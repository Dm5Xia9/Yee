using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Yee.Page.Models;

#nullable disable

namespace Yee.Page.Migrations
{
    public partial class not_nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<JsonDocument>(
                name: "Value",
                schema: "YeePage",
                table: "YeeSectionValues",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<YeeCSharpLink>(
                name: "SectionLink",
                schema: "YeePage",
                table: "YeeSectionValues",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(YeeCSharpLink),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<YeeCSharpLink>(
                name: "StyleLink",
                schema: "YeePage",
                table: "YeePages",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(YeeCSharpLink),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<YeeCSharpLink>(
                name: "RouterLink",
                schema: "YeePage",
                table: "YeePages",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(YeeCSharpLink),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<YeeCSharpLink>(
                name: "HeaderLink",
                schema: "YeePage",
                table: "YeePages",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(YeeCSharpLink),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                schema: "YeePage",
                table: "YeePages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "BodyId",
                schema: "YeePage",
                table: "YeePages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "BodyClass",
                schema: "YeePage",
                table: "YeePages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<JsonDocument>(
                name: "Value",
                schema: "YeePage",
                table: "YeeSectionValues",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<YeeCSharpLink>(
                name: "SectionLink",
                schema: "YeePage",
                table: "YeeSectionValues",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(YeeCSharpLink),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<YeeCSharpLink>(
                name: "StyleLink",
                schema: "YeePage",
                table: "YeePages",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(YeeCSharpLink),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<YeeCSharpLink>(
                name: "RouterLink",
                schema: "YeePage",
                table: "YeePages",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(YeeCSharpLink),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<YeeCSharpLink>(
                name: "HeaderLink",
                schema: "YeePage",
                table: "YeePages",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(YeeCSharpLink),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                schema: "YeePage",
                table: "YeePages",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BodyId",
                schema: "YeePage",
                table: "YeePages",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BodyClass",
                schema: "YeePage",
                table: "YeePages",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
