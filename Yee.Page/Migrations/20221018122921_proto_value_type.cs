using Microsoft.EntityFrameworkCore.Migrations;
using Yee.Page.Models;

#nullable disable

namespace Yee.Page.Migrations
{
    public partial class proto_value_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<YeeCSharpLink>(
                name: "PropertyType",
                schema: "YeePage",
                table: "YeePropertyValues",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyType",
                schema: "YeePage",
                table: "YeePropertyValues");
        }
    }
}
