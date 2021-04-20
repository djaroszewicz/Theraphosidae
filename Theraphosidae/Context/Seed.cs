using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Areas.Dashboard.Models.Db.Media;
using Theraphosidae.Areas.Dashboard.Models.Db.Report;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;

namespace Theraphosidae.Context
{
    public class Seed
    {
        public static async Task SeedData(TheraphosidaeContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {

                var users = new List<User>
                {
                    new User
                    {
                        Id = "a",
                        UserName = "admin",
                        Email = "admin@admin.pl",
                    },
                    new User
                    {
                        Id = "u",
                        UserName = "user",
                        Email = "user@user.pl",
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "haslo");
                }
            }


            if (!context.AnimalTaxonomies.Any())
            {

                var animalTaxonomies = new List<AnimalTaxonomyModel>();

                for (int i = 1; i <= 20; i++)
                {
                    var animalTaxonomy = new AnimalTaxonomyModel
                    {
                        Id = i,
                        Regnum = "regnum" + i,
                        Subregnum = "subregnum" + i,
                        Superphylum = "superhylum" + i,
                        Phylum = "phylum" + i,
                        Subphylum = "subphylum" + i,
                        Infraphylum = "infraphylum" + i,
                        Superclassis = "superclassic" + i,
                        Classis = "classic" + i,
                        Subclassis = "sublcassic" + i,
                        Infraclassis = "infraclassic" + i,
                        Superordo = "superordo" + i,
                        Ordo = "ordo" + i,
                        Subordo = "subordo" + i,
                        Infraordo = "infraordo" + i,
                        Superfamilia = "superfamilia" + i,
                        Familia = "familia" + i,
                        Subfamilia = "subfamilia" + i,
                        Infrafamilia = "infrafamilia" + i,
                        Supertrubus = "supertrubus" + i,
                        Tribus = "tribus" + i,
                        Subtribus = "subtribus" + i,
                        Infratribus = "infratribus" + i,
                        Supergenus = "supergenus" + i,
                        Genus = "genus" + i,
                        Subgenus = "subgenus" + i,
                        Infragenus = "infragenus" + i,
                        Species = "species" + i,
                        Subspecies = "subspecies" + i,
                        Natio = "natio" + i,
                        Morpha = "morpha" + i,
                        Forma = "forma" + i
                    };

                    animalTaxonomies.Add(animalTaxonomy);
                }

                foreach (var taxonomies in animalTaxonomies)
                {
                    await context.AnimalTaxonomies.AddAsync(taxonomies);
                }

                await context.SaveChangesAsync();
            }

            if (!context.Spiders.Any())
            {

                var spiders = new List<SpiderModel>();

                for (int i = 1; i <= 20; i++)
                {
                    var spider = new SpiderModel
                    {
                        Id = i,
                        NamePl = "namePL" + i,
                        NameEng = "nameEng" + i,
                        Size = i,
                        Type = "type" + i,
                        TemperatureMin = i,
                        TemperatureMax = i,
                        HumidityMin = i,
                        HumidityMax = i,
                        OriginPlace = "originplace" + i,
                        PowerOfVenom = i,
                        Aggressiveness = i,
                        Speed = i,
                        LengthOfLife = i,
                        CocoonSize = i,
                        Description = "description" + i,
                        ShortDescription = "shortdescription" + i,
                        AnimalTaxonomyId = i,
                        Experience = "experience" + i
                    };

                    spiders.Add(spider);
                }

                foreach (var spider in spiders)
                {
                    await context.Spiders.AddAsync(spider);
                }

                await context.SaveChangesAsync();
            }

            if (!context.Images.Any())
            {

                var images = new List<ImageModel>();

                for (int i = 1; i <= 20; i++)
                {
                    var image = new ImageModel
                    {
                        Id = "id" + i,
                        Url = "url" + i,
                        Name = "name" + i,
                        Description = "description" + i,
                        SpiderId = i
                    };

                    images.Add(image);
                }

                foreach (var image in images)
                {
                    await context.Images.AddAsync(image);
                }

                await context.SaveChangesAsync();
            }

            if (!context.Reports.Any())
            {

                var reports = new List<ReportModel>();

                for (int i = 1; i <= 20; i++)
                {
                    var report = new ReportModel
                    {
                        Id = i,
                        Content = "content" + i,
                        AddDate = DateTime.Now,
                        Views = i,
                        Title = "title" + i,
                        ReportCategory = "reportCategory" + i,
                        SpiderId = i
                    };

                    if (i % 2 == 0)
                    {
                        report.UserId = "a";
                    }
                    else
                    {
                        report.UserId = "u";
                    }

                    reports.Add(report);
                }

                foreach (var report in reports)
                {
                    await context.Reports.AddAsync(report);
                }

                await context.SaveChangesAsync();
            }

            if (!context.ReportImages.Any())
            {

                var images = new List<ReportImageModel>();

                for (int i = 1; i <= 20; i++)
                {
                    var image = new ReportImageModel
                    {
                        Id = "id" + i,
                        Url = "url" + i,
                        Name = "name" + i,
                        Description = "description" + i,
                        ReportId = i
                    };

                    images.Add(image);
                }

                foreach (var image in images)
                {
                    await context.ReportImages.AddAsync(image);
                }

                await context.SaveChangesAsync();
            }

            if (!context.Articles.Any())
            {

                var articles = new List<ArticleModel>();

                for (int i = 1; i <= 20; i++)
                {
                    var article = new ArticleModel
                    {
                        Id = i,
                        AddDate = DateTime.Now,
                        Content = "content" + i,
                        CommentStatus = true,
                        Slug = "slug" + i,
                        ModifiedDate = DateTime.Now,
                        FullUrl = "fullurl" + i,
                        CommentCount = i,
                        Views = i,
                        Category = "category" + i,
                        Abstract = "abstract" + i,
                        Literature = "literature" + i
                    };

                    if (i % 2 == 0)
                    {
                        article.UserId = "a";
                    }
                    else
                    {
                        article.UserId = "u";
                    }

                    articles.Add(article);
                }

                foreach (var article in articles)
                {
                    await context.Articles.AddAsync(article);
                }

                await context.SaveChangesAsync();
            }

            if (!context.Medias.Any())
            {

                var medias = new List<MediaModel>();

                for (int i = 1; i <= 20; i++)
                {
                    var media = new MediaModel
                    {
                        Id = "id" + i,
                        AddDate = DateTime.Now,
                        Url = "url" + i,
                        Name = "name" + i,
                        Description = "description" + i,
                        Length = i,
                        TypeId = i,
                        Type = "type" + i,
                        ArticleId = i
                    };

                    medias.Add(media);
                }

                foreach (var media in medias)
                {
                    await context.Medias.AddAsync(media);
                }

                await context.SaveChangesAsync();
            }

            if (!context.Comments.Any())
            {

                var comments = new List<CommentModel>();

                for (int i = 1; i <= 20; i++)
                {
                    var comment = new CommentModel
                    {
                        Id = i,
                        AddDate = DateTime.Now,
                        Content = "content" + i,
                        ArticleId = i
                    };

                    if (i % 2 == 0)
                    {
                        comment.UserId = "a";
                    }
                    else
                    {
                        comment.UserId = "u";
                    }

                    comments.Add(comment);
                }

                foreach (var comment in comments)
                {
                    await context.Comments.AddAsync(comment);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
