using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theraphosidae.Areas.Dashboard.Models.View.Article
{
    public class ArticleCommentView
    {
        public ArticleView Article { get; set; }
        public CommentView Comment { get; set; }

        public int ArticleHelperId { get; set; }
    }
}
