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
                    CocoonSize = spider.CocoonSize,
                    //AnimalTaxonomyId = spider.AnimalTaxonomyId
                    
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

        public static AnimalTaxonomyModel MergeAnimalTaxonomyModelWithView(AnimalTaxonomyModel model, SpiderAnimalTaxonomyView view)
        {

            model.Regnum = view.AnimalTaxonomy.Regnum;
            model.Subregnum = view.AnimalTaxonomy.Subregnum;
            model.Superphylum = view.AnimalTaxonomy.Superphylum;
            model.Phylum = view.AnimalTaxonomy.Phylum;
            model.Subphylum = view.AnimalTaxonomy.Subphylum;
            model.Infraphylum = view.AnimalTaxonomy.Infraphylum;
            model.Superclassis = view.AnimalTaxonomy.Superclassis;
            model.Classis = view.AnimalTaxonomy.Classis;
            model.Subclassis = view.AnimalTaxonomy.Subclassis;
            model.Infraclassis = view.AnimalTaxonomy.Infraclassis;
            model.Superordo = view.AnimalTaxonomy.Superordo;
            model.Ordo = view.AnimalTaxonomy.Ordo;
            model.Subordo = view.AnimalTaxonomy.Subordo;
            model.Infraordo = view.AnimalTaxonomy.Infraordo;
            model.Superfamilia = view.AnimalTaxonomy.Superfamilia;
            model.Familia = view.AnimalTaxonomy.Familia;
            model.Subfamilia = view.AnimalTaxonomy.Subfamilia;
            model.Infrafamilia = view.AnimalTaxonomy.Infrafamilia;
            model.Supertrubus = view.AnimalTaxonomy.Supertrubus;
            model.Tribus = view.AnimalTaxonomy.Tribus;
            model.Subtribus = view.AnimalTaxonomy.Subtribus;
            model.Infratribus = view.AnimalTaxonomy.Infratribus;
            model.Supergenus = view.AnimalTaxonomy.Supergenus;
            model.Genus = view.AnimalTaxonomy.Genus;
            model.Subgenus = view.AnimalTaxonomy.Subgenus;
            model.Infragenus = view.AnimalTaxonomy.Infragenus;
            model.Species = view.AnimalTaxonomy.Species;
            model.Subspecies = view.AnimalTaxonomy.Subspecies;
            model.Natio = view.AnimalTaxonomy.Natio;
            model.Morpha = view.AnimalTaxonomy.Morpha;
            model.Forma = view.AnimalTaxonomy.Forma;

            return model;
        }

        public static SpiderModel MergeSpiderModelWitthView(SpiderModel model, SpiderAnimalTaxonomyView view)
        {
            model.NamePl = view.Spider.NamePl;
            model.NameEng = view.Spider.NameEng;
            //model.AnimalTaxonomyId = view.Spider.AnimalTaxonomyId;
            model.Size = view.Spider.Size;
            model.Type = view.Spider.Type;
            model.TemperatureMin = view.Spider.TemperatureMin;
            model.TemperatureMax = view.Spider.TemperatureMax;
            model.HumidityMin = view.Spider.HumidityMin;
            model.HumidityMax = view.Spider.HumidityMax;
            model.OriginPlace = view.Spider.OriginPlace;
            model.PowerOfVenom = view.Spider.PowerOfVenom;
            model.Aggressiveness = view.Spider.Aggressiveness;
            model.Speed = view.Spider.Speed;
            model.LengthOfLife = view.Spider.LengthOfLife;
            model.CocoonSize = view.Spider.CocoonSize;
            

            return model;
        }

    }
}
