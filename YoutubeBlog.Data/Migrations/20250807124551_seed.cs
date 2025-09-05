using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeBlog.Data.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("cc10d066-3845-45bb-81fd-e115212da5ca"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("fcb7fc85-bca5-4cde-939f-c84dc1a7acbd"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1a35bd45-c0b2-4a18-bf02-1701a906daa3"), new Guid("d9d161d1-5f1c-4795-b58e-9538b3c2aa42"), "Asp.NET Core, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.", "Admin Test", new DateTime(2025, 8, 7, 15, 45, 50, 519, DateTimeKind.Local).AddTicks(6852), null, null, new Guid("c4c81017-a819-4b6b-b500-366333c98506"), false, null, null, "Asp.net Core Deneme Makalesi 1", new Guid("7c7044df-73ba-4d2c-91b0-96079bed45fc"), 15 },
                    { new Guid("4fc17d7c-635c-4db4-a73d-f2a5a3a8d620"), new Guid("be73c158-096f-4175-b17f-9911fab18085"), "Visual Studio, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.", "Admin Test", new DateTime(2025, 8, 7, 15, 45, 50, 519, DateTimeKind.Local).AddTicks(6859), null, null, new Guid("300a25dd-266d-4322-ad20-794efd1e3b22"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("473ee9ed-7f9c-44c1-b2ab-ae340b6969c0"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e3fa38b-f05a-44d9-bcd5-8457ef3f59a7"),
                column: "ConcurrencyStamp",
                value: "88b6cb44-2541-42c0-9a69-98ab7caa12a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("70c0f847-fa43-4cb0-84b0-7276842ad863"),
                column: "ConcurrencyStamp",
                value: "990da6f8-9f68-4575-8021-e5f4a5a93d17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5bc073c-fef8-43ea-8212-7e2a28c7b6bf"),
                column: "ConcurrencyStamp",
                value: "b6deda79-df2c-4327-8f12-b6d2bb22cec4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("473ee9ed-7f9c-44c1-b2ab-ae340b6969c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dd194f6-4d2f-41db-a5b0-6c066c258e8c", "AQAAAAEAACcQAAAAEGH14yHaySofIb929NGzTJ2wse6p5TpYJeUPL6n5NIQWxLAuhAtk3Uw+h6CnnMq5MQ==", "77b257a5-1363-411b-9690-056781fc161a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c7044df-73ba-4d2c-91b0-96079bed45fc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b8948e2-74c5-4d92-969b-8b1fa2de8e1a", "AQAAAAEAACcQAAAAEGI//4pFFu3T2tUeg+iFNKkeLHosydJ9b+nBdgX4G8kmgOz1drig/CzGPN4YYk110g==", "c07b4faf-baa3-4ff1-8d3b-593a9a25d219" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("be73c158-096f-4175-b17f-9911fab18085"),
                column: "CreatedDate",
                value: new DateTime(2025, 8, 7, 15, 45, 50, 519, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d9d161d1-5f1c-4795-b58e-9538b3c2aa42"),
                column: "CreatedDate",
                value: new DateTime(2025, 8, 7, 15, 45, 50, 519, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("300a25dd-266d-4322-ad20-794efd1e3b22"),
                column: "CreatedDate",
                value: new DateTime(2025, 8, 7, 15, 45, 50, 519, DateTimeKind.Local).AddTicks(7144));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("c4c81017-a819-4b6b-b500-366333c98506"),
                column: "CreatedDate",
                value: new DateTime(2025, 8, 7, 15, 45, 50, 519, DateTimeKind.Local).AddTicks(7141));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1a35bd45-c0b2-4a18-bf02-1701a906daa3"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4fc17d7c-635c-4db4-a73d-f2a5a3a8d620"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("cc10d066-3845-45bb-81fd-e115212da5ca"), new Guid("be73c158-096f-4175-b17f-9911fab18085"), "Visual Studio, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.", "Admin Test", new DateTime(2025, 7, 21, 9, 28, 4, 510, DateTimeKind.Local).AddTicks(1500), null, null, new Guid("300a25dd-266d-4322-ad20-794efd1e3b22"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("473ee9ed-7f9c-44c1-b2ab-ae340b6969c0"), 15 },
                    { new Guid("fcb7fc85-bca5-4cde-939f-c84dc1a7acbd"), new Guid("d9d161d1-5f1c-4795-b58e-9538b3c2aa42"), "Asp.NET Core, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.", "Admin Test", new DateTime(2025, 7, 21, 9, 28, 4, 510, DateTimeKind.Local).AddTicks(1492), null, null, new Guid("c4c81017-a819-4b6b-b500-366333c98506"), false, null, null, "Asp.net Core Deneme Makalesi 1", new Guid("7c7044df-73ba-4d2c-91b0-96079bed45fc"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e3fa38b-f05a-44d9-bcd5-8457ef3f59a7"),
                column: "ConcurrencyStamp",
                value: "3dfc22c5-6200-4ebb-9687-1c1b02ebcfbd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("70c0f847-fa43-4cb0-84b0-7276842ad863"),
                column: "ConcurrencyStamp",
                value: "c960ae0c-abff-4ae8-bbdb-50e060a9888a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5bc073c-fef8-43ea-8212-7e2a28c7b6bf"),
                column: "ConcurrencyStamp",
                value: "db632edd-100f-4f82-aaff-68d14878c68e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("473ee9ed-7f9c-44c1-b2ab-ae340b6969c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fa99480-532d-438c-aea9-206f05e8e3b2", "AQAAAAEAACcQAAAAEHvH50aFh3EJVSLY0Cp5WgtQn2for9VcH7UDncNTtXCeCvsoTFT0eEVYk8FEgNPoYg==", "30c09146-82d6-4d9e-af5f-9e168e418494" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c7044df-73ba-4d2c-91b0-96079bed45fc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "daf7d6f6-873f-4063-aaed-8f6d2cec4866", "AQAAAAEAACcQAAAAEBRY2fT67Uin8Nq24A4MFmkMx2DblMEeKWPITPtMHThuBe3mfUlBPJDNLngM3MC1og==", "42af73ac-59be-40d1-b3d1-6748a5a5e831" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("be73c158-096f-4175-b17f-9911fab18085"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 21, 9, 28, 4, 510, DateTimeKind.Local).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d9d161d1-5f1c-4795-b58e-9538b3c2aa42"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 21, 9, 28, 4, 510, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("300a25dd-266d-4322-ad20-794efd1e3b22"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 21, 9, 28, 4, 510, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("c4c81017-a819-4b6b-b500-366333c98506"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 21, 9, 28, 4, 510, DateTimeKind.Local).AddTicks(1766));
        }
    }
}
