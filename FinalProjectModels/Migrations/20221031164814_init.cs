using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectModels.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "الحسابات",
                columns: table => new
                {
                    رقم_الحساب = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    اسم_الحساب = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    مدين = table.Column<double>(type: "float", nullable: false),
                    دائن = table.Column<double>(type: "float", nullable: false),
                    طبيعه_الحساب = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    التصنيف = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    كود_الحساب = table.Column<int>(type: "int", nullable: false),
                    العنوان = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    التليفون = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_الحسابات", x => x.رقم_الحساب);
                });

            migrationBuilder.CreateTable(
                name: "الخزنه",
                columns: table => new
                {
                    رقم_المسلسل = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    الحركه = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    التاريخ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    وارد = table.Column<double>(type: "float", nullable: false),
                    منصرف = table.Column<double>(type: "float", nullable: false),
                    رصيد = table.Column<double>(type: "float", nullable: false),
                    الحساب = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_الخزنه", x => x.رقم_المسلسل);
                });

            migrationBuilder.CreateTable(
                name: "الفواتير",
                columns: table => new
                {
                    رقم_الفاتوره = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    التاريخ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    الحساب = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    طريقه_الحساب = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    الكميه = table.Column<int>(type: "int", nullable: false),
                    الخصم = table.Column<double>(type: "float", nullable: false),
                    النهائي = table.Column<double>(type: "float", nullable: false),
                    درج_النقديه = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_الفواتير", x => x.رقم_الفاتوره);
                });

            migrationBuilder.CreateTable(
                name: "بيع",
                columns: table => new
                {
                    رقم_الصنف = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    اسم_الصنف = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    وحده = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    الكميه = table.Column<int>(type: "int", nullable: false),
                    السعر = table.Column<double>(type: "float", nullable: false),
                    الاجمالي = table.Column<double>(type: "float", nullable: false),
                    النهائي = table.Column<double>(type: "float", nullable: false)
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
                    اسم_الصنف = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    وحده = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    الكميه = table.Column<int>(type: "int", nullable: false),
                    السعر = table.Column<double>(type: "float", nullable: false),
                    الاجمالي = table.Column<double>(type: "float", nullable: false),
                    ألنهائي = table.Column<double>(type: "float", nullable: false)
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
                    اسم_الصنف = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    وحده = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    الكميه = table.Column<int>(type: "int", nullable: false),
                    السعر = table.Column<double>(type: "float", nullable: false),
                    الاجمالي = table.Column<double>(type: "float", nullable: false),
                    ألنهائي = table.Column<double>(type: "float", nullable: false)
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
                    وحده = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    الكميه = table.Column<int>(type: "int", nullable: false),
                    السعر = table.Column<double>(type: "float", nullable: false),
                    الاجمالي = table.Column<double>(type: "float", nullable: false),
                    النهائي = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_مرتجع_شراء", x => x.رقم_الصنف);
                });

            migrationBuilder.CreateTable(
                name: "البضاعه",
                columns: table => new
                {
                    رقم_الصنف = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    اسم_الصنف = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    سعر_البيع = table.Column<double>(type: "float", nullable: false),
                    اجمالي_الكميه = table.Column<int>(type: "int", nullable: false),
                    سعر_الشراء = table.Column<double>(type: "float", nullable: false),
                    الوصف = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    الفواتيررقم_الفاتوره = table.Column<int>(type: "int", nullable: false),
                    شراءرقم_الصنف = table.Column<int>(type: "int", nullable: false),
                    بيعرقم_الصنف = table.Column<int>(type: "int", nullable: false),
                    مرتجع_بيعرقم_الصنف = table.Column<int>(type: "int", nullable: false),
                    مرتجع_شراءرقم_الصنف = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_البضاعه", x => x.رقم_الصنف);
                    table.ForeignKey(
                        name: "FK_البضاعه_الفواتير_الفواتيررقم_الفاتوره",
                        column: x => x.الفواتيررقم_الفاتوره,
                        principalTable: "الفواتير",
                        principalColumn: "رقم_الفاتوره",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_البضاعه_بيع_بيعرقم_الصنف",
                        column: x => x.بيعرقم_الصنف,
                        principalTable: "بيع",
                        principalColumn: "رقم_الصنف",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_البضاعه_شراء_شراءرقم_الصنف",
                        column: x => x.شراءرقم_الصنف,
                        principalTable: "شراء",
                        principalColumn: "رقم_الصنف",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_البضاعه_مرتجع_بيع_مرتجع_بيعرقم_الصنف",
                        column: x => x.مرتجع_بيعرقم_الصنف,
                        principalTable: "مرتجع_بيع",
                        principalColumn: "رقم_الصنف",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_البضاعه_مرتجع_شراء_مرتجع_شراءرقم_الصنف",
                        column: x => x.مرتجع_شراءرقم_الصنف,
                        principalTable: "مرتجع_شراء",
                        principalColumn: "رقم_الصنف",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_البضاعه_الفواتيررقم_الفاتوره",
                table: "البضاعه",
                column: "الفواتيررقم_الفاتوره");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "البضاعه");

            migrationBuilder.DropTable(
                name: "الحسابات");

            migrationBuilder.DropTable(
                name: "الخزنه");

            migrationBuilder.DropTable(
                name: "الفواتير");

            migrationBuilder.DropTable(
                name: "بيع");

            migrationBuilder.DropTable(
                name: "شراء");

            migrationBuilder.DropTable(
                name: "مرتجع_بيع");

            migrationBuilder.DropTable(
                name: "مرتجع_شراء");
        }
    }
}
