using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;

namespace Theraphosidae.Context
{
    public class TheraphosidaeContext : IdentityDbContext<User>
    {
        public TheraphosidaeContext(DbContextOptions<TheraphosidaeContext> options) : base(options) { }

        public DbSet<ArticleModel> Articles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
