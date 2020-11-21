using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;

namespace Theraphosidae.Services.interfaces
{
    public interface ISpiderService
    {
        Task<bool> Create(SpiderModel spider, int animalTaxonomyId);
        Task<bool> Update(SpiderModel spider, AnimalTaxonomyModel animalTaxonomy);
        Task<bool> Delete(int id);
        Task<SpiderModel> Get(int id);
        Task<List<SpiderModel>> GetAll();
    }
}
