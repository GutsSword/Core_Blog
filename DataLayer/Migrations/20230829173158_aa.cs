using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e91a6f5d-c276-468e-8981-c1eab1b47c64"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("f1d0e2d7-8f1c-49b7-b159-71459d605bbd"), new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 8, 29, 20, 31, 58, 263, DateTimeKind.Local).AddTicks(1941), null, null, new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"), false, null, null, "Asp.net core ile geliştirme.", 15 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 31, 58, 263, DateTimeKind.Local).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 31, 58, 263, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 31, 58, 263, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 31, 58, 263, DateTimeKind.Local).AddTicks(2281));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f1d0e2d7-8f1c-49b7-b159-71459d605bbd"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("e91a6f5d-c276-468e-8981-c1eab1b47c64"), new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 8, 29, 20, 29, 11, 152, DateTimeKind.Local).AddTicks(1227), null, null, new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"), false, null, null, "Asp.net core ile geliştirme.", 15 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 29, 11, 152, DateTimeKind.Local).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 29, 11, 152, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 29, 11, 152, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 29, 11, 152, DateTimeKind.Local).AddTicks(1625));
        }
    }
}
