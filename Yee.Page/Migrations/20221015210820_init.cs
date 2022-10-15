using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Yee.Page.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "YeePage");

            migrationBuilder.CreateTable(
                name: "YeePages",
                schema: "YeePage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YeeSectionValues",
                schema: "YeePage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<JsonDocument>(type: "jsonb", nullable: false),
                    YeePageId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeeSectionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YeeSectionValues_YeePages_YeePageId",
                        column: x => x.YeePageId,
                        principalSchema: "YeePage",
                        principalTable: "YeePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YeePages_Id",
                schema: "YeePage",
                table: "YeePages",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YeeSectionValues_Id",
                schema: "YeePage",
                table: "YeeSectionValues",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YeeSectionValues_YeePageId",
                schema: "YeePage",
                table: "YeeSectionValues",
                column: "YeePageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YeeSectionValues",
                schema: "YeePage");

            migrationBuilder.DropTable(
                name: "YeePages",
                schema: "YeePage");
        }
    }
}
