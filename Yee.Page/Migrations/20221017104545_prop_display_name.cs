using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yee.Page.Migrations
{
    public partial class prop_display_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                schema: "YeePage",
                table: "YeePropertyValues",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                schema: "YeePage",
                table: "YeePropertyValues");
        }
    }
}
