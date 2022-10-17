using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Yee.Page.Models;

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
                name: "YeeComponentValues",
                schema: "YeePage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComponentRef = table.Column<YeeCSharpLink>(type: "jsonb", nullable: true),
                    ProperyValues = table.Column<List<YeePropertyValue>>(type: "jsonb", nullable: true),
                    IsHeader = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeeComponentValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YeePages",
                schema: "YeePage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    RouterLink = table.Column<YeeCSharpLink>(type: "jsonb", nullable: true),
                    BodyId = table.Column<string>(type: "text", nullable: true),
                    BodyClass = table.Column<string>(type: "text", nullable: true),
                    StyleLink = table.Column<YeeCSharpLink>(type: "jsonb", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YeeComponentValuesYeePage",
                schema: "YeePage",
                columns: table => new
                {
                    PagesId = table.Column<long>(type: "bigint", nullable: false),
                    YeeComponentsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeeComponentValuesYeePage", x => new { x.PagesId, x.YeeComponentsId });
                    table.ForeignKey(
                        name: "FK_YeeComponentValuesYeePage_YeeComponentValues_YeeComponentsId",
                        column: x => x.YeeComponentsId,
                        principalSchema: "YeePage",
                        principalTable: "YeeComponentValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YeeComponentValuesYeePage_YeePages_PagesId",
                        column: x => x.PagesId,
                        principalSchema: "YeePage",
                        principalTable: "YeePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YeeComponentValues_Id",
                schema: "YeePage",
                table: "YeeComponentValues",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YeeComponentValuesYeePage_YeeComponentsId",
                schema: "YeePage",
                table: "YeeComponentValuesYeePage",
                column: "YeeComponentsId");

            migrationBuilder.CreateIndex(
                name: "IX_YeePages_Id",
                schema: "YeePage",
                table: "YeePages",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YeeComponentValuesYeePage",
                schema: "YeePage");

            migrationBuilder.DropTable(
                name: "YeeComponentValues",
                schema: "YeePage");

            migrationBuilder.DropTable(
                name: "YeePages",
                schema: "YeePage");
        }
    }
}
