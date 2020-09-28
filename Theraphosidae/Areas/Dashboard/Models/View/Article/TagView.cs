using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theraphosidae.Areas.Dashboard.Models.View.Article
{
    public class TagView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Podaj nazwę tagu")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj skróconą nazwę tagu")]
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
