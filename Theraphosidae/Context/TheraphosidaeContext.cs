﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Areas.Dashboard.Models.Db.Media;
using Theraphosidae.Areas.Dashboard.Models.Db.Report;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;

namespace Theraphosidae.Context
{
    public class TheraphosidaeContext : IdentityDbContext<User>
    {
        public TheraphosidaeContext(DbContextOptions<TheraphosidaeContext> options) : base(options) { }
         
        public DbSet<ArticleModel> Articles { get; set; }

        public DbSet<MediaModel> Medias { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<SpiderModel> Spiders { get; set; }
        public DbSet<AnimalTaxonomyModel> AnimalTaxonomies { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<ReportModel> Reports { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<TaxonomyModel> Taxonomies { get; set; }
        public DbSet<ReportImageModel> ReportImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
