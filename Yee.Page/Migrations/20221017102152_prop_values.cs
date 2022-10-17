using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Yee.Page.Models;

#nullable disable

namespace Yee.Page.Migrations
{
    public partial class prop_values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProperyValues",
                schema: "YeePage",
                table: "YeeComponentValues");

            migrationBuilder.CreateTable(
                name: "YeePropertyValues",
                schema: "YeePage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "YeeProperties",
                schema: "YeePage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Property = table.Column<string>(type: "text", nullable: true),
                    YeePropertyValueId = table.Column<long>(type: "bigint", nullable: true),
                    YeeComponentValuesId = table.Column<long>(type: "bigint", nullable: true),
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
                name: "YeeProperties",
                schema: "YeePage");

            migrationBuilder.DropTable(
                name: "YeePropertyValues",
                schema: "YeePage");

            migrationBuilder.AddColumn<List<YeePropertyValue>>(
                name: "ProperyValues",
                schema: "YeePage",
                table: "YeeComponentValues",
                type: "jsonb",
                nullable: true);
        }
    }
}
