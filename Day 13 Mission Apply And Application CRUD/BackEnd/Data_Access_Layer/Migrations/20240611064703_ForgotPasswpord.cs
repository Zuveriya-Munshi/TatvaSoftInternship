using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class ForgotPasswpord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalSheets",
                table: "Missions",
                newName: "TotalSeats");

            migrationBuilder.RenameColumn(
                name: "Sheet",
                table: "MissionApplication",
                newName: "Seats");

            migrationBuilder.CreateTable(
                name: "ForgotPasswords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RequestDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgotPasswords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForgotPasswords");

            migrationBuilder.RenameColumn(
                name: "TotalSeats",
                table: "Missions",
                newName: "TotalSheets");

            migrationBuilder.RenameColumn(
                name: "Seats",
                table: "MissionApplication",
                newName: "Sheet");
        }
    }
}
