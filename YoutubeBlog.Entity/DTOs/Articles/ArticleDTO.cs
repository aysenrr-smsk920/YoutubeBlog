using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTO.Articles
{
    public class ArticleDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }   
        public string Content { get; set; }   
        public CategoryDTO Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public Image Image { get; set; }
        public AppUser User { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int ViewCount { get; set; }

    }
}
