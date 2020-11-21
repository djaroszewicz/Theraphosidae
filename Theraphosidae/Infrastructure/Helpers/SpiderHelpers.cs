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
                TemperatureMin = result.Spider.TemperatureMin,
                TemperatureMax = result.Spider.TemperatureMax,
                HumidityMin = result.Spider.HumidityMin,
                HumidityMax = result.Spider.HumidityMax,
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

        public static SpiderAnimalTaxonomyView ConvertSpiderAndAnimalTaxonomyToView(SpiderModel spider, AnimalTaxonomyModel animalTaxonomy)
        {
            var spiderAnimalTaxonomyView = new SpiderAnimalTaxonomyView
            {
                Spider = new SpiderView
                {
                    Id = spider.Id,
                    NamePl = spider.NamePl,
                    NameEng = spider.NameEng,
                    Size = spider.Size,
                    Type = spider.Type,
                    TemperatureMin = spider.TemperatureMin,
                    TemperatureMax = spider.TemperatureMax,
                    HumidityMin = spider.HumidityMin,
                    HumidityMax = spider.HumidityMax,
                    OriginPlace = spider.OriginPlace,
                    PowerOfVenom = spider.PowerOfVenom,
                    Aggressiveness = spider.Aggressiveness,
                    Speed = spider.Speed,
                    LengthOfLife = spider.LengthOfLife,
                    CocoonSize = spider.CocoonSize
                },

                AnimalTaxonomy = new AnimalTaxonomyView
                {
                    Id = animalTaxonomy.Id,
                    Regnum = animalTaxonomy.Regnum,
                    Subregnum = animalTaxonomy.Subregnum,
                    Superphylum = animalTaxonomy.Superphylum,
                    Phylum = animalTaxonomy.Phylum,
                    Subphylum = animalTaxonomy.Subphylum,
                    Infraphylum = animalTaxonomy.Infraphylum,
                    Superclassis = animalTaxonomy.Superclassis,
                    Classis = animalTaxonomy.Classis,
                    Subclassis = animalTaxonomy.Subclassis,
                    Infraclassis = animalTaxonomy.Infraclassis,
                    Superordo = animalTaxonomy.Superordo,
                    Ordo = animalTaxonomy.Ordo,
                    Subordo = animalTaxonomy.Subordo,
                    Infraordo = animalTaxonomy.Infraordo,
                    Superfamilia = animalTaxonomy.Superfamilia,
                    Familia = animalTaxonomy.Familia,
                    Subfamilia = animalTaxonomy.Subfamilia,
                    Infrafamilia = animalTaxonomy.Infrafamilia,
                    Supertrubus = animalTaxonomy.Supertrubus,
                    Tribus = animalTaxonomy.Tribus,
                    Subtribus = animalTaxonomy.Subtribus,
                    Infratribus = animalTaxonomy.Infratribus,
                    Supergenus = animalTaxonomy.Supergenus,
                    Genus = animalTaxonomy.Genus,
                    Subgenus = animalTaxonomy.Subgenus,
                    Infragenus = animalTaxonomy.Infragenus,
                    Species = animalTaxonomy.Species,
                    Subspecies = animalTaxonomy.Subspecies,
                    Natio = animalTaxonomy.Natio,
                    Morpha = animalTaxonomy.Morpha,
                    Forma = animalTaxonomy.Forma
                }
            };

            return spiderAnimalTaxonomyView; 
        }

        public static SpiderView ConvertSpiderToView(SpiderModel result)
        {
            var spiderView = new SpiderView
            {
                Id = result.Id,
                NamePl = result.NamePl,
                NameEng = result.NameEng,
                Size = result.Size,
                Type = result.Type,
                TemperatureMin = result.TemperatureMin,
                TemperatureMax = result.TemperatureMax,
                HumidityMin = result.HumidityMin,
                HumidityMax = result.HumidityMax,
                OriginPlace = result.OriginPlace,
                PowerOfVenom = result.PowerOfVenom,
                Aggressiveness = result.Aggressiveness,
                Speed = result.Speed,
                LengthOfLife = result.LengthOfLife,
                CocoonSize = result.CocoonSize
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
