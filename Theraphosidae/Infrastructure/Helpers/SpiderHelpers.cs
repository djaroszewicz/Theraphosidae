using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;
using Theraphosidae.Areas.Dashboard.Models.View.Spider;

namespace Theraphosidae.Infrastructure.Helpers
{
    public static class SpiderHelpers
    {
        public static SpiderModel ConvertToModel(SpiderView result)
        {
            var spiderModel = new SpiderModel
            {
                NamePl = result.NamePl,
                NameEng = result.NameEng,
                AnimalTaxonomyId = result.AnimalTaxonomyId
            };

            return spiderModel;
        }

        public static SpiderView ConvertToView(SpiderModel result)
        {
            var spiderView = new SpiderView
            {
                Id = result.Id,
                NamePl = result.NamePl,
                NameEng = result.NameEng,
                AnimalTaxonomy = result.AnimalTaxonomy
            };

            return spiderView;
        }

        public static SpiderModel MergeModelWitthView(SpiderModel model, SpiderView view)
        {
            model.NamePl = view.NamePl;
            model.NameEng = view.NameEng;
            model.AnimalTaxonomyId = view.AnimalTaxonomyId;

            return model;
        }

    }
}
