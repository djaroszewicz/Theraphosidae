using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Areas.Dashboard.Models.Db.Media;

namespace Theraphosidae.Context
{
    public class TheraphosidaeContext : IdentityDbContext<User>
    {
        public TheraphosidaeContext(DbContextOptions<TheraphosidaeContext> options) : base(options) { }

        public DbSet<ArticleModel> Articles { get; set; }
        public DbSet<TaxonomyModel> Taxonomies { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<MediaModel> Medias { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
