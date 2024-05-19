using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class IsApprovedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is book approved by admin");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Books");

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
        }
    }
}
