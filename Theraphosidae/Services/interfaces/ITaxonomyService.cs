using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;

namespace Theraphosidae.Services.interfaces
{
    public interface ITaxonomyService
    {
        Task<List<TaxonomyModel>> SaveCategories(List<CategoryModel> categories, ArticleModel article);
        Task<List<TaxonomyModel>> SaveTags(List<TagModel> tags, ArticleModel article);
        Task<bool> Delete(int articleId);
    }
}
