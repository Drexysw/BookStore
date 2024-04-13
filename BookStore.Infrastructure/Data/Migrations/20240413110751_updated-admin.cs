using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class updatedadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bff69dcd-47cd-452a-8536-4823df1b2e70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2a4e8f04-7f50-4928-99f3-7ed52dc61945", "AQAAAAEAACcQAAAAEE4OW5Yl0Vq9zp9Jynby7nJgt19P/pvuGLLaIj1QELTxkXu80GIQm+ZEwi7s+lst8g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal1232-c23-dsds334-sdsk23-b2343431fefe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cba48b5a-8cc1-4917-b40a-1fe09163cc96", "AQAAAAEAACcQAAAAEL2QyFOIfazQ+oY/Z0vk+tkxthRKe+yw40UIlK+jcXbvw/VHu9QIhlQQifUndjj3Pw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0acd2869-963a-4e05-8808-3a64d534a3ef", "AQAAAAEAACcQAAAAEINd3raSWrg0Dfm7tDyu8XLSN3nKJy/LpLR5O740FnLCI40MxIF8aJOE3t11I0+gzQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bff69dcd-47cd-452a-8536-4823df1b2e70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4c62b67e-bb5f-4390-9f9c-2e76573084df", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal1232-c23-dsds334-sdsk23-b2343431fefe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1bec7ee-c379-4811-92ec-bac39b032d75", "AQAAAAEAACcQAAAAEGIA0wMFKIke3HllGrBUE2UzcfpIbBYRzgjloHe+rKE3BMPXyAhhAbvGKVI2YfcIgQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aad1445f-299d-4676-b756-506ab8c39083", "AQAAAAEAACcQAAAAEPTY6zIgMMzgqSZrqJHoWHaN3+CcQd5nW1akUZ+S3piCVDVVKHnILgQkQTLmXVBEEg==" });
        }
    }
}
