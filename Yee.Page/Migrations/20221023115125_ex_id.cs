using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yee.Page.Migrations
{
    public partial class ex_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExId",
                schema: "YeePage",
                table: "YeeComponentValues",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExId",
                schema: "YeePage",
                table: "YeeComponentValues");
        }
    }
}
