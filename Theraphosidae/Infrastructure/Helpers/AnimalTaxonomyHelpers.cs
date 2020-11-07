using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;
using Theraphosidae.Areas.Dashboard.Models.View.Spider;

namespace Theraphosidae.Infrastructure.Helpers
{
    public static class AnimalTaxonomyHelpers
    {
        public static AnimalTaxonomyModel ConvertToModel(AnimalTaxonomyView result)
        {
            var AnimalTaxonomyModel = new AnimalTaxonomyModel
            {
                Regnum = result.Regnum,
                Subregnum = result.Subregnum,
                Superphylum = result.Superphylum,
                Phylum = result.Phylum,
                Subphylum = result.Subphylum,
                Infraphylum = result.Infraphylum,
                Superclassis = result.Superclassis,
                Classis = result.Classis,
                Subclassis = result.Subclassis,
                Infraclassis = result.Infraclassis,
                Superordo = result.Superordo,
                Ordo = result.Ordo,
                Subordo = result.Subordo,
                Infraordo = result.Infraordo,
                Superfamilia = result.Superfamilia,
                Familia = result.Familia,
                Subfamilia = result.Subfamilia,
                Infrafamilia = result.Infrafamilia,
                Supertrubus = result.Supertrubus,
                Tribus = result.Tribus,
                Subtribus = result.Subtribus,
                Infratribus = result.Infratribus,
                Supergenus = result.Supergenus,
                Genus = result.Genus,
                Subgenus = result.Subgenus,
                Infragenus = result.Infragenus,
                Species = result.Species,
                Subspecies = result.Subspecies,
                Natio = result.Natio,
                Morpha = result.Morpha,
                Forma = result.Forma
                
            };

            return AnimalTaxonomyModel;
        }

        public static AnimalTaxonomyView ConvertToView(AnimalTaxonomyModel result)
        {
            var AnimalTaxonomyView = new AnimalTaxonomyView
            {
                Id = result.Id,
                Regnum = result.Regnum,
                Subregnum = result.Subregnum,
                Superphylum = result.Superphylum,
                Phylum = result.Phylum,
                Subphylum = result.Subphylum,
                Infraphylum = result.Infraphylum,
                Superclassis = result.Superclassis,
                Classis = result.Classis,
                Subclassis = result.Subclassis,
                Infraclassis = result.Infraclassis,
                Superordo = result.Superordo,
                Ordo = result.Ordo,
                Subordo = result.Subordo,
                Infraordo = result.Infraordo,
                Superfamilia = result.Superfamilia,
                Familia = result.Familia,
                Subfamilia = result.Subfamilia,
                Infrafamilia = result.Infrafamilia,
                Supertrubus = result.Supertrubus,
                Tribus = result.Tribus,
                Subtribus = result.Subtribus,
                Infratribus = result.Infratribus,
                Supergenus = result.Supergenus,
                Genus = result.Genus,
                Subgenus = result.Subgenus,
                Infragenus = result.Infragenus,
                Species = result.Species,
                Subspecies = result.Subspecies,
                Natio = result.Natio,
                Morpha = result.Morpha,
                Forma = result.Forma
            };

            return AnimalTaxonomyView;
        }

        public static AnimalTaxonomyModel MergeViewWithModel(AnimalTaxonomyModel model, AnimalTaxonomyView view)
        {

            model.Regnum = view.Regnum;
            model.Subregnum = view.Subregnum;
            model.Superphylum = view.Superphylum;
            model.Phylum = view.Phylum;
            model.Subphylum = view.Subphylum;
            model.Infraphylum = view.Infraphylum;
            model.Superclassis = view.Superclassis;
            model.Classis = view.Classis;
            model.Subclassis = view.Subclassis;
            model.Infraclassis = view.Infraclassis;
            model.Superordo = view.Superordo;
            model.Ordo = view.Ordo;
            model.Subordo = view.Subordo;
            model.Infraordo = view.Infraordo;
            model.Superfamilia = view.Superfamilia;
            model.Familia = view.Familia;
            model.Subfamilia = view.Subfamilia;
            model.Infrafamilia = view.Infrafamilia;
            model.Supertrubus = view.Supertrubus;
            model.Tribus = view.Tribus;
            model.Subtribus = view.Subtribus;
            model.Infratribus = view.Infratribus;
            model.Supergenus = view.Supergenus;
            model.Genus = view.Genus;
            model.Subgenus = view.Subgenus;
            model.Infragenus = view.Infragenus;
            model.Species = view.Species;
            model.Subspecies = view.Subspecies;
            model.Natio = view.Natio;
            model.Morpha = view.Morpha;
            model.Forma = view.Forma;

            return model;
        }
    }
}
