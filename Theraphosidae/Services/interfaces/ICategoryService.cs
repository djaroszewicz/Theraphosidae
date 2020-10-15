﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;

namespace Theraphosidae.Services.interfaces
{
    public interface ICategoryService
    {
        Task<bool> Create(CategoryModel category);
        Task<CategoryModel> Get(int id);
        Task<List<CategoryModel>> GetAll();
        Task<bool> Update(CategoryModel category);
        Task<bool> Delete(int id);
        Task<List<CategoryModel>> GetCategoriesByName(IEnumerable<string> categoriesName);
        Task<CategoryModel> GetCategoryByName(string name);
        Task<bool> CheckIfCategoryExist(string name);
    }
}
