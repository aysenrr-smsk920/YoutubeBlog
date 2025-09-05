using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Category : EntityBase 
    {
        public Category() 
        { 

        }
        public Category(string name, string createdBy) 
        {
            Name = name;
            CreatedBy = createdBy;
        }
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
