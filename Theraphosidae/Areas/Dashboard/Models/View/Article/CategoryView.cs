using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theraphosidae.Areas.Dashboard.Models.View.Article
{
    public class CategoryView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Uzupełnij nazwę dla kategorii")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Uzupełnij skróconą nazwę dla0 kategorii")]
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
