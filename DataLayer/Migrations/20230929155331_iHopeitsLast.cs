using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class iHopeitsLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2fb42331-6926-486c-a501-7feb89e802a8"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7f14b6ba-8893-4060-9d76-cd3415a9c096"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("78f2503b-0257-4df5-a30b-b4578d2564f0"), new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 9, 29, 18, 53, 30, 726, DateTimeKind.Local).AddTicks(751), null, null, new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"), false, null, null, "Asp.net core ile geliştirme.", new Guid("6c7bf599-963f-47f3-b488-0218ea50fbec"), 15 },
                    { new Guid("9133be17-5658-4819-87e8-91d29fb9904c"), new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 9, 29, 18, 53, 30, 726, DateTimeKind.Local).AddTicks(765), null, null, new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"), false, null, null, "2.Asp.net core makale yazısı.", new Guid("71829b03-40ee-42d5-a62e-2827d34a02fa"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43825a01-65a3-43ad-a6d1-8c0a70bde378"),
                column: "ConcurrencyStamp",
                value: "3db2e0cf-d213-4136-8fe9-697ed5ef522d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ad28833-513a-4101-a75d-21b871d22562"),
                column: "ConcurrencyStamp",
                value: "ca5d2a6c-1071-4e71-8136-22e9b17ff90a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ebf0ef6f-1d52-4197-96c0-0c48fbac76ad"),
                column: "ConcurrencyStamp",
                value: "5bf518f0-32b4-4d41-83df-21c739487667");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c7bf599-963f-47f3-b488-0218ea50fbec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbc0c2f5-f0a1-4968-ae1f-a2eab722f422", "AQAAAAEAACcQAAAAEKKimrColSbGvwdu0RPZ9FXAD8EBIIA5xkjDVheXwhJ3Q3sZ7DDgEzjAu5byRJQFPA==", "f5f7db56-30e2-47b5-9a53-71c13ff4c19a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("71829b03-40ee-42d5-a62e-2827d34a02fa"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "831eea05-bc79-47f2-9fe7-ccd1a7e2dd7c", "c7be4b64-f147-4cbb-a360-3ca405653096" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 18, 53, 30, 726, DateTimeKind.Local).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 18, 53, 30, 726, DateTimeKind.Local).AddTicks(5327));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 18, 53, 30, 726, DateTimeKind.Local).AddTicks(5548));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 18, 53, 30, 726, DateTimeKind.Local).AddTicks(5543));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("78f2503b-0257-4df5-a30b-b4578d2564f0"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9133be17-5658-4819-87e8-91d29fb9904c"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("2fb42331-6926-486c-a501-7feb89e802a8"), new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 9, 29, 14, 6, 55, 624, DateTimeKind.Local).AddTicks(171), null, null, new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"), false, null, null, "2.Asp.net core makale yazısı.", new Guid("71829b03-40ee-42d5-a62e-2827d34a02fa"), 15 },
                    { new Guid("7f14b6ba-8893-4060-9d76-cd3415a9c096"), new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 9, 29, 14, 6, 55, 624, DateTimeKind.Local).AddTicks(163), null, null, new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"), false, null, null, "Asp.net core ile geliştirme.", new Guid("6c7bf599-963f-47f3-b488-0218ea50fbec"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43825a01-65a3-43ad-a6d1-8c0a70bde378"),
                column: "ConcurrencyStamp",
                value: "ece642dd-aaa3-465a-be01-6acfedbc98eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ad28833-513a-4101-a75d-21b871d22562"),
                column: "ConcurrencyStamp",
                value: "7f255222-c1eb-43c6-8be3-828282a04ac2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ebf0ef6f-1d52-4197-96c0-0c48fbac76ad"),
                column: "ConcurrencyStamp",
                value: "59b7070f-0168-4fdd-925f-1097bfc57d76");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c7bf599-963f-47f3-b488-0218ea50fbec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c831054-3cf2-4443-a554-e77421d243e0", "AQAAAAEAACcQAAAAEIdNQYFi0WtlH1h0liCHSI3QO1puJrIWaXSr/UwVB7g9ntTZsJn8y+hdeGX7aS26/w==", "23540f3f-5494-44f3-a04e-cb8a435932b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("71829b03-40ee-42d5-a62e-2827d34a02fa"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1d0b47a0-8e08-4243-9911-21fe4d1866f0", "404de6be-56e0-4b90-bb42-7a5f85755143" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 14, 6, 55, 624, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 14, 6, 55, 624, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 14, 6, 55, 624, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 14, 6, 55, 624, DateTimeKind.Local).AddTicks(2182));
        }
    }
}
