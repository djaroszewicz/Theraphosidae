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
        public static SpiderModel ConvertSpiderToModel(SpiderAnimalTaxonomyView result)
        {
            var spiderModel = new SpiderModel
            {
                NamePl = result.Spider.NamePl,
                NameEng = result.Spider.NameEng,
                Size = result.Spider.Size,
                Type = result.Spider.Type,
                Temperature = result.Spider.Temperature,
                Humidity = result.Spider.Humidity,
                OriginPlace = result.Spider.OriginPlace,
                PowerOfVenom = result.Spider.PowerOfVenom,
                Aggressiveness = result.Spider.Aggressiveness,
                Speed = result.Spider.Speed,
                LengthOfLife = result.Spider.LengthOfLife,
                CocoonSize = result.Spider.CocoonSize
                //AnimalTaxonomyId = result.Spider.AnimalTaxonomyId
            };

            

            return spiderModel;
        }

        public static AnimalTaxonomyModel ConvertAnimalTaxonomyToModel(SpiderAnimalTaxonomyView result)
        {
            var AnimalTaxonomyModel = new AnimalTaxonomyModel
            {
                Regnum = result.AnimalTaxonomy.Regnum,
                Subregnum = result.AnimalTaxonomy.Subregnum,
                Superphylum = result.AnimalTaxonomy.Superphylum,
                Phylum = result.AnimalTaxonomy.Phylum,
                Subphylum = result.AnimalTaxonomy.Subphylum,
                Infraphylum = result.AnimalTaxonomy.Infraphylum,
                Superclassis = result.AnimalTaxonomy.Superclassis,
                Classis = result.AnimalTaxonomy.Classis,
                Subclassis = result.AnimalTaxonomy.Subclassis,
                Infraclassis = result.AnimalTaxonomy.Infraclassis,
                Superordo = result.AnimalTaxonomy.Superordo,
                Ordo = result.AnimalTaxonomy.Ordo,
                Subordo = result.AnimalTaxonomy.Subordo,
                Infraordo = result.AnimalTaxonomy.Infraordo,
                Superfamilia = result.AnimalTaxonomy.Superfamilia,
                Familia = result.AnimalTaxonomy.Familia,
                Subfamilia = result.AnimalTaxonomy.Subfamilia,
                Infrafamilia = result.AnimalTaxonomy.Infrafamilia,
                Supertrubus = result.AnimalTaxonomy.Supertrubus,
                Tribus = result.AnimalTaxonomy.Tribus,
                Subtribus = result.AnimalTaxonomy.Subtribus,
                Infratribus = result.AnimalTaxonomy.Infratribus,
                Supergenus = result.AnimalTaxonomy.Supergenus,
                Genus = result.AnimalTaxonomy.Genus,
                Subgenus = result.AnimalTaxonomy.Subgenus,
                Infragenus = result.AnimalTaxonomy.Infragenus,
                Species = result.AnimalTaxonomy.Species,
                Subspecies = result.AnimalTaxonomy.Subspecies,
                Natio = result.AnimalTaxonomy.Natio,
                Morpha = result.AnimalTaxonomy.Morpha,
                Forma = result.AnimalTaxonomy.Forma

            };

            return AnimalTaxonomyModel;
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
