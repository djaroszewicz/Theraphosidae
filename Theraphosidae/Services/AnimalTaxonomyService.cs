using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;
using Theraphosidae.Context;

namespace Theraphosidae.Services.interfaces
{
    public class AnimalTaxonomyService : IAnimalTaxonomyService
    {
        private readonly TheraphosidaeContext _context;

        public AnimalTaxonomyService(TheraphosidaeContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(AnimalTaxonomyModel AnimalTaxonomy)
        {
            await _context.AnimalTaxonomies.AddAsync(AnimalTaxonomy);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var AnimalTaxonomy = await _context.AnimalTaxonomies.SingleOrDefaultAsync(a => a.Id == id);

            if(AnimalTaxonomy == null)
            {
                return false;
            }

            _context.AnimalTaxonomies.Remove(AnimalTaxonomy);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<AnimalTaxonomyModel> Get(int id)
        {
            return await _context.AnimalTaxonomies.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<AnimalTaxonomyModel>> GetAll()
        {
            return await _context.AnimalTaxonomies.ToListAsync();
        }

        public async Task<bool> Update(AnimalTaxonomyModel AnimalTaxonomy)
        {
            _context.AnimalTaxonomies.Update(AnimalTaxonomy);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
