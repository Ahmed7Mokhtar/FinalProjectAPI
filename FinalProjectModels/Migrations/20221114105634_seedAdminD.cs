using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectModels.Migrations
{
    public partial class seedAdminD : Migration
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
                values: new object[] { "9ca51c3e-25d3-4c68-aa9a-705dc1484108", 0, "eee15c60-8be1-41d8-9717-f305aa947a30", "ahmed@gmail.com", false, "Ahmed", "Mokhtar", false, null, "AHMED@GMAIL.COM", "AHMED@GMAIL.COM", "AQAAAAEAACcQAAAAEDDhX04dEQ3nXE33JLvsz/zZYtCDfvNvjUzZ3N9QEfDp93XPw8zuTxqPSlRIJyNKzQ==", "01065086511", false, "6eff21e9-8d7f-4603-81de-cefece27d0fd", false, "ahmed@gmail.com" });

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
