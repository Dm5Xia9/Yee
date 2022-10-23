using Microsoft.EntityFrameworkCore.Migrations;
using Yee.Page.Models;

#nullable disable

namespace Yee.Page.Migrations
{
    public partial class flex_component : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<FlexOptions>(
                name: "FlexOptions",
                schema: "YeePage",
                table: "YeeComponentValues",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFlexable",
                schema: "YeePage",
                table: "YeeComponentValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlexOptions",
                schema: "YeePage",
                table: "YeeComponentValues");

            migrationBuilder.DropColumn(
                name: "IsFlexable",
                schema: "YeePage",
                table: "YeeComponentValues");
        }
    }
}
