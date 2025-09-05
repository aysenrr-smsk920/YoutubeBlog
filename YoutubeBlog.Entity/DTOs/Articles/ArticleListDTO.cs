using YoutubeBlog.Entity.DTO.Articles;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Articles
{
    public class ArticleListDTO
    {
        public IList<Article> Articles { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual int CurrentPage { get; set; } = 1; //hangipagede 
        public virtual int PageSize { get; set; } = 3; //bir sayfada kaç tane gözükecek
        public virtual int TotalCount { get; set; }//sayfa sayısı 50/10=5 gibi
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));
        public virtual bool ShowPrevious => CurrentPage > 1;
        public virtual bool ShowNext => CurrentPage < TotalPages;
        public virtual bool IsAscending { get; set; }
    }
}
