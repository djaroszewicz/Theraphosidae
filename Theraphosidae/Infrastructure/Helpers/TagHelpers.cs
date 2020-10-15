using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Areas.Dashboard.Models.View.Article;
using Theraphosidae.Context;

namespace Theraphosidae.Infrastructure.Helpers
{
    public class TagHelpers
    {
        static string ConvertTextToSlug(string text)
        {
            return text.Trim().Replace(" ", "-").ToLower();
        }

        public static TagModel ConvertToModel(TagView view)
        {
            var categoryModel = new TagModel
            {
                Name = view.Name,
                Slug = ConvertTextToSlug(view.ShortName),
                Description = view.Description,
                Count = 0
            };

            return categoryModel;
        }

        public static TagView ConvertToView(TagModel model)
        {
            var tagView = new TagView
            {
                Id = model.Id,
                Name = model.Name,
                ShortName = model.Slug,
                Description = model.Description
            };
            return tagView;
        }

        public static TagModel MergeModelWithView(TagModel model, TagView view)
        {
            model.Name = view.Name;
            model.Slug = ConvertTextToSlug(view.ShortName);
            model.Description = view.Description;

            return model;
        }

    }
}
