using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"), "Admin Test", new DateTime(2023, 8, 29, 20, 26, 23, 955, DateTimeKind.Local).AddTicks(8474), null, null, false, null, null, "Kategori2" },
                    { new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"), "Admin Test", new DateTime(2023, 8, 29, 20, 26, 23, 955, DateTimeKind.Local).AddTicks(8647), null, null, false, null, null, null },
                    { new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"), "Admin Test", new DateTime(2023, 8, 29, 20, 26, 23, 955, DateTimeKind.Local).AddTicks(8632), null, null, false, null, null, null },
                    { new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"), "Admin Test", new DateTime(2023, 8, 29, 20, 26, 23, 955, DateTimeKind.Local).AddTicks(8469), null, null, false, null, null, "Kategori1" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("b442f80f-25e1-4d1e-9499-8acdde2a4009"), new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 8, 29, 20, 26, 23, 955, DateTimeKind.Local).AddTicks(8222), null, null, new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"), false, null, null, "Asp.net core ile geliştirme.", 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("b442f80f-25e1-4d1e-9499-8acdde2a4009"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"));
        }
    }
}
