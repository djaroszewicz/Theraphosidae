using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;

namespace Theraphosidae.Services.interfaces
{
    public interface IAnimalTaxonomyService
    {
        Task<bool> Create(AnimalTaxonomyModel AnimalTaxonomy);
        Task<AnimalTaxonomyModel> Get(int id);
        Task<List<AnimalTaxonomyModel>> GetAll();
        Task<bool> Update(AnimalTaxonomyModel AnimalTaxonomy);
        Task<bool> Delete(int id);
    }
}
