using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class fixedSecurityStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bff69dcd-47cd-452a-8536-4823df1b2e70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fce46d0e-10df-48f8-a4eb-3b806c8e8c79", "AQAAAAEAACcQAAAAEMuNUr/x6GmmyREe2NDXXwHvU+UjZE/aM6QJOijza7hvDbYV/0/CqXcxS1/WeFh/Lw==", "2e3112b8-6559-4e6f-a6ce-ee9595405798" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal1232-c23-dsds334-sdsk23-b2343431fefe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44daf76f-d7ee-43be-bc0b-4caa38c5a516", "AQAAAAEAACcQAAAAEHigSpCej+lgWNxqVIB2+VvzHZ95cjNp6sZnm98mqebNkF0ftVwSKJ2xME9qcmLV+Q==", "2898835f-2cd7-4981-9394-5370ced1da30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0bdf9ce4-7835-4f56-b533-64dd2f245e03", "AQAAAAEAACcQAAAAEP5uW0n2gj7VcN897kGljMFKHPsiJ8ADBQS4ufCtwr8wl/QX/u8QZ0J2EHCIpkZsPQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bff69dcd-47cd-452a-8536-4823df1b2e70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a4e8f04-7f50-4928-99f3-7ed52dc61945", "AQAAAAEAACcQAAAAEE4OW5Yl0Vq9zp9Jynby7nJgt19P/pvuGLLaIj1QELTxkXu80GIQm+ZEwi7s+lst8g==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal1232-c23-dsds334-sdsk23-b2343431fefe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cba48b5a-8cc1-4917-b40a-1fe09163cc96", "AQAAAAEAACcQAAAAEL2QyFOIfazQ+oY/Z0vk+tkxthRKe+yw40UIlK+jcXbvw/VHu9QIhlQQifUndjj3Pw==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0acd2869-963a-4e05-8808-3a64d534a3ef", "AQAAAAEAACcQAAAAEINd3raSWrg0Dfm7tDyu8XLSN3nKJy/LpLR5O740FnLCI40MxIF8aJOE3t11I0+gzQ==" });
        }
    }
}
