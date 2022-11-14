using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectModels.Migrations
{
    public partial class inittt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_البضاعه_الفواتير_الفواتيررقم_الفاتوره",
                table: "البضاعه");

            migrationBuilder.DropIndex(
                name: "IX_البضاعه_الفواتيررقم_الفاتوره",
                table: "البضاعه");

            migrationBuilder.DropColumn(
                name: "الفواتيررقم_الفاتوره",
                table: "البضاعه");

            migrationBuilder.CreateTable(
                name: "البضاعهالفواتير",
                columns: table => new
                {
                    البضاعهرقم_الصنف = table.Column<int>(type: "int", nullable: false),
                    الفواتيررقم_الفاتوره = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_البضاعهالفواتير", x => new { x.البضاعهرقم_الصنف, x.الفواتيررقم_الفاتوره });
                    table.ForeignKey(
                        name: "FK_البضاعهالفواتير_البضاعه_البضاعهرقم_الصنف",
                        column: x => x.البضاعهرقم_الصنف,
                        principalTable: "البضاعه",
                        principalColumn: "رقم_الصنف",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_البضاعهالفواتير_الفواتير_الفواتيررقم_الفاتوره",
                        column: x => x.الفواتيررقم_الفاتوره,
                        principalTable: "الفواتير",
                        principalColumn: "رقم_الفاتوره",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_البضاعهالفواتير_الفواتيررقم_الفاتوره",
                table: "البضاعهالفواتير",
                column: "الفواتيررقم_الفاتوره");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "البضاعهالفواتير");

            migrationBuilder.AddColumn<int>(
                name: "الفواتيررقم_الفاتوره",
                table: "البضاعه",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_البضاعه_الفواتيررقم_الفاتوره",
                table: "البضاعه",
                column: "الفواتيررقم_الفاتوره");

            migrationBuilder.AddForeignKey(
                name: "FK_البضاعه_الفواتير_الفواتيررقم_الفاتوره",
                table: "البضاعه",
                column: "الفواتيررقم_الفاتوره",
                principalTable: "الفواتير",
                principalColumn: "رقم_الفاتوره",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
