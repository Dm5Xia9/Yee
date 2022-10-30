using System;
using Microsoft.EntityFrameworkCore.Migrations;
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ComponentRef = table.Column<YeeCSharpLink>(type: "jsonb", nullable: true),
                    IsHeader = table.Column<bool>(type: "boolean", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsFlexable = table.Column<bool>(type: "boolean", nullable: false),
                    FlexOptions = table.Column<FlexOptions>(type: "jsonb", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeeComponentValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YeeComponentValues_YeeComponentValues_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "YeePage",
                        principalTable: "YeeComponentValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "YeePages",
                schema: "YeePage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "YeePropertyValues",
                schema: "YeePage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyType = table.Column<YeeCSharpLink>(type: "jsonb", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    IsModelData = table.Column<bool>(type: "boolean", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeePropertyValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YeeComponentValuesYeePage",
                schema: "YeePage",
                columns: table => new
                {
                    PagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    YeeComponentsId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "YeeProperties",
                schema: "YeePage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Property = table.Column<string>(type: "text", nullable: true),
                    YeePropertyValueId = table.Column<Guid>(type: "uuid", nullable: true),
                    YeeComponentValuesId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeeProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YeeProperties_YeeComponentValues_YeeComponentValuesId",
                        column: x => x.YeeComponentValuesId,
                        principalSchema: "YeePage",
                        principalTable: "YeeComponentValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_YeeProperties_YeePropertyValues_YeePropertyValueId",
                        column: x => x.YeePropertyValueId,
                        principalSchema: "YeePage",
                        principalTable: "YeePropertyValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_YeeComponentValues_Id",
                schema: "YeePage",
                table: "YeeComponentValues",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YeeComponentValues_ParentId",
                schema: "YeePage",
                table: "YeeComponentValues",
                column: "ParentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_YeeProperties_Id",
                schema: "YeePage",
                table: "YeeProperties",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YeeProperties_YeeComponentValuesId",
                schema: "YeePage",
                table: "YeeProperties",
                column: "YeeComponentValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_YeeProperties_YeePropertyValueId",
                schema: "YeePage",
                table: "YeeProperties",
                column: "YeePropertyValueId");

            migrationBuilder.CreateIndex(
                name: "IX_YeePropertyValues_Id",
                schema: "YeePage",
                table: "YeePropertyValues",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YeeComponentValuesYeePage",
                schema: "YeePage");

            migrationBuilder.DropTable(
                name: "YeeProperties",
                schema: "YeePage");

            migrationBuilder.DropTable(
                name: "YeePages",
                schema: "YeePage");

            migrationBuilder.DropTable(
                name: "YeeComponentValues",
                schema: "YeePage");

            migrationBuilder.DropTable(
                name: "YeePropertyValues",
                schema: "YeePage");
        }
    }
}
