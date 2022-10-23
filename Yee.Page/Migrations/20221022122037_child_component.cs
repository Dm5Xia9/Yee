using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yee.Page.Migrations
{
    public partial class child_component : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                schema: "YeePage",
                table: "YeeComponentValues",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_YeeComponentValues_ParentId",
                schema: "YeePage",
                table: "YeeComponentValues",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_YeeComponentValues_YeeComponentValues_ParentId",
                schema: "YeePage",
                table: "YeeComponentValues",
                column: "ParentId",
                principalSchema: "YeePage",
                principalTable: "YeeComponentValues",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YeeComponentValues_YeeComponentValues_ParentId",
                schema: "YeePage",
                table: "YeeComponentValues");

            migrationBuilder.DropIndex(
                name: "IX_YeeComponentValues_ParentId",
                schema: "YeePage",
                table: "YeeComponentValues");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "YeePage",
                table: "YeeComponentValues");
        }
    }
}
