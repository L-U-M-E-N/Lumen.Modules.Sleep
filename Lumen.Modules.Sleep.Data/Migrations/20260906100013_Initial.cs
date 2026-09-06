using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lumen.Modules.Sleep.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sleep");

            migrationBuilder.CreateTable(
                name: "Sleep",
                schema: "Sleep",
                columns: table => new
                {
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sleep", x => new { x.Start, x.End });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sleep_Start",
                schema: "Sleep",
                table: "Sleep",
                column: "Start",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sleep",
                schema: "Sleep");
        }
    }
}
