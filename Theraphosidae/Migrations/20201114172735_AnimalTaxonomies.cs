using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Theraphosidae.Migrations
{
    public partial class AnimalTaxonomies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalTaxonomies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Regnum = table.Column<string>(nullable: true),
                    Subregnum = table.Column<string>(nullable: true),
                    Superphylum = table.Column<string>(nullable: true),
                    Phylum = table.Column<string>(nullable: true),
                    Subphylum = table.Column<string>(nullable: true),
                    Infraphylum = table.Column<string>(nullable: true),
                    Superclassis = table.Column<string>(nullable: true),
                    Classis = table.Column<string>(nullable: true),
                    Subclassis = table.Column<string>(nullable: true),
                    Infraclassis = table.Column<string>(nullable: true),
                    Superordo = table.Column<string>(nullable: true),
                    Ordo = table.Column<string>(nullable: true),
                    Subordo = table.Column<string>(nullable: true),
                    Infraordo = table.Column<string>(nullable: true),
                    Superfamilia = table.Column<string>(nullable: true),
                    Familia = table.Column<string>(nullable: true),
                    Subfamilia = table.Column<string>(nullable: true),
                    Infrafamilia = table.Column<string>(nullable: true),
                    Supertrubus = table.Column<string>(nullable: true),
                    Tribus = table.Column<string>(nullable: true),
                    Subtribus = table.Column<string>(nullable: true),
                    Infratribus = table.Column<string>(nullable: true),
                    Supergenus = table.Column<string>(nullable: true),
                    Genus = table.Column<string>(nullable: true),
                    Subgenus = table.Column<string>(nullable: true),
                    Infragenus = table.Column<string>(nullable: true),
                    Species = table.Column<string>(nullable: true),
                    Subspecies = table.Column<string>(nullable: true),
                    Natio = table.Column<string>(nullable: true),
                    Morpha = table.Column<string>(nullable: true),
                    Forma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTaxonomies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spiders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NamePl = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Temperature = table.Column<float>(nullable: false),
                    Humidity = table.Column<int>(nullable: false),
                    OriginPlace = table.Column<string>(nullable: true),
                    PowerOfVenom = table.Column<int>(nullable: false),
                    Aggressiveness = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    LengthOfLife = table.Column<int>(nullable: false),
                    CocoonSize = table.Column<int>(nullable: false),
                    AnimalTaxonomyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spiders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spiders_AnimalTaxonomies_AnimalTaxonomyId",
                        column: x => x.AnimalTaxonomyId,
                        principalTable: "AnimalTaxonomies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SpiderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Spiders_SpiderId",
                        column: x => x.SpiderId,
                        principalTable: "Spiders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_SpiderId",
                table: "Images",
                column: "SpiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Spiders_AnimalTaxonomyId",
                table: "Spiders",
                column: "AnimalTaxonomyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Spiders");

            migrationBuilder.DropTable(
                name: "AnimalTaxonomies");
        }
    }
}
