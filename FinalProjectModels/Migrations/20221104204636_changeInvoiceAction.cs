using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectModels.Migrations
{
    public partial class changeInvoiceAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_الحركة_الفواتير_فاتورةرقم_الفاتوره",
                table: "الحركة");

            migrationBuilder.DropIndex(
                name: "IX_الحركة_فاتورةرقم_الفاتوره",
                table: "الحركة");

            migrationBuilder.DropColumn(
                name: "فاتورةرقم_الفاتوره",
                table: "الحركة");

            migrationBuilder.AddColumn<int>(
                name: "رقم_الحركة",
                table: "الفواتير",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "طبيعه_الحساب",
                table: "الحسابات",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "العنوان",
                table: "الحسابات",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "التليفون",
                table: "الحسابات",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "التصنيف",
                table: "الحسابات",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "اسم_الحساب",
                table: "الحسابات",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_الفواتير_رقم_الحركة",
                table: "الفواتير",
                column: "رقم_الحركة");

            migrationBuilder.AddForeignKey(
                name: "FK_الفواتير_الحركة_رقم_الحركة",
                table: "الفواتير",
                column: "رقم_الحركة",
                principalTable: "الحركة",
                principalColumn: "رقم_الحركة",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_الفواتير_الحركة_رقم_الحركة",
                table: "الفواتير");

            migrationBuilder.DropIndex(
                name: "IX_الفواتير_رقم_الحركة",
                table: "الفواتير");

            migrationBuilder.DropColumn(
                name: "رقم_الحركة",
                table: "الفواتير");

            migrationBuilder.AlterColumn<string>(
                name: "طبيعه_الحساب",
                table: "الحسابات",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "العنوان",
                table: "الحسابات",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "التليفون",
                table: "الحسابات",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "التصنيف",
                table: "الحسابات",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "اسم_الحساب",
                table: "الحسابات",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "فاتورةرقم_الفاتوره",
                table: "الحركة",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_الحركة_فاتورةرقم_الفاتوره",
                table: "الحركة",
                column: "فاتورةرقم_الفاتوره");

            migrationBuilder.AddForeignKey(
                name: "FK_الحركة_الفواتير_فاتورةرقم_الفاتوره",
                table: "الحركة",
                column: "فاتورةرقم_الفاتوره",
                principalTable: "الفواتير",
                principalColumn: "رقم_الفاتوره");
        }
    }
}
