using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yee.DynamicRouters.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DynamicRouter");

            migrationBuilder.CreateTable(
                name: "YeeRoutes",
                schema: "DynamicRouter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocalPath = table.Column<string>(type: "text", nullable: false),
                    StaticContent = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeeRoutes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YeeRoutes_Id",
                schema: "DynamicRouter",
                table: "YeeRoutes",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YeeRoutes",
                schema: "DynamicRouter");
        }
    }
}
