using Microsoft.EntityFrameworkCore.Migrations;

namespace Theraphosidae.Migrations
{
    public partial class SpiderExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Spiders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Spiders");
        }
    }
}
