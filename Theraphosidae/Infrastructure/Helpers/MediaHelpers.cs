using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Media;
using Theraphosidae.Areas.Dashboard.Models.View.Media;

namespace Theraphosidae.Infrastructure.Helpers
{
    public static class MediaHelpers
    {
        public static MediaModel ConvertToModel(MediaView view)
        {
            var mediaModel = new MediaModel { };
            return mediaModel;

        }

        public static MediaView ConvertToView(MediaModel result)
        {
            var mediaView = new MediaView
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Url = result.Url
            };

            return mediaView;
        }

        public static MediaModel MergeModelWithView(MediaModel model, MediaView view)
        {
            model.Name = view.Name;
            model.Description = view.Description;

            return model;
        }

    }
}
