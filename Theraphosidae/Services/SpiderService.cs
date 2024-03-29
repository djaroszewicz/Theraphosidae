﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;
using Theraphosidae.Context;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Services
{
    public class SpiderService : ISpiderService
    {
        private readonly TheraphosidaeContext _theraphosidaeContext;

        public SpiderService(TheraphosidaeContext theraphosidaeContext)
        {
            _theraphosidaeContext = theraphosidaeContext;
        }

        public async Task<bool> Create(SpiderModel spider, int animalTaxonomyId)
        {
            spider.AnimalTaxonomyId = animalTaxonomyId;

            await _theraphosidaeContext.Spiders.AddAsync(spider);

            return await _theraphosidaeContext.SaveChangesAsync() > 0;

        }

        public async Task<bool> CreateAnimalTaxonomy(AnimalTaxonomyModel animalTaxonomy)
        {
            await _theraphosidaeContext.AnimalTaxonomies.AddAsync(animalTaxonomy);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(SpiderModel spider, AnimalTaxonomyModel animalTaxonomy)
        {
            _theraphosidaeContext.Spiders.Update(spider);
            _theraphosidaeContext.AnimalTaxonomies.Update(animalTaxonomy);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateSpiderImage(SpiderModel spider)
        {
            _theraphosidaeContext.Spiders.Update(spider);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }




        public async Task<bool> Delete(int id)
        {
            var spider = await _theraphosidaeContext.Spiders.SingleOrDefaultAsync(s => s.Id == id);
            var spiderImage = await _theraphosidaeContext.Images.SingleOrDefaultAsync(s => s.SpiderId == id);

            if(spider != null)
            {
                _theraphosidaeContext.Spiders.Remove(spider);
                _theraphosidaeContext.Images.Remove(spiderImage);
                return await _theraphosidaeContext.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<SpiderModel> Get(int id)
        {
            var spider = await _theraphosidaeContext.Spiders
                .Include(t => t.AnimalTaxonomy)
                .Include(i => i.Image)
                .SingleOrDefaultAsync(s => s.Id == id);

            return spider;
        }

        public async Task<List<SpiderModel>> GetAll()
        {
            return await _theraphosidaeContext.Spiders
                .Include(t => t.AnimalTaxonomy)
                .Include(i => i.Image)
                .ToListAsync();
        }

        
    }
}
