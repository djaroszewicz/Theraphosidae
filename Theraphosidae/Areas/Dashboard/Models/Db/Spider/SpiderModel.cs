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
        public int Size { get; set; }
        public string Type { get; set; }
        public float TemperatureMin { get; set; }
        public float TemperatureMax { get; set; }
        public int HumidityMin { get; set; }
        public int HumidityMax { get; set; }
        public string OriginPlace { get; set; }
        public int PowerOfVenom { get; set; }
        public int Aggressiveness { get; set; }
        public int Speed { get; set; }
        public int LengthOfLife { get; set; }
        public int CocoonSize { get; set; }
        public int AnimalTaxonomyId { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        // Dodaj Short Description i Description
        public AnimalTaxonomyModel AnimalTaxonomy { get; set; }
        public ICollection<ImageModel> Images { get; set; }
    }
}
