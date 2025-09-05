using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("7C7044DF-73BA-4D2C-91B0-96079BED45FC"),
                RoleId = Guid.Parse("1E3FA38B-F05A-44D9-BCD5-8457EF3F59A7")
            },
            new AppUserRole 
            {
                UserId = Guid.Parse("473EE9ED-7F9C-44C1-B2AB-AE340B6969C0"),
                RoleId = Guid.Parse("70C0F847-FA43-4CB0-84B0-7276842AD863")
            });
        }
    }
}
