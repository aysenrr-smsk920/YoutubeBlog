using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
    {
        protected AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Category {  get; set; }
        public DbSet<Image> Image {  get; set; }
        public DbSet<Visitor> visitors { get; set; }
        public DbSet<ArticleVisitor> articleVisitors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Article>().Property(x => x.Title).HasMaxLength(150); burada tanımlaması mantıklı olmaz map de yapılmalı
            //builder.ApplyConfiguration(new ArticleMap()); bu şekilde de kullanılabilir ama diğerlerini de tek tek eklememiz gerekiyor.

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
