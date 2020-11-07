using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;

namespace Theraphosidae.Areas.Dashboard.Models.View.Spider
{
    public class SpiderView
    {
        [Required]
        public int Id { get; set; }
        public string NamePl { get; set; }
        public string NameEng { get; set; }

        public int Size { get; set; }
        [Required]
        public string Type { get; set; }
        public float Temperature { get; set; }
        public int Humidity { get; set; }
        [Required]
        public string OriginPlace { get; set; }
        [Required]
        public int PowerOfVenom { get; set; }
        [Required]
        public int Aggressiveness { get; set; }
        [Required]
        public int Speed { get; set; }
        public int LengthOfLife { get; set; }
        public int CocoonSize { get; set; }

        [Required]
        public int AnimalTaxonomyId { get; set; }
        public AnimalTaxonomyModel AnimalTaxonomy { get; set; }
    }
}
