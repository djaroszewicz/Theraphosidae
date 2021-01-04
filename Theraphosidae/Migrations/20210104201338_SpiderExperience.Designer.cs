﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Theraphosidae.Context;

namespace Theraphosidae.Migrations
{
    [DbContext(typeof(TheraphosidaeContext))]
    [Migration("20210104201338_SpiderExperience")]
    partial class SpiderExperience
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Account.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Article.ArticleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Abstract")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Category")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CommentCount")
                        .HasColumnType("int");

                    b.Property<bool>("CommentStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FullUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Literature")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Slug")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Article.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Slug")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Article.CommentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Article.TagModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Slug")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Article.TaxonomyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TagId");

                    b.ToTable("Taxonomies");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Media.MediaModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Length")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId")
                        .IsUnique();

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Report.ReportImageModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ReportId")
                        .IsUnique();

                    b.ToTable("ReportImages");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Report.ReportModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ReportCategory")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("SpiderId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpiderId");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Spider.AnimalTaxonomyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Classis")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Familia")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Forma")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Genus")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Infraclassis")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Infrafamilia")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Infragenus")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Infraordo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Infraphylum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Infratribus")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Morpha")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Natio")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Ordo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phylum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Regnum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Species")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Subclassis")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Subfamilia")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Subgenus")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Subordo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Subphylum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Subregnum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Subspecies")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Subtribus")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Superclassis")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Superfamilia")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Supergenus")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Superordo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Superphylum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Supertrubus")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Tribus")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("AnimalTaxonomies");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Spider.ImageModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("SpiderId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("SpiderId")
                        .IsUnique();

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Spider.SpiderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Aggressiveness")
                        .HasColumnType("int");

                    b.Property<int>("AnimalTaxonomyId")
                        .HasColumnType("int");

                    b.Property<int>("CocoonSize")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Experience")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("HumidityMax")
                        .HasColumnType("int");

                    b.Property<int>("HumidityMin")
                        .HasColumnType("int");

                    b.Property<int>("LengthOfLife")
                        .HasColumnType("int");

                    b.Property<string>("NameEng")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NamePl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OriginPlace")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PowerOfVenom")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<float>("TemperatureMax")
                        .HasColumnType("float");

                    b.Property<float>("TemperatureMin")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AnimalTaxonomyId");

                    b.ToTable("Spiders");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Account.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Account.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Account.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Account.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Article.ArticleModel", b =>
                {
                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Account.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Article.CommentModel", b =>
                {
                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Article.ArticleModel", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Account.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Article.TaxonomyModel", b =>
                {
                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Article.ArticleModel", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Article.CategoryModel", "Category")
                        .WithMany("Taxonomies")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Article.TagModel", "Tag")
                        .WithMany("Taxonomies")
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Media.MediaModel", b =>
                {
                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Article.ArticleModel", "Article")
                        .WithOne("Image")
                        .HasForeignKey("Theraphosidae.Areas.Dashboard.Models.Db.Media.MediaModel", "ArticleId");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Report.ReportImageModel", b =>
                {
                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Report.ReportModel", "Report")
                        .WithOne("ReportImage")
                        .HasForeignKey("Theraphosidae.Areas.Dashboard.Models.Db.Report.ReportImageModel", "ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Report.ReportModel", b =>
                {
                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Spider.SpiderModel", "Spider")
                        .WithMany()
                        .HasForeignKey("SpiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Account.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Spider.ImageModel", b =>
                {
                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Spider.SpiderModel", "Spider")
                        .WithOne("Image")
                        .HasForeignKey("Theraphosidae.Areas.Dashboard.Models.Db.Spider.ImageModel", "SpiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Theraphosidae.Areas.Dashboard.Models.Db.Spider.SpiderModel", b =>
                {
                    b.HasOne("Theraphosidae.Areas.Dashboard.Models.Db.Spider.AnimalTaxonomyModel", "AnimalTaxonomy")
                        .WithMany()
                        .HasForeignKey("AnimalTaxonomyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
