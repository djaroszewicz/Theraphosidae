﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;

namespace Theraphosidae.Services.interfaces
{
    public interface IArticleService
    {
        Task<bool> Create(ArticleModel article);
        Task<ArticleModel> Get(int id);
        Task<List<ArticleModel>> GetAll();
        Task<bool> Update(ArticleModel article);
        Task<bool> Delete(int id);
        //Task<int> ArticleCount();
        //Task<int> ArticleCountFromCategory(string category);
        Task<bool> IncrementArticleViews(int id);
        //Task<bool> CheckIfSlugExist(string slug);
        //Task<ArticleModel> GetArticleBySlug(string slug);
        //Task<List<ArticleModel>> GetRangeOfArticle(int start, int count);
        //Task<List<ArticleModel>> GetRangeOfArticleCategory(int start, int count, string category);
        //Task<List<ArticleModel>> GetRecommendedArticle(string category, int currentArticleId);
        //public string GetFirstCategoryOfArticle(ArticleModel article);
    }
}
