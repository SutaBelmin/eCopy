using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCopy.Services.Migrations
{
    public partial class isPaid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPayed",
                table: "Requests",
                newName: "IsPaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "Requests",
                newName: "IsPayed");
        }
    }
}
