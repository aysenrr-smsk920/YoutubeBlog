using YoutubeBlog.Entity.DTO.Articles;
using YoutubeBlog.Entity.DTOs.Articles;

namespace YoutubeBlog.Service.Services.Abstraction
{
    public interface IArticleService
    {
        Task<List<ArticleDTO>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<List<ArticleDTO>> GetAllArticlesWithCategoryDeletedAsync();
        Task<ArticleDTO> GetArticlesWithCategoryNonDeletedAsync(Guid articleId);
        Task CreadteArticleAsync(ArticleAddDTO articleAddDTO);
        Task<string> UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
        Task<string> UndoDeleteArticleAsync(Guid articleId);
        Task<ArticleListDTO> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<ArticleListDTO> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);


    }
}