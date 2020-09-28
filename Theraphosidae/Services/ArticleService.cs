using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Context;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Services
{
    public class ArticleService : IArticleService
    {
        private readonly TheraphosidaeContext _context;
        
        public ArticleService(TheraphosidaeContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(ArticleModel category)
        {
            await _context.Articles.AddAsync(category);
            return await _context.SaveChangesAsync() > 0;
        }
        public Task<int> ArticleCount()
        {
            throw new NotImplementedException();
        }

        public Task<int> ArticleCountFromCategory(string category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            // DODAĆ ZDJĘCIA! INCLUDE(t => t.Images). Zrób model image

            var article = await _context.Articles.SingleOrDefaultAsync(i => i.Id == id);
            if(article == null)
            {
                return false;
            }
            _context.Articles.Remove(article);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ArticleModel> Get(int id)
        {
            return await _context.Articles
                .Include(t => t.Taxonomies).ThenInclude(t => t.Category)
                .Include(t => t.Taxonomies).ThenInclude(t => t.Tag)
                .Include(t => t.User)
                .Include(t => t.Comments)
                .SingleOrDefaultAsync(i => i.Id == id);
            //DODAĆ TUTAJ ZDJĘCIA. PODPIĄĆ MODEL SOBIE POD CLOUDINARY
        }

        public async Task<List<ArticleModel>> GetAll()
        {
            var articleList = await _context.Articles
                .Include(t => t.Taxonomies).ThenInclude(t => t.Category)
                .Include(t => t.Taxonomies).ThenInclude(t => t.Tag)
                .Include(t => t.User)
                .Include(t => t.Comments)
                .OrderByDescending(t => t.AddDate)
                .ToListAsync();

            return articleList;
        }

        public Task<bool> IncrementArticleViews(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(ArticleModel article)
        {
            article.ModifiedDate = DateTime.Now;
            _context.Articles.Update(article);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> CheckIfSlugExist(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleModel> GetArticleBySlug(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArticleModel>> GetRangeOfArticle(int start, int count)
        {
            var articleList = await _context.Articles
                .Include(t => t.Taxonomies).ThenInclude(t => t.Category)
                .Include(t => t.Taxonomies).ThenInclude(t => t.Tag)
                .Include(t => t.User)
                .Include(t => t.Comments)
                .OrderBy(t => t.AddDate)
                .Where(t => t.IsDraft != true)
                .ToListAsync();

            articleList.Reverse();
            return articleList.Skip(start).Take(count).ToList();
        }

        public async Task<List<ArticleModel>> GetRangeOfArticleCategory(int start, int count, string category)
        {
            var articleList = await _context.Taxonomies
        }

        public Task<List<ArticleModel>> GetRecommendedArticle(string category, int currentArticleId)
        {
            throw new NotImplementedException();
        }

        public string GetFirstCategoryOfArticle(ArticleModel article)
        {
            throw new NotImplementedException();
        }
    }
}
