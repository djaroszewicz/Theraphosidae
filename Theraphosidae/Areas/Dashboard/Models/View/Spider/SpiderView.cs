using Microsoft.AspNetCore.Http;
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
        [Required(ErrorMessage = "Proszę podać typ ptasznika")]
        public string Type { get; set; }
        public float TemperatureMin { get; set; }
        public float TemperatureMax { get; set; }
        public int HumidityMin { get; set; }
        public int HumidityMax { get; set; }
        [Required(ErrorMessage = "Proszę podać pochodzenie ptasznika")]
        public string OriginPlace { get; set; }
        [Required(ErrorMessage = "Podaj siłę jadu ptasznika")]
        public int PowerOfVenom { get; set; }
        [Required(ErrorMessage = "Podaj agresywność ptasznika")]
        public int Aggressiveness { get; set; }
        [Required(ErrorMessage = "Podaj szybkość ptasznika")]
        public int Speed { get; set; }
        public int LengthOfLife { get; set; }
        public int CocoonSize { get; set; }
        [Required(ErrorMessage = "Opis ptasznika jest wymagany!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Krótki opis ptasznika jest wymagany!")]
        public string ShortDescription { get; set; }
        public IFormFile SpiderFileImg { get; set; }

        [Required]
        public int AnimalTaxonomyId { get; set; }
        public AnimalTaxonomyModel AnimalTaxonomy { get; set; }
    }
}
