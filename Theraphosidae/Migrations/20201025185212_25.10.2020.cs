using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Theraphosidae.Migrations
{
    public partial class _25102020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Excerpt = table.Column<string>(nullable: true),
                    IsDraft = table.Column<bool>(nullable: false),
                    CommentStatus = table.Column<bool>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    FullUrl = table.Column<string>(nullable: true),
                    MenuOrder = table.Column<int>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommentModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentModel_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    ArticleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Taxonomies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TagId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxonomies_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taxonomies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taxonomies_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_ArticleId",
                table: "CommentModel",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_ArticleId",
                table: "Medias",
                column: "ArticleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomies_ArticleId",
                table: "Taxonomies",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomies_CategoryId",
                table: "Taxonomies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomies_TagId",
                table: "Taxonomies",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentModel");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Taxonomies");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
