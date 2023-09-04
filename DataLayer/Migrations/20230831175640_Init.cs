using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("39309ea3-d363-4c62-b9b5-963196a8f264"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9135080c-a174-483b-bb82-6a8b31d0e1d8"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                columns: new[] { "ConcurrencyStamp", "ImageId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0e8e752-4796-4590-a87c-c58c550aaced", new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"), "AQAAAAEAACcQAAAAEPBSD9r9vcGR2Ei3CKBpojcMe7qpshC6n2dkWf6AAYQT7vIcXRRb/BN2iJ3EIlB4eg==", "f0df7cf5-23a3-4924-8bb9-47e4eab58a32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("71829b03-40ee-42d5-a62e-2827d34a02fa"),
                columns: new[] { "ConcurrencyStamp", "ImageId", "SecurityStamp" },
                values: new object[] { "ab74bd10-9229-4df1-a146-5fb6eed13314", new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"), "4742bad3-5955-4d38-b853-66352a8c670f" });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId",
                table: "Articles");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a0a9b5cf-3529-4ecd-867c-299db51d180c"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("adc7e5e0-149c-46b2-9299-98163e2ddf63"));

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Articles");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("39309ea3-d363-4c62-b9b5-963196a8f264"), new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 8, 31, 19, 0, 42, 831, DateTimeKind.Local).AddTicks(8338), null, null, new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"), false, null, null, "Asp.net core ile geliştirme.", 15 },
                    { new Guid("9135080c-a174-483b-bb82-6a8b31d0e1d8"), new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", "Admin Test", new DateTime(2023, 8, 31, 19, 0, 42, 831, DateTimeKind.Local).AddTicks(8344), null, null, new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"), false, null, null, "2.Asp.net core makale yazısı.", 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43825a01-65a3-43ad-a6d1-8c0a70bde378"),
                column: "ConcurrencyStamp",
                value: "198cfc30-257a-4aa0-8eac-c5d1af043762");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ad28833-513a-4101-a75d-21b871d22562"),
                column: "ConcurrencyStamp",
                value: "3592f499-460d-42cb-ad62-53a63a6b526c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ebf0ef6f-1d52-4197-96c0-0c48fbac76ad"),
                column: "ConcurrencyStamp",
                value: "ed6534c9-c79f-42a0-9ed9-6f8c7e22ccc2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c7bf599-963f-47f3-b488-0218ea50fbec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cf4c13c-374a-4aea-b053-7498bca26276", "AQAAAAEAACcQAAAAEFo0HciAHf406BOKm1j4fbmctcteHrKWhsYiDNoIm91BlfekD1PHZFRW0EqpbkG7rA==", "6d7e2943-8b40-40ff-97d3-b5a4101ff88e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("71829b03-40ee-42d5-a62e-2827d34a02fa"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7b738077-508a-4841-b50a-8059e416bcd0", "a4d264c5-72fd-4d37-aea6-d487c46ff495" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 19, 0, 42, 831, DateTimeKind.Local).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 19, 0, 42, 831, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 19, 0, 42, 831, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 19, 0, 42, 831, DateTimeKind.Local).AddTicks(8780));

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
