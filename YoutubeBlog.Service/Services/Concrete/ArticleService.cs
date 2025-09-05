using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTO.Articles;
using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Services.Abstraction;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitofwork, IMapper mapper,IHttpContextAccessor httpContextAccessor,IImageHelper imageHelper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            this.imageHelper = imageHelper;
        }
        public async Task<ArticleListDTO> GetAllByPagingAsync(Guid? categoryId,int currentPage=1,int pageSize=3,bool isAscending= false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = categoryId == null
                ? await unitofwork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Image, u => u.User)
                : await unitofwork.GetRepository<Article>().GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted, x => x.Category, i => i.Image, u => u.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListDTO
            {
                Articles = sortedArticles,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
                

            };
        }
        public async Task CreadteArticleAsync(ArticleAddDTO articleAddDTO)
        {

            //var userId = Guid.Parse("473EE9ED-7F9C-44C1-B2AB-AE340B6969C0");
            //var userId = httpContextAccessor.HttpContext.User.GetLoggedUserId(); uzun kullanımı bu bunun erine cosnt tanımlayıp kısaca kullanalım 
            var userId = _user.GetLoggedUserId();
            var userEmail = _user.GetLoggedUserEmail();

            var imageUpload = await imageHelper.Upload(articleAddDTO.Title, articleAddDTO.Photo,ImageType.Post);
            Image image = new(imageUpload.Fullname, articleAddDTO.Photo.ContentType, userEmail);
            await unitofwork.GetRepository<Image>().AddAsync(image);

            var article = new Article(articleAddDTO.Title, articleAddDTO.Content, userId,userEmail,articleAddDTO.CategoryId, image.Id);

            await unitofwork.GetRepository<Article>().AddAsync(article);
            await unitofwork.SaveAsync();
        }

        public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await unitofwork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDTO>>(articles);
            return map; // getallasync repositoryden geliyor
        }
        public async Task<ArticleDTO> GetArticlesWithCategoryNonDeletedAsync(Guid articleId)
        {
            var article = await unitofwork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i=>i.Image, u=>u.User);
            var map = mapper.Map<ArticleDTO>(article);
            return map; // getallasync repositoryden geliyor
        }
        public async Task<string> UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO)
        {
            var userEmail = _user.GetLoggedUserEmail();
            var article = await unitofwork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDTO.Id, x => x.Category, i=>i.Image);

            if(articleUpdateDTO.Photo != null)
            {
                imageHelper.Delete(article.Image.FileName);

                var imageUpload = await imageHelper.Upload(articleUpdateDTO.Title, articleUpdateDTO.Photo, ImageType.Post);
                Image image = new(imageUpload.Fullname, articleUpdateDTO.Photo.ContentType, userEmail);
                await unitofwork.GetRepository<Image>().AddAsync(image); 

                article.ImageId = image.Id;
            }

            mapper.Map(articleUpdateDTO, article);
            //article.Title = articleUpdateDTO.Title;
            //article.Content = articleUpdateDTO.Content;
            //article.CategoryId = articleUpdateDTO.CategoryId;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;
            //article.IsCompleted = true;

            await unitofwork.GetRepository<Article>().UpdateAsync(article);
            await unitofwork.SaveAsync();

            return article.Title;
        }
        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedUserEmail();
            var article = await unitofwork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;

            await unitofwork.GetRepository<Article>().UpdateAsync(article);
            await unitofwork.SaveAsync();

            return article.Title;
        }

        public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryDeletedAsync()
        {
            var articles = await unitofwork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDTO>>(articles);
            return map;
        }

        public async Task<string> UndoDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedUserEmail();
            var article = await unitofwork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;

            await unitofwork.GetRepository<Article>().UpdateAsync(article);
            await unitofwork.SaveAsync();

            return article.Title;
        }

        public async Task<ArticleListDTO> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = await unitofwork.GetRepository<Article>().GetAllAsync(
                a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword)), 
                a => a.Category, i => i.Image, u => u.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListDTO
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending

            };
        }
    }
}
