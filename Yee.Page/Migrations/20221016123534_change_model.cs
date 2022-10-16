using Microsoft.EntityFrameworkCore.Migrations;
using Yee.Page.Models;

#nullable disable

namespace Yee.Page.Migrations
{
    public partial class change_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "YeePage",
                table: "YeeSectionValues",
                newName: "Values");

            migrationBuilder.RenameColumn(
                name: "HeaderLink",
                schema: "YeePage",
                table: "YeePages",
                newName: "HeaderValues");

            migrationBuilder.AddColumn<YeeCSharpLink>(
                name: "HeaderSectionLink",
                schema: "YeePage",
                table: "YeePages",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeaderSectionLink",
                schema: "YeePage",
                table: "YeePages");

            migrationBuilder.RenameColumn(
                name: "Values",
                schema: "YeePage",
                table: "YeeSectionValues",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "HeaderValues",
                schema: "YeePage",
                table: "YeePages",
                newName: "HeaderLink");
        }
    }
}
