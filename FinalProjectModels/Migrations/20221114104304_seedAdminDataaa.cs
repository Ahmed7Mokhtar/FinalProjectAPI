using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectModels.Migrations
{
    public partial class seedAdminDataaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ca51c3e-25d3-4c68-aa9a-705dc1484108",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c33fe29-49d2-4145-867d-d542a00ade74", "AQAAAAEAACcQAAAAECuedMsDUKKa7lPW4CNgWgZg400c7QzZzfR7y9i00aOUfYC2aiij7BKR3xBCEJta4g==", "81901762-4671-44dd-a4b1-ef9b56fc5c7c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ca51c3e-25d3-4c68-aa9a-705dc1484108",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02d9aa96-5c92-4ec2-b614-16898d8bfb9a", "AQAAAAEAACcQAAAAEBMslf+VqWk8kb0XMoXbQJNFJTvwI7HIJrtSCDyw5x1J5QjIhKgyLr8iraL7p19Low==", "db607f9c-b3c8-4164-bcbc-0b5ec5d9bda2" });
        }
    }
}
