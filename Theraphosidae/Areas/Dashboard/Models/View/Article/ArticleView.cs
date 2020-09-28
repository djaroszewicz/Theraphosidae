﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;

namespace Theraphosidae.Areas.Dashboard.Models.View.Article
{
    public class ArticleView
    {
        public ArticleView()
        {
            IsPhotoEdited = false;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Uzupełnij tytuł")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Wpis nie może być pusty")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Uzupełnij adres url wpisu")]
        public string Slug { get; set; }
        public string Excerpt { get; set; }
        public string FullUrl { get; set; }

        public IFormFile FeaturedImg { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPhotoEdited { get; set; }

        [Required(ErrorMessage = "Wpis musi mieć datę publikacji")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Wpis musi mieć godzinę publikacji")]
        public DateTime Time { get; set; }

        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<string> Tags { get; set; }

        public bool CommentStatus { get; set; }
        public bool IsDraft { get; set; }

        public User User { get; set; }

        //Dodać zdjęcie, kategorie
    }
}
