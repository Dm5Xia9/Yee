using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yee.Page.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "YeePage",
                table: "YeeComponentValues",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                schema: "YeePage",
                table: "YeeComponentValues");
        }
    }
}
