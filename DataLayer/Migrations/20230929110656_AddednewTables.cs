using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class AddednewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a0a9b5cf-3529-4ecd-867c-299db51d180c"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("adc7e5e0-149c-46b2-9299-98163e2ddf63"));

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

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
                    { new Guid("a0a9b5cf-3529-4ecd-867c-299db51d180c"), new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 8, 31, 20, 56, 39, 418, DateTimeKind.Local).AddTicks(6986), null, null, new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"), false, null, null, "2.Asp.net core makale yazısı.", new Guid("71829b03-40ee-42d5-a62e-2827d34a02fa"), 15 },
                    { new Guid("adc7e5e0-149c-46b2-9299-98163e2ddf63"), new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 8, 31, 20, 56, 39, 418, DateTimeKind.Local).AddTicks(6979), null, null, new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"), false, null, null, "Asp.net core ile geliştirme.", new Guid("6c7bf599-963f-47f3-b488-0218ea50fbec"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43825a01-65a3-43ad-a6d1-8c0a70bde378"),
                column: "ConcurrencyStamp",
                value: "d715b09b-61a2-444e-b9d0-9f70ccdcfdd4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ad28833-513a-4101-a75d-21b871d22562"),
                column: "ConcurrencyStamp",
                value: "003ecdc9-9fdb-4d09-88cf-f50223a10c54");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ebf0ef6f-1d52-4197-96c0-0c48fbac76ad"),
                column: "ConcurrencyStamp",
                value: "79688628-b07d-4bb0-b0fc-1d666b2d5049");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c7bf599-963f-47f3-b488-0218ea50fbec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0e8e752-4796-4590-a87c-c58c550aaced", "AQAAAAEAACcQAAAAEPBSD9r9vcGR2Ei3CKBpojcMe7qpshC6n2dkWf6AAYQT7vIcXRRb/BN2iJ3EIlB4eg==", "f0df7cf5-23a3-4924-8bb9-47e4eab58a32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("71829b03-40ee-42d5-a62e-2827d34a02fa"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ab74bd10-9229-4df1-a146-5fb6eed13314", "4742bad3-5955-4d38-b853-66352a8c670f" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 20, 56, 39, 418, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 20, 56, 39, 418, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 20, 56, 39, 418, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 20, 56, 39, 418, DateTimeKind.Local).AddTicks(7474));
        }
    }
}
