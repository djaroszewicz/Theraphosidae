using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Areas.Dashboard.Models.View.Article;

namespace Theraphosidae.Infrastructure.Helpers
{
    public static class CommentHelpers
    {

        public static CommentModel ConvertToModel(CommentView result, ArticleModel article, User user)
        {

            var commentModel = new CommentModel
            {
                AddDate = DateTime.Now,
                Content = result.Content,
                User = user,
                //Name = result.Name,
                //Email = result.Email,
                Article = article
            };

            return commentModel;
        }

        public static CommentView ConvertToView(CommentModel result)
        {
            var commentView = new CommentView
            {
                Id = result.Id,
                AddDate = DateTime.Now,
                Content = result.Content,
                User = result.User
                //Name = result.Name,
                //Email = result.Email,
            };

            return commentView;
        }


        public static CommentModel MergeViewWithModel(CommentModel model, CommentView view)
        {
            model.Content = view.Content;
            model.User = view.User;
            //model.Email = view.Email;
            //model.Name = view.Name;

            return model;
        }

    }
}
