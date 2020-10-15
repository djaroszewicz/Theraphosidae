using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theraphosidae.Areas.Dashboard.Models.Db.Spider
{
    public class SpiderModel
    {
        [Key]
        public int Id { get; set; }
        public string NamePl { get; set; }
        public string NameEng { get; set; }
        public int? AnimalTaxonomyId { get; set; }
        public AnimalTaxonomyModel AnimalTaxonomy { get; set; }
        public ICollection<ImageModel> Images { get; set; }
    }
}
