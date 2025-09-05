 using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Article : EntityBase
    {
        public Article()
        {
            
        }
        public Article(string title, string content , Guid userId, string createdby, Guid categoryId, Guid imageId)
        {
            Title= title;
            Content= content;
            UserId= userId;
            CategoryId= categoryId;
            ImageId= imageId;
            CreatedBy = createdby;
            // ViewCount= 0; bu şekilde de sıfır olarak verilir.
        }
      

        public Guid Id { get; set; }
        public string Title { get; set; } //başlık
        public string Content { get; set; } //içerik
        public int ViewCount { get; set; } = 0; //görüntüleme

        public Guid CategoryId { get; set; }
        public Category Category {  get; set; }

        public Guid? ImageId { get; set; }
        public Image Image { get; set; }

        public Guid UserId { get; set; }

        public AppUser User { get; set; }

        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }


    }
}
