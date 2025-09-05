using Microsoft.AspNetCore.Identity;
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid? ImageId { get; set; } = Guid.Parse("C4C81017-A819-4B6B-B500-366333C98506");

        public Image Image {  get; set; }

        public ICollection<Article> Articles { get; set; } //birden çoğa

    }
}
 