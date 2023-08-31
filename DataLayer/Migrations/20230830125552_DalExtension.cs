using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class DalExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1225059f-c356-49c6-8472-be86ba67cd0d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("650317a5-5a17-47fc-94bd-7c6c3a0a9e34"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("4face794-f74a-4011-9c37-e87c039a08fc"), new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 8, 30, 15, 55, 51, 776, DateTimeKind.Local).AddTicks(980), null, null, new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"), false, null, null, "Asp.net core ile geliştirme.", 15 },
                    { new Guid("5defe240-19cf-45b3-91cf-d92c8909d8ee"), new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 8, 30, 15, 55, 51, 776, DateTimeKind.Local).AddTicks(992), null, null, new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"), false, null, null, "2.Asp.net core makale yazısı.", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 30, 15, 55, 51, 776, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 30, 15, 55, 51, 776, DateTimeKind.Local).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 30, 15, 55, 51, 776, DateTimeKind.Local).AddTicks(2956));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 30, 15, 55, 51, 776, DateTimeKind.Local).AddTicks(2949));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4face794-f74a-4011-9c37-e87c039a08fc"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("5defe240-19cf-45b3-91cf-d92c8909d8ee"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1225059f-c356-49c6-8472-be86ba67cd0d"), new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(7884), null, null, new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"), false, null, null, "2.Asp.net core makale yazısı.", 15 },
                    { new Guid("650317a5-5a17-47fc-94bd-7c6c3a0a9e34"), new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(7877), null, null, new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"), false, null, null, "Asp.net core ile geliştirme.", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(8161));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(8289));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(8285));
        }
    }
}
