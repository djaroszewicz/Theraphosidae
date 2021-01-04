using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Areas.Dashboard.Models.View.Article;

namespace Theraphosidae.Infrastructure.Helpers
{
    public static class ArticleHelpers
    {
        public static string BuildArticleFullUrl(string url, string slug)
        {
            return $"{url}/article/{slug}";
        }

        //private static List<string> GetCategoryFromTaxonomy(ICollection<TaxonomyModel> taxonomies)
        //{
        //    var categoryList = new List<string>();

        //    foreach(var taxonomy in taxonomies)
        //    {
        //        if(taxonomy.Category != null)
        //        {
        //            categoryList.Add(taxonomy.Category.Name);
        //        }
                
        //    }

        //    return categoryList;
        //}

        //private static List<string> GetTagFromTaxonomy(ICollection<TaxonomyModel> taxonomies)
        //{
        //    var tagList = new List<string>();
        //    foreach(var taxonomy in taxonomies)
        //    {
        //        if ( taxonomy.Tag != null)
        //        {
        //            tagList.Add(taxonomy.Tag.Name);
        //        }
        //    }

        //    return tagList;
        //}

        private static string ValidateSlug(string text)
        {
            var tempString = text.Trim().Replace(" ", "-").ToLower();
            return Regex.Replace(tempString, "/[&\\/\\#,+()$~%.'\":*?<>{}!]/g", "", RegexOptions.Compiled);
        }

        //private static DateTime MergeTimeWithDate(DateTime date, DateTime time)
        //{
        //    var day = date.Day;
        //    var mounth = date.Month;
        //    var year = date.Year;

        //    var minutes = time.Minute;
        //    var hour = time.Hour;

        //    return new DateTime(year, mounth, day, hour, minutes, 0);
        //}
        private static DateTime MergeTimeWithDate(DateTime date)
        {
            var day = date.Day;
            var mounth = date.Month;
            var year = date.Year;

            return new DateTime(day, mounth, year);
        }

        public static ArticleModel ConvertToModel(ArticleView article, User user, string mainUrl)
        {
            var articleModel = new ArticleModel
            {
                //AddDate = MergeTimeWithDate(article.Date, article.Time),
                AddDate = DateTime.Now,
                Content = article.Content,
                Title = article.Title,
                Abstract = article.Abstract,
                Literature = article.Literature,
                //Excerpt = article.Excerpt,
                //IsDraft = article.IsDraft,
                CommentStatus = article.CommentStatus,
                //Slug = ValidateSlug(article.Slug),
                ModifiedDate = null,
                //FullUrl = BuildArticleFullUrl(mainUrl, ValidateSlug(article.Slug)),
                //MenuOrder = null,
                CommentCount = 0,
                User = user
            };
            return articleModel;
        }

        public static ArticleModel ConvertArticleToModel(ArticleCommentView result, User user)
        {
            var articleModel = new ArticleModel
            {
                //AddDate = MergeTimeWithDate(article.Date, article.Time),
                AddDate = DateTime.Now,
                Content = result.Article.Content,
                Title = result.Article.Title,
                Abstract = result.Article.Abstract,
                Literature = result.Article.Literature,
                //Excerpt = article.Excerpt,
                //IsDraft = article.IsDraft,
                CommentStatus = result.Article.CommentStatus,
                //Slug = ValidateSlug(article.Slug),
                ModifiedDate = null,
                //FullUrl = BuildArticleFullUrl(mainUrl, ValidateSlug(article.Slug)),
                //MenuOrder = null,
                CommentCount = 0,
                User = user
            };
            return articleModel;
        }

        public static CommentModel ConvertCommentToModel(ArticleCommentView result, User user)
        {
            var commentModel = new CommentModel
            {
                AddDate = DateTime.Now,
                Content = result.Comment.Content,
                User = user,
                //Name = result.Name,
                //Email = result.Email,
                //ArticleId = article.Id
            };

            return commentModel;
        }

        public static ArticleView ConvertToView(ArticleModel article)
        {
            var articleView = new ArticleView
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                Abstract = article.Abstract,
                Literature = article.Literature,
                Views = article.Views,
                CommentStatus = article.CommentStatus,
                Slug = article.Slug,
                User = article.User,
                FullUrl = article.FullUrl,
                AddDate = article.AddDate.ToShortDateString()
                //Excerpt = article.Excerpt,
                //IsDraft = article.IsDraft,
                //Date = MergeTimeWithDate(article.AddDate)
                //Date = MergeTimeWithDate(article.AddDate)



            };

            if(article.Image == null)
            {
                articleView.ImageUrl = "https://res.cloudinary.com/dyytlulq9/image/upload/v1609687626/logo_dirysy.png";
            }
            else
            {
                articleView.ImageUrl = article.Image.Url;
            }

            //if(article.Taxonomies.Count != 0)
            //{
            //    articleView.Categories = GetCategoryFromTaxonomy(article.Taxonomies);
            //    articleView.Tags = GetTagFromTaxonomy(article.Taxonomies);
            //}

            return articleView;
        }

        public static ArticleCommentView ConvertToDetailsView(ArticleModel article)
        {
            var articleCommentView = new ArticleCommentView
            {

                Article = new ArticleView
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                    Abstract = article.Abstract,
                    Literature = article.Literature,
                    Views = article.Views,
                    CommentStatus = article.CommentStatus,
                    Slug = article.Slug,
                    User = article.User,
                    FullUrl = article.FullUrl,
                    AddDate = article.AddDate.ToShortDateString()
                }

                //Comment = new CommentView
                //{
                //    Id = comment.Id,
                //    AddDate = DateTime.Now,
                //    Content = comment.Content,
                //    User = comment.User
                //}

            };

            if (article.Image == null)
            {
                articleCommentView.Article.ImageUrl = "https://res.cloudinary.com/dyytlulq9/image/upload/v1609687626/logo_dirysy.png";
            }
            else
            {
                articleCommentView.Article.ImageUrl = article.Image.Url;
            }

            return articleCommentView;
        }

        public static ArticleModel MergeViewWithModel(ArticleModel model, ArticleView view, string mainUrl)
        {
            model.Title = view.Title;
            model.Slug = view.Slug;
            model.Content = view.Content;
            model.CommentStatus = view.CommentStatus;
            model.Abstract = view.Abstract;
            model.Literature = view.Literature;
            //model.IsDraft = view.IsDraft;
            //model.Excerpt = view.Excerpt;
            model.FullUrl = BuildArticleFullUrl(mainUrl, view.Slug);

            return model;
        }

        public static ArticleModel MergeArticleViewWithModel(ArticleModel model, ArticleCommentView view)
        {
            model.Title = view.Article.Title;
            model.Slug = view.Article.Slug;
            model.Content = view.Article.Content;
            model.CommentStatus = view.Article.CommentStatus;
            model.Abstract = view.Article.Abstract;
            model.Literature = view.Article.Literature;
            //model.IsDraft = view.IsDraft;
            //model.Excerpt = view.Excerpt;
            //model.FullUrl = BuildArticleFullUrl(mainUrl, view.Slug);

            return model;
        }

        public static CommentModel MergeCommentViewWithModel(CommentModel model, ArticleCommentView view)
        {
            model.Content = view.Comment.Content;
            model.User = view.Comment.User;
            //model.Email = view.Email;
            //model.Name = view.Name;

            return model;
        }
    }
}
