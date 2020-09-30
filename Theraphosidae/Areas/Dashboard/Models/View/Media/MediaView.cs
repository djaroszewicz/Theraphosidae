﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theraphosidae.Areas.Dashboard.Models.View.Media
{
    public class MediaView
    {
        [Required]
        public string Id { get; set; }
        public string Url { get; set; }
        [Required(ErrorMessage = "Podaj nazwę zdjęcia")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Uzupełnij opis")]
        public string Description { get; set; }
    }
}
