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
    public class CategoryService : ICategoryService
    {
        private readonly TheraphosidaeContext _context;

        public CategoryService(TheraphosidaeContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfCategoryExist(string name)
        {
            return await _context.Categories.AnyAsync(a => a.Name == name);
        }

        public async Task<bool> Create(CategoryModel category)
        {
            await _context.Categories.AddAsync(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(a => a.Id == id);

            if(category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<CategoryModel> Get(int id)
        {
            return await _context.Categories.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<CategoryModel>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<CategoryModel>> GetCategoriesByName(IEnumerable<string> categoriesName)
        {
            var categorriesList = new List<CategoryModel>();
            if(categoriesName != null)
            {
                foreach(var name in categoriesName)
                {
                    var category = await _context.Categories.SingleOrDefaultAsync(a => a.Name == name);
                    categorriesList.Add(category);
                }
                
            }
            return categorriesList;
        }

        public async Task<CategoryModel> GetCategoryByName(string name)
        {
            return await _context.Categories.SingleOrDefaultAsync(a => a.Name == name);
        }

        public async Task<bool> Update(CategoryModel category)
        {
            _context.Categories.Update(category);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
