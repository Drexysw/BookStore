using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bff69dcd-47cd-452a-8536-4823df1b2e70", 0, "4c62b67e-bb5f-4390-9f9c-2e76573084df", "admin@gmail.com", false, "Stamo", true, "Petkov", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", null, null, false, null, false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "Name", "Rating", "UserId" },
                values: new object[] { 2, "Stamo", 6.0, "bff69dcd-47cd-452a-8536-4823df1b2e70" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bff69dcd-47cd-452a-8536-4823df1b2e70");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal1232-c23-dsds334-sdsk23-b2343431fefe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21f83f62-5059-4d38-91bf-162c24a49c13", "AQAAAAEAACcQAAAAEB+SbZgTdsDbZOFQNlPKfqoHcsixsz5oK9qh4UQewcn6XXDlxyDGnE5f/mdtEL0ncQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64884041-e21f-4128-8e7a-16a78bf11b13", "AQAAAAEAACcQAAAAEP9Hs5/YNzwUHoggAGBlr/ECxhse7JdOdPMcKcWkHvrAQ02Zj53fN671PFU+6Rvikw==" });
        }
    }
}
