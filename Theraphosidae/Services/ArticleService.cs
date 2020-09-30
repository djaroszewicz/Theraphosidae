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
        public async Task<int> ArticleCount()
        {
            var articles = await _context.Articles.Where(a => a.IsDraft != true).ToListAsync();
            return articles.Count;
        }

        public async Task<int> ArticleCountFromCategory(string category)
        {
            var articles = await _context.Taxonomies
                .Where(t => t.Category.Name == category)
                .Include(t => t.Article)
                .Where(t => t.Article.IsDraft != true)
                .Select(t => t.Article)
                .ToListAsync();

            return articles.Count;
        }

        public async Task<bool> Delete(int id)
        {
            // DODAĆ ZDJĘCIA! INCLUDE(t => t.Images). Zrób model image

            var article = await _context.Articles.Include(i => i.Image).SingleOrDefaultAsync(i => i.Id == id);
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
                .Include(t => t.Image)
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

        public async Task<bool> IncrementArticleViews(int id)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(a => a.Id == id);
            article.Views++;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(ArticleModel article)
        {
            article.ModifiedDate = DateTime.Now;
            _context.Articles.Update(article);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CheckIfSlugExist(string slug)
        {
            return await _context.Articles.AnyAsync(a => a.Slug == slug);
        }

        public async Task<ArticleModel> GetArticleBySlug(string slug)
        {
            return await _context.Articles
                .Include(a => a.Taxonomies).ThenInclude(a => a.Category)
                .Include(a => a.Taxonomies).ThenInclude(a => a.Tag)
                .Include(a => a.Image)
                .Include(a => a.User)
                .Include(a => a.Comments)
                .SingleOrDefaultAsync(a => a.Slug == slug);
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
                .Where(a => a.Category.Name == category)
                .Include(a => a.Article)
                .ThenInclude(u => u.User)
                .Include(a => a.Article)
                .ThenInclude(c => c.Comments)
                .Include(t => t.Tag)
                .OrderByDescending(a => a.Article.AddDate)
                .Where(a => a.Article.IsDraft != true)
                .Select(a => a.Article)
                .ToListAsync();

            return articleList.Skip(start).Take(count).ToList();
        }

        public async Task<List<ArticleModel>> GetRecommendedArticle(string category, int currentArticleId)
        {
            var recommendedArticles = await _context.Taxonomies
              .Where(x => x.Category.Name == category)
              .Include(a => a.Article)
              .ThenInclude(u => u.User)
              .Include(a => a.Article)
              .ThenInclude(c => c.Comments)
              .Include(t => t.Tag)
              .OrderByDescending(x => x.Article.AddDate)
              .Where(x => x.Article.IsDraft != true && x.ArticleId != currentArticleId)
              .Select(a => a.Article)
              .Take(2)
              .ToListAsync();

            if(recommendedArticles.Count == 0 || category == null)
            {
                var newsetArticles = Enumerable.Reverse(await _context.Articles.Where(x => x.IsDraft != true && x.Id != currentArticleId).Include(x => x.Image).Include(x => x.User).Include(x => x.Comments).ToListAsync()).Take(2).OrderByDescending(a => a.AddDate);
                return newsetArticles.ToList();
            }

            return recommendedArticles;
        }

        public string GetFirstCategoryOfArticle(ArticleModel article)
        {
            foreach(var taxonomy in article.Taxonomies)
            {
                if(taxonomy.Category != null)
                {
                    return taxonomy.Category.Name;
                }

            }
            return null;
        }
    }
}
