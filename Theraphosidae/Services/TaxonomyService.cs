using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Context;
using Theraphosidae.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Theraphosidae.Services
{
    public class TaxonomyService : ITaxonomyService
    {
        private readonly TheraphosidaeContext _context;

        public TaxonomyService(TheraphosidaeContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int articleId)
        {
            var taxonomiesToRemove = await _context.Taxonomies.Where(t => t.ArticleId == articleId).ToListAsync();

            foreach(var taxonomy in taxonomiesToRemove)
            {
                _context.Taxonomies.Remove(taxonomy);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TaxonomyModel>> SaveCategories(List<CategoryModel> categories, ArticleModel article)
        {
            var taxonomiesList = new List<TaxonomyModel>();

            foreach(var category in categories)
            {
                var taxonomy = new TaxonomyModel
                {
                    Category = category,
                    Article = article
                };
                taxonomiesList.Add(taxonomy);
                await _context.Taxonomies.AddAsync(taxonomy);
            }

            await _context.SaveChangesAsync();
            return taxonomiesList;
        }

        public async Task<List<TaxonomyModel>> SaveTags(List<TagModel> tags, ArticleModel article)
        {
            var taxonomiesList = new List<TaxonomyModel>();

            foreach ( var tag in tags)
            {
                var taxonomy = new TaxonomyModel
                {
                    Tag = tag,
                    Article = article
                };
                taxonomiesList.Add(taxonomy);
                await _context.Taxonomies.AddAsync(taxonomy);
            }

            await _context.SaveChangesAsync();
            return taxonomiesList;
        }
    }
}
