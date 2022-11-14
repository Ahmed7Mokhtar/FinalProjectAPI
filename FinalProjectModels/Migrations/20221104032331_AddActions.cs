using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectModels.Migrations
{
    public partial class AddActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_البضاعه_بيع_بيعرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.DropForeignKey(
                name: "FK_البضاعه_شراء_شراءرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.DropForeignKey(
                name: "FK_البضاعه_مرتجع_بيع_مرتجع_بيعرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.DropForeignKey(
                name: "FK_البضاعه_مرتجع_شراء_مرتجع_شراءرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.DropTable(
                name: "بيع");

            migrationBuilder.DropTable(
                name: "شراء");

            migrationBuilder.DropTable(
                name: "مرتجع_بيع");

            migrationBuilder.DropTable(
                name: "مرتجع_شراء");

            migrationBuilder.DropIndex(
                name: "IX_البضاعه_بيعرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.DropIndex(
                name: "IX_البضاعه_شراءرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.DropIndex(
                name: "IX_البضاعه_مرتجع_بيعرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.DropIndex(
                name: "IX_البضاعه_مرتجع_شراءرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.DropColumn(
                name: "بيعرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.DropColumn(
                name: "شراءرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.DropColumn(
                name: "مرتجع_بيعرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.DropColumn(
                name: "مرتجع_شراءرقم_الصنف",
                table: "البضاعه");

            migrationBuilder.CreateTable(
                name: "الحركة",
                columns: table => new
                {
                    رقم_الحركة = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    نوع_الحركة = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    تاريخ_الحركة = table.Column<DateTime>(type: "datetime2", nullable: false),
                    المبلغ = table.Column<double>(type: "float", nullable: false),
                    فاتورةرقم_الفاتوره = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_الحركة", x => x.رقم_الحركة);
                    table.ForeignKey(
                        name: "FK_الحركة_الفواتير_فاتورةرقم_الفاتوره",
                        column: x => x.فاتورةرقم_الفاتوره,
                        principalTable: "الفواتير",
                        principalColumn: "رقم_الفاتوره");
                });

            migrationBuilder.CreateIndex(
                name: "IX_الحركة_فاتورةرقم_الفاتوره",
                table: "الحركة",
                column: "فاتورةرقم_الفاتوره");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "الحركة");

            migrationBuilder.AddColumn<int>(
                name: "بيعرقم_الصنف",
                table: "البضاعه",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "شراءرقم_الصنف",
                table: "البضاعه",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "مرتجع_بيعرقم_الصنف",
                table: "البضاعه",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "مرتجع_شراءرقم_الصنف",
                table: "البضاعه",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "بيع",
                columns: table => new
                {
                    رقم_الصنف = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    اسم_الصنف = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    الاجمالي = table.Column<double>(type: "float", nullable: false),
                    السعر = table.Column<double>(type: "float", nullable: false),
                    الكميه = table.Column<int>(type: "int", nullable: false),
                    النهائي = table.Column<double>(type: "float", nullable: false),
                    وحده = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_بيع", x => x.رقم_الصنف);
                });

            migrationBuilder.CreateTable(
                name: "شراء",
                columns: table => new
                {
                    رقم_الصنف = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ألنهائي = table.Column<double>(type: "float", nullable: false),
                    اسم_الصنف = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    الاجمالي = table.Column<double>(type: "float", nullable: false),
                    السعر = table.Column<double>(type: "float", nullable: false),
                    الكميه = table.Column<int>(type: "int", nullable: false),
                    وحده = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_شراء", x => x.رقم_الصنف);
                });

            migrationBuilder.CreateTable(
                name: "مرتجع_بيع",
                columns: table => new
                {
                    رقم_الصنف = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ألنهائي = table.Column<double>(type: "float", nullable: false),
                    اسم_الصنف = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    الاجمالي = table.Column<double>(type: "float", nullable: false),
                    السعر = table.Column<double>(type: "float", nullable: false),
                    الكميه = table.Column<int>(type: "int", nullable: false),
                    وحده = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_مرتجع_بيع", x => x.رقم_الصنف);
                });

            migrationBuilder.CreateTable(
                name: "مرتجع_شراء",
                columns: table => new
                {
                    رقم_الصنف = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    اسم_الصنف = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    الاجمالي = table.Column<double>(type: "float", nullable: false),
                    السعر = table.Column<double>(type: "float", nullable: false),
                    الكميه = table.Column<int>(type: "int", nullable: false),
                    النهائي = table.Column<double>(type: "float", nullable: false),
                    وحده = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_مرتجع_شراء", x => x.رقم_الصنف);
                });

            migrationBuilder.CreateIndex(
                name: "IX_البضاعه_بيعرقم_الصنف",
                table: "البضاعه",
                column: "بيعرقم_الصنف");

            migrationBuilder.CreateIndex(
                name: "IX_البضاعه_شراءرقم_الصنف",
                table: "البضاعه",
                column: "شراءرقم_الصنف");

            migrationBuilder.CreateIndex(
                name: "IX_البضاعه_مرتجع_بيعرقم_الصنف",
                table: "البضاعه",
                column: "مرتجع_بيعرقم_الصنف");

            migrationBuilder.CreateIndex(
                name: "IX_البضاعه_مرتجع_شراءرقم_الصنف",
                table: "البضاعه",
                column: "مرتجع_شراءرقم_الصنف");

            migrationBuilder.AddForeignKey(
                name: "FK_البضاعه_بيع_بيعرقم_الصنف",
                table: "البضاعه",
                column: "بيعرقم_الصنف",
                principalTable: "بيع",
                principalColumn: "رقم_الصنف",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_البضاعه_شراء_شراءرقم_الصنف",
                table: "البضاعه",
                column: "شراءرقم_الصنف",
                principalTable: "شراء",
                principalColumn: "رقم_الصنف",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_البضاعه_مرتجع_بيع_مرتجع_بيعرقم_الصنف",
                table: "البضاعه",
                column: "مرتجع_بيعرقم_الصنف",
                principalTable: "مرتجع_بيع",
                principalColumn: "رقم_الصنف",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_البضاعه_مرتجع_شراء_مرتجع_شراءرقم_الصنف",
                table: "البضاعه",
                column: "مرتجع_شراءرقم_الصنف",
                principalTable: "مرتجع_شراء",
                principalColumn: "رقم_الصنف",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
