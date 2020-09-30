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
    public class TagService : ITagService
    {
        private readonly TheraphosidaeContext _context;
        public TagService(TheraphosidaeContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckIfTagExist(string name)
        {
            return await _context.Tags.AnyAsync(a => a.Name == name);
        }

        public async Task<bool> Create(TagModel tag)
        {
            await _context.Tags.AddAsync(tag);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var tag = await _context.Tags.SingleOrDefaultAsync(a => a.Id == id);
            if(tag == null)
            {
                return false;
            }

            _context.Tags.Remove(tag);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<TagModel> Get(int id)
        {
            return await _context.Tags.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<TagModel>> GetAll()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<List<TagModel>> GetCategoriesByNames(IEnumerable<string> tagsName)
        {
            var tagList = new List<TagModel>();
            if(tagsName != null)
            {
                foreach(var name in tagsName)
                {
                    var tag = await _context.Tags.SingleOrDefaultAsync(a => a.Name == name);
                    tagList.Add(tag);
                }

            }
            return tagList;
        }

        public async Task<bool> Update(TagModel tag)
        {
            _context.Tags.Update(tag);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
