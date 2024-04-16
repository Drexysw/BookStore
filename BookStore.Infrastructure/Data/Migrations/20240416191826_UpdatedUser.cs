using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class UpdatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sellers_UserId",
                table: "Sellers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bff69dcd-47cd-452a-8536-4823df1b2e70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "99b7ab8b-456f-49b8-bc28-1f0874b2c2a1", "AQAAAAEAACcQAAAAEH9S1tE45BqP9mFXJ3G6qQ29qAZhLvYxaOvz0QssZjbe/XPc6nUgP4QEOj/QeHuaEQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal1232-c23-dsds334-sdsk23-b2343431fefe",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "854bad60-c7ef-4604-8502-c30e7acf1c74", "David", "Davidov", "AQAAAAEAACcQAAAAEET464d6HMcK41aMTHudhU/xi37oWlB5YuiTxHcu+RN3Fby9sEnLUX5Gd714EpeBqw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "7ff3c693-825b-4b9c-a3ed-8d8ae5ced34b", "David", "Davidov", "AQAAAAEAACcQAAAAEOulM9SupstdMWkPt6/7PET2Mrza/md0GIbDsQcvUbNKUdoXfWSQlC0iHULL47lXBw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_UserId",
                table: "Sellers",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sellers_UserId",
                table: "Sellers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bff69dcd-47cd-452a-8536-4823df1b2e70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "30c78296-4c6a-4f1e-b1a6-5ee46a776bae", "AQAAAAEAACcQAAAAEH5mx94S8Js/3jq/pCt4TYh88vWfOOqz/fibseLURW8YMx0tI5pwyUI05NqNTFniZQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal1232-c23-dsds334-sdsk23-b2343431fefe",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "1dc5ddf2-25da-4a80-ad75-4673cefdac85", null, null, "AQAAAAEAACcQAAAAEDPHOiuog6yxgzQpYc7ByzhN3m5TPmnDOjg510HCm9WGLKmT5X0xBr6cfACMXoSXiA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "6d966b0a-bc67-41e8-8b8b-7a28af5093de", null, null, "AQAAAAEAACcQAAAAEEoLfGxP/7EiZSZfhOJSwadLnPY/llH7lhSpaHolZTf+2ThaSU3ffI+zYkSfNoQESQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_UserId",
                table: "Sellers",
                column: "UserId");
        }
    }
}
