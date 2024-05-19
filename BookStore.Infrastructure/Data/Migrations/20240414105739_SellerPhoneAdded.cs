using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class SellerPhoneAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bff69dcd-47cd-452a-8536-4823df1b2e70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "48980cd3-f834-4aee-8914-b1b3075f556e", "AQAAAAEAACcQAAAAEEVBKaCq1GDZO7a0RVHJHesMsQaj3oTZdzY98bXe9SBkVWtcF9ed80y1TJAqZidDoQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal1232-c23-dsds334-sdsk23-b2343431fefe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0ebabf6c-c8e4-40f5-ad7a-85f08636f51c", "AQAAAAEAACcQAAAAELCY3aMePN7PAa5hwZbCRaCmehg5HRKTqHgu6B4eltCob1B9jDu4dMXuuzgthOOopg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "02a36c72-76f1-4da8-bf01-7317500453dd", "AQAAAAEAACcQAAAAEML2EEDLZ/3CNoXjY4QsjJuctaVcN62qWvYEG0lMJKfnwR6C4ZcngvwGbB9qndaABg==" });

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "+4563478905");

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhoneNumber",
                value: "+0875423556");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Sellers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bff69dcd-47cd-452a-8536-4823df1b2e70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fce46d0e-10df-48f8-a4eb-3b806c8e8c79", "AQAAAAEAACcQAAAAEMuNUr/x6GmmyREe2NDXXwHvU+UjZE/aM6QJOijza7hvDbYV/0/CqXcxS1/WeFh/Lw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal1232-c23-dsds334-sdsk23-b2343431fefe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44daf76f-d7ee-43be-bc0b-4caa38c5a516", "AQAAAAEAACcQAAAAEHigSpCej+lgWNxqVIB2+VvzHZ95cjNp6sZnm98mqebNkF0ftVwSKJ2xME9qcmLV+Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0bdf9ce4-7835-4f56-b533-64dd2f245e03", "AQAAAAEAACcQAAAAEP5uW0n2gj7VcN897kGljMFKHPsiJ8ADBQS4ufCtwr8wl/QX/u8QZ0J2EHCIpkZsPQ==" });
        }
    }
}
