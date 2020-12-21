using Microsoft.EntityFrameworkCore.Migrations;

namespace Theraphosidae.Migrations
{
    public partial class ArticleModelAddLiterautreAbstract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abstract",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Literature",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abstract",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Literature",
                table: "Articles");
        }
    }
}
