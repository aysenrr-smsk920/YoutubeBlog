using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //builder.Property(x => x.Title).HasMaxLength(150);
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Asp.net Core Deneme Makalesi 1",
                Content = "Asp.NET Core, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.",
                ViewCount = 15,
                CategoryId = Guid.Parse("D9D161D1-5F1C-4795-B58E-9538B3C2AA42"),
                ImageId = Guid.Parse("C4C81017-A819-4B6B-B500-366333C98506"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("7C7044DF-73BA-4D2C-91B0-96079BED45FC")
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Deneme Makalesi 1",
                Content = "Visual Studio, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.",
                ViewCount = 15,
                CategoryId = Guid.Parse("BE73C158-096F-4175-B17F-9911FAB18085"),
                ImageId = Guid.Parse("300A25DD-266D-4322-AD20-794EFD1E3B22"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("473EE9ED-7F9C-44C1-B2AB-AE340B6969C0")
            });
        }
    }
}
