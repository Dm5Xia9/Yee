using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yee.Page.Migrations
{
    public partial class route : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YeeRoutes",
                schema: "YeePage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocalPath = table.Column<string>(type: "text", nullable: true),
                    StaticContent = table.Column<string>(type: "text", nullable: true),
                    PageId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeeRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YeeRoutes_YeePages_PageId",
                        column: x => x.PageId,
                        principalSchema: "YeePage",
                        principalTable: "YeePages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_YeeRoutes_Id",
                schema: "YeePage",
                table: "YeeRoutes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YeeRoutes_PageId",
                schema: "YeePage",
                table: "YeeRoutes",
                column: "PageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YeeRoutes",
                schema: "YeePage");
        }
    }
}
