using Microsoft.EntityFrameworkCore.Migrations;

namespace Theraphosidae.Migrations
{
    public partial class HumdityTemperature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spiders_AnimalTaxonomies_AnimalTaxonomyId",
                table: "Spiders");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "Spiders");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Spiders");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalTaxonomyId",
                table: "Spiders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HumidityMax",
                table: "Spiders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HumidityMin",
                table: "Spiders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TemperatureMax",
                table: "Spiders",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TemperatureMin",
                table: "Spiders",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_Spiders_AnimalTaxonomies_AnimalTaxonomyId",
                table: "Spiders",
                column: "AnimalTaxonomyId",
                principalTable: "AnimalTaxonomies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spiders_AnimalTaxonomies_AnimalTaxonomyId",
                table: "Spiders");

            migrationBuilder.DropColumn(
                name: "HumidityMax",
                table: "Spiders");

            migrationBuilder.DropColumn(
                name: "HumidityMin",
                table: "Spiders");

            migrationBuilder.DropColumn(
                name: "TemperatureMax",
                table: "Spiders");

            migrationBuilder.DropColumn(
                name: "TemperatureMin",
                table: "Spiders");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalTaxonomyId",
                table: "Spiders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Humidity",
                table: "Spiders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Temperature",
                table: "Spiders",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_Spiders_AnimalTaxonomies_AnimalTaxonomyId",
                table: "Spiders",
                column: "AnimalTaxonomyId",
                principalTable: "AnimalTaxonomies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
