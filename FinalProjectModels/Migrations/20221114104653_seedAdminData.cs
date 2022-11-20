using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectModels.Migrations
{
    public partial class seedAdminData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18725df9-46e2-4376-876c-63057dfc5f3c", "18725df9-46e2-4376-876c-63057dfc5f3c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9ca51c3e-25d3-4c68-aa9a-705dc1484108", 0, "1e167842-42ef-4e67-a58a-3dd0a75c0d42", "ahmed@gmail.com", false, "Ahmed", "Mokhtar", false, null, null, null, "AQAAAAEAACcQAAAAEEpd7gxh/ItKb+Tmz/4wwPhLtrsLKD0gH9YVzZMAHHB8DcAKkjn0A+SWi8R9kW+kkA==", "01065086511", false, "d4303008-2087-4f2d-ba7b-5e5967337ff5", false, "ahmed@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "18725df9-46e2-4376-876c-63057dfc5f3c", "9ca51c3e-25d3-4c68-aa9a-705dc1484108" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18725df9-46e2-4376-876c-63057dfc5f3c", "9ca51c3e-25d3-4c68-aa9a-705dc1484108" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18725df9-46e2-4376-876c-63057dfc5f3c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ca51c3e-25d3-4c68-aa9a-705dc1484108");
        }
    }
}
