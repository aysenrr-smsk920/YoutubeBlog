using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeBlog.Data.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("14ef2a43-7039-4969-a4ff-4280bcb7433b"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("b21b5ec2-f8f2-473c-811d-436ccc111d5b"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("081389c3-4337-4907-993b-bb1be8ee4a62"), new Guid("be73c158-096f-4175-b17f-9911fab18085"), "Visual Studio, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.", "Admin Test", new DateTime(2025, 7, 21, 8, 59, 29, 336, DateTimeKind.Local).AddTicks(9450), null, null, new Guid("300a25dd-266d-4322-ad20-794efd1e3b22"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("473ee9ed-7f9c-44c1-b2ab-ae340b6969c0"), 15 },
                    { new Guid("ec7b3f74-840f-41b6-8aa9-ee439166557f"), new Guid("d9d161d1-5f1c-4795-b58e-9538b3c2aa42"), "Asp.NET Core, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.", "Admin Test", new DateTime(2025, 7, 21, 8, 59, 29, 336, DateTimeKind.Local).AddTicks(9443), null, null, new Guid("c4c81017-a819-4b6b-b500-366333c98506"), false, null, null, "Asp.net Core Deneme Makalesi 1", new Guid("7c7044df-73ba-4d2c-91b0-96079bed45fc"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e3fa38b-f05a-44d9-bcd5-8457ef3f59a7"),
                column: "ConcurrencyStamp",
                value: "16d8b82b-dad2-4b20-9a7c-8c2b0bfcd834");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("70c0f847-fa43-4cb0-84b0-7276842ad863"),
                column: "ConcurrencyStamp",
                value: "3689410a-e61c-435c-9f82-f19a0eb93439");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5bc073c-fef8-43ea-8212-7e2a28c7b6bf"),
                column: "ConcurrencyStamp",
                value: "3c1b1dae-3239-4e48-8df7-37ac5c51b5c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("473ee9ed-7f9c-44c1-b2ab-ae340b6969c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "770af162-5d0a-49af-beba-d14e7a75a7c4", "AQAAAAEAACcQAAAAEHoNl9O/igiDyM3O9suzmw6r0RpsWPdq1Lzt29EX3hhLQ2bjZYQcCFW45XS64efyhQ==", "5916cd3e-5b5b-4e7c-a8cc-eb70e76b42cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c7044df-73ba-4d2c-91b0-96079bed45fc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddb3bdd5-765b-4506-9fdd-836ef4a58a70", "AQAAAAEAACcQAAAAEJDjtl9oYCHy4vOEaNMz7TDQpf28dmxYMZx5eG9ivOBOsxhMSU43BZIy/Vg6J7VB6Q==", "8e91d07b-7db9-4a45-b432-6acbc87b9245" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("be73c158-096f-4175-b17f-9911fab18085"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 21, 8, 59, 29, 336, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d9d161d1-5f1c-4795-b58e-9538b3c2aa42"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 21, 8, 59, 29, 336, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("300a25dd-266d-4322-ad20-794efd1e3b22"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 21, 8, 59, 29, 336, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("c4c81017-a819-4b6b-b500-366333c98506"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 21, 8, 59, 29, 336, DateTimeKind.Local).AddTicks(9796));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("081389c3-4337-4907-993b-bb1be8ee4a62"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ec7b3f74-840f-41b6-8aa9-ee439166557f"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("14ef2a43-7039-4969-a4ff-4280bcb7433b"), new Guid("d9d161d1-5f1c-4795-b58e-9538b3c2aa42"), "Asp.NET Core, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.", "Admin Test", new DateTime(2025, 7, 20, 23, 37, 4, 750, DateTimeKind.Local).AddTicks(2423), null, null, new Guid("c4c81017-a819-4b6b-b500-366333c98506"), false, null, null, "Asp.net Core Deneme Makalesi 1", new Guid("7c7044df-73ba-4d2c-91b0-96079bed45fc"), 15 },
                    { new Guid("b21b5ec2-f8f2-473c-811d-436ccc111d5b"), new Guid("be73c158-096f-4175-b17f-9911fab18085"), "Visual Studio, Microsoft tarafından geliştirilen, açık kaynaklı ve platformlar arası (cross-platform) bir uygulama geliştirme çerçevesidir. Yüksek performansı, modüler yapısı ve esnekliği sayesinde web, masaüstü ve bulut tabanlı uygulamalarda sıkça tercih edilir. Özellikle ASP.NET Core ile birlikte modern web API'leri ve dinamik web siteleri geliştirmek oldukça kolay ve hızlıdır.", "Admin Test", new DateTime(2025, 7, 20, 23, 37, 4, 750, DateTimeKind.Local).AddTicks(2428), null, null, new Guid("300a25dd-266d-4322-ad20-794efd1e3b22"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("473ee9ed-7f9c-44c1-b2ab-ae340b6969c0"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e3fa38b-f05a-44d9-bcd5-8457ef3f59a7"),
                column: "ConcurrencyStamp",
                value: "36d344d7-41a9-42da-9008-8916933c730b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("70c0f847-fa43-4cb0-84b0-7276842ad863"),
                column: "ConcurrencyStamp",
                value: "cad28ebd-821c-440f-8b4f-0cba69ce3b07");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5bc073c-fef8-43ea-8212-7e2a28c7b6bf"),
                column: "ConcurrencyStamp",
                value: "77313cb7-6315-44f4-aed7-16fc4af9a2ef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("473ee9ed-7f9c-44c1-b2ab-ae340b6969c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a5a88ec-b1cb-4d9b-a60d-ea6175c12eb4", "AQAAAAEAACcQAAAAENjqxcnCBpniiP/XcTtMo/fXPhd38LwwR6z3EuNuBAqjaT5X3tlt+DoLZSp00Cm4nA==", "295183b7-5ceb-43c1-ae56-b08b7386e770" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c7044df-73ba-4d2c-91b0-96079bed45fc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50aaef85-b5ed-4923-943d-15599bedfcdc", "AQAAAAEAACcQAAAAEFiR09YQfTaGdpnW3yn72vCbzB6pyiDX/GW+Jj9svkdl9dglus0Ug9LOiLUOP/ESiA==", "026c99f6-2b8d-45f1-855e-a3ba15fc348d" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("be73c158-096f-4175-b17f-9911fab18085"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 20, 23, 37, 4, 750, DateTimeKind.Local).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d9d161d1-5f1c-4795-b58e-9538b3c2aa42"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 20, 23, 37, 4, 750, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("300a25dd-266d-4322-ad20-794efd1e3b22"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 20, 23, 37, 4, 750, DateTimeKind.Local).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("c4c81017-a819-4b6b-b500-366333c98506"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 20, 23, 37, 4, 750, DateTimeKind.Local).AddTicks(2738));
        }
    }
}
