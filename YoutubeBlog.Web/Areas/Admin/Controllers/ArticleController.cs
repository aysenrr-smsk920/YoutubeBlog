using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstraction;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryServise;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;
        private readonly IToastNotification toast;

        public ArticleController(IArticleService articleService, ICategoryService categoryServise, IMapper mapper, IValidator<Article> validator, IToastNotification toast)
        {
            this.articleService = articleService;
            this.categoryServise = categoryServise;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConst.Superadmin},{RoleConst.Admin}, {RoleConst.User}")]
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConst.Superadmin},{RoleConst.Admin}")]
        public async Task<IActionResult> DeletedArticle()
        {
            var articles = await articleService.GetAllArticlesWithCategoryDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConst.Superadmin},{RoleConst.Admin}")]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryServise.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDTO { Categories = categories });
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConst.Superadmin},{RoleConst.Admin}")]
        public async Task<IActionResult> Add(ArticleAddDTO articleAddDTO)
        {
            var map = mapper.Map<Article>(articleAddDTO);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articleService.CreadteArticleAsync(articleAddDTO);
                toast.AddSuccessToastMessage(Messages.Article.Add(articleAddDTO.Title), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);

            }
            var categories = await categoryServise.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDTO { Categories = categories });
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConst.Superadmin},{RoleConst.Admin}")]
        public async Task<IActionResult> Update(Guid articleId)//önemli 
        {
            var article = await articleService.GetArticlesWithCategoryNonDeletedAsync(articleId);
            var categories = await categoryServise.GetAllCategoriesNonDeleted();

            var articleUpdateDTO = mapper.Map<ArticleUpdateDTO>(article);
            articleUpdateDTO.Categories = categories;

            return View(articleUpdateDTO);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConst.Superadmin},{RoleConst.Admin}")]
        public async Task<IActionResult> Update(ArticleUpdateDTO articleUpdateDTO)//önemli 
        {
            var map = mapper.Map<Article>(articleUpdateDTO);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var title = await articleService.UpdateArticleAsync(articleUpdateDTO);
                toast.AddSuccessToastMessage(Messages.Article.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            var categories = await categoryServise.GetAllCategoriesNonDeleted();

            articleUpdateDTO.Categories = categories;

            return View(articleUpdateDTO);
        }
        [Authorize(Roles = $"{RoleConst.Superadmin},{RoleConst.Admin}")]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            var title = await articleService.SafeDeleteArticleAsync(articleId);
            toast.AddSuccessToastMessage(Messages.Article.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
        [Authorize(Roles = $"{RoleConst.Superadmin},{RoleConst.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid articleId)
        {
            var title = await articleService.UndoDeleteArticleAsync(articleId);
            toast.AddSuccessToastMessage(Messages.Article.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}
