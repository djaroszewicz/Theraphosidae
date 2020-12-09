using Microsoft.EntityFrameworkCore.Migrations;

namespace Theraphosidae.Migrations
{
    public partial class Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Spiders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Spiders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Spiders");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Spiders");
        }
    }
}
