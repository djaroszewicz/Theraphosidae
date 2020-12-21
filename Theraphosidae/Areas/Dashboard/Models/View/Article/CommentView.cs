using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;

namespace Theraphosidae.Areas.Dashboard.Models.View.Article
{
    public class CommentView
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; }
        //public bool IsAccepted { get; set; }
        //[EmailAddress(ErrorMessage = "Podaj prawidłowy adres E-mail")]
        //[Required(ErrorMessage = "Uzupełnij E-mail")]
        //public string Email { get; set; }
        //[Required(ErrorMessage = "Uzupełnij swoją nazwę")]
        //public string Name { get; set; }
        [Required(ErrorMessage = "Nie można dodać pustego komentarza!")]
        public string Content { get; set; }
        //[Required(ErrorMessage = "Id artykułu jest obowiązkowe!")]
        public int ArticleId { get; set; }
        public User User { get; set; }
    }
}
