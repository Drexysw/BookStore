using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class SeededOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Authobriography",
                table: "Authors",
                type: "nvarchar(330)",
                maxLength: 330,
                nullable: false,
                comment: "Author's authobriography",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldComment: "Author's authobriography");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1dc5ddf2-25da-4a80-ad75-4673cefdac85", "AQAAAAEAACcQAAAAEDPHOiuog6yxgzQpYc7ByzhN3m5TPmnDOjg510HCm9WGLKmT5X0xBr6cfACMXoSXiA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d966b0a-bc67-41e8-8b8b-7a28af5093de", "AQAAAAEAACcQAAAAEEoLfGxP/7EiZSZfhOJSwadLnPY/llH7lhSpaHolZTf+2ThaSU3ffI+zYkSfNoQESQ==" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "BookId", "BuyerId" },
                values: new object[,]
                {
                    { 1, "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224" },
                    { 2, "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224" },
                    { 3, "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumns: new[] { "BookId", "BuyerId" },
                keyValues: new object[] { 1, "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224" });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumns: new[] { "BookId", "BuyerId" },
                keyValues: new object[] { 2, "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224" });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumns: new[] { "BookId", "BuyerId" },
                keyValues: new object[] { 3, "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224" });

            migrationBuilder.AlterColumn<string>(
                name: "Authobriography",
                table: "Authors",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "Author's authobriography",
                oldClrType: typeof(string),
                oldType: "nvarchar(330)",
                oldMaxLength: 330,
                oldComment: "Author's authobriography");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bff69dcd-47cd-452a-8536-4823df1b2e70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "833e027d-0a32-4af1-9264-7aec806607ea", "AQAAAAEAACcQAAAAELO8Ozc2QuMgXEHsjHZ2iV0UDyg68v508p6FfPu10H/j28A574lmh8qQ6Jh/GgNivA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal1232-c23-dsds334-sdsk23-b2343431fefe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21b009fb-feac-437b-92bc-b7e3e2dd76c1", "AQAAAAEAACcQAAAAEL6csZvkIpcMS++H07XUSBax0lAFVut+HMJWGYJo0HJHWT71njzjSHBySGaOA2kFGA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "100d6ee4-fd62-414d-85b4-5f6cf28b4fd5", "AQAAAAEAACcQAAAAENBaNiuQ/eAfI46TzVZJsWLoa6IzEgjDVg0AsiT7XlV0pd2VT/dIzzIKWSzqexP4pw==" });
        }
    }
}
