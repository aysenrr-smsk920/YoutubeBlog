using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeBlog.Data.Migrations
{
    public partial class visit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1a35bd45-c0b2-4a18-bf02-1701a906daa3"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4fc17d7c-635c-4db4-a73d-f2a5a3a8d620"));

            migrationBuilder.CreateTable(
                name: "visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "articleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_articleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articleVisitors_visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("2ac9b860-dddc-4b1d-8995-94dc7435d461"), new Guid("be73c158-096f-4175-b17f-9911fab18085"), "Visual Studio, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.", "Admin Test", new DateTime(2025, 8, 9, 13, 57, 47, 371, DateTimeKind.Local).AddTicks(1115), null, null, new Guid("300a25dd-266d-4322-ad20-794efd1e3b22"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("473ee9ed-7f9c-44c1-b2ab-ae340b6969c0"), 15 },
                    { new Guid("ad08c4de-b794-47b8-b1ce-649fb28a7267"), new Guid("d9d161d1-5f1c-4795-b58e-9538b3c2aa42"), "Asp.NET Core, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.", "Admin Test", new DateTime(2025, 8, 9, 13, 57, 47, 371, DateTimeKind.Local).AddTicks(1108), null, null, new Guid("c4c81017-a819-4b6b-b500-366333c98506"), false, null, null, "Asp.net Core Deneme Makalesi 1", new Guid("7c7044df-73ba-4d2c-91b0-96079bed45fc"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e3fa38b-f05a-44d9-bcd5-8457ef3f59a7"),
                column: "ConcurrencyStamp",
                value: "18311075-b0b1-446a-ac29-3316a2469ffb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("70c0f847-fa43-4cb0-84b0-7276842ad863"),
                column: "ConcurrencyStamp",
                value: "d39883a3-3dd5-4922-a7db-6cc4d2341fe1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5bc073c-fef8-43ea-8212-7e2a28c7b6bf"),
                column: "ConcurrencyStamp",
                value: "0104b24d-9ea6-4cc3-b49c-fb91b8bedbac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("473ee9ed-7f9c-44c1-b2ab-ae340b6969c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a41b3734-8ea1-4b4f-a2d8-0a0653d91ca6", "AQAAAAEAACcQAAAAEFmXuJTiO/cuPwtBaR8KBrcSjVUp2Lf7kxPlQGqq4ZIhMOmkQZ6IAWR+xVZSaMCw6g==", "601703a5-53ee-413c-a902-adf96c22acf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c7044df-73ba-4d2c-91b0-96079bed45fc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b711054-7fd1-4763-afca-867460381153", "AQAAAAEAACcQAAAAELhO4m6pr4IdklfyQ9QAIH78e4obZda//iCc3N8gOKrBSTB125HsWgm52vxiE1cmcQ==", "0618464d-7622-429f-8508-da19662abd0f" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("be73c158-096f-4175-b17f-9911fab18085"),
                column: "CreatedDate",
                value: new DateTime(2025, 8, 9, 13, 57, 47, 371, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d9d161d1-5f1c-4795-b58e-9538b3c2aa42"),
                column: "CreatedDate",
                value: new DateTime(2025, 8, 9, 13, 57, 47, 371, DateTimeKind.Local).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("300a25dd-266d-4322-ad20-794efd1e3b22"),
                column: "CreatedDate",
                value: new DateTime(2025, 8, 9, 13, 57, 47, 371, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("c4c81017-a819-4b6b-b500-366333c98506"),
                column: "CreatedDate",
                value: new DateTime(2025, 8, 9, 13, 57, 47, 371, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.CreateIndex(
                name: "IX_articleVisitors_VisitorId",
                table: "articleVisitors",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articleVisitors");

            migrationBuilder.DropTable(
                name: "visitors");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2ac9b860-dddc-4b1d-8995-94dc7435d461"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ad08c4de-b794-47b8-b1ce-649fb28a7267"));

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
    }
}
