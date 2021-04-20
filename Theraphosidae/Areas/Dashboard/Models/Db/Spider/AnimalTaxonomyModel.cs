using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theraphosidae.Areas.Dashboard.Models.Db.Spider
{
    public class AnimalTaxonomyModel
    {
        [Key]
        public int Id { get; set; }
        public string Regnum { get; set; }
        public string Subregnum { get; set; }
        public string Superphylum { get; set; }
        public string Phylum { get; set; }
        public string Subphylum { get; set; }
        public string Infraphylum { get; set; }
        public string Superclassis { get; set; }
        public string Classis { get; set; }
        public string Subclassis { get; set; }
        public string Infraclassis { get; set; }
        public string Superordo { get; set; }
        public string Ordo { get; set; }
        public string Subordo { get; set; }
        public string Infraordo { get; set; }
        public string Superfamilia { get; set; }
        public string Familia { get; set; }
        public string Subfamilia { get; set; }
        public string Infrafamilia { get; set; }
        public string Supertrubus { get; set; }
        public string Tribus { get; set; }
        public string Subtribus { get; set; }
        public string Infratribus { get; set; }
        public string Supergenus { get; set; }
        public string Genus { get; set; }
        public string Subgenus { get; set; }
        public string Infragenus { get; set; }
        public string Species { get; set; }
        public string Subspecies { get; set; }
        public string Natio { get; set; }
        public string Morpha { get; set; }
        public string Forma { get; set; }

    }






    //public class AnimalTaxonomyModel
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public string Regnum { get; set; } //królestwo  GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //    public string Subregnum { get; set; } //podkrólestwo
    //    public string Superphylum { get; set; } //nadtyp
    //    public string Phylum { get; set; } //typ
    //    public string Subphylum { get; set; } //podtyp
    //    public string Infraphylum { get; set; } //infratyp
    //    public string Superclassis { get; set; } //nadgromada
    //    public string Classis { get; set; } //gromada   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //    public string Subclassis { get; set; } //podgromada
    //    public string Infraclassis { get; set; } //infragromada
    //    public string Superordo { get; set; } //nadrząd
    //    public string Ordo { get; set; } //rząd skrót: ord., o.    GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //    public string Subordo { get; set; } //podrząd skrót: subord., so.
    //    public string Infraordo { get; set; } //infrarząd
    //    public string Superfamilia { get; set; } //nadrodzina
    //    public string Familia { get; set; } //rodzina skrót: fam.    GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //    public string Subfamilia { get; set; } //podrodzina skrót: subfam.
    //    public string Infrafamilia { get; set; } //infrarodzina? nie jestem pewien systematyki w Polsce
    //    public string Supertrubus { get; set; } //nadplemię
    //    public string Tribus { get; set; } //plemię
    //    public string Subtribus { get; set; } //podplemię
    //    public string Infratribus { get; set; } //infraplemię?? to samo co wyzej
    //    public string Supergenus { get; set; } //nadrodzaj
    //    public string Genus { get; set; } //rodzaj skrót: gen.    GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //    public string Subgenus { get; set; } //podrodzaj skrót: subg., subgen.
    //    public string Infragenus { get; set; } //infrarodzaj?? brak wiedzy z systematyki
    //    public string Species { get; set; } //gatunek skrót: sp.    GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //    public string Subspecies { get; set; } //subsp., ssp.
    //    public string Natio { get; set; } //nacja
    //    public string Morpha { get; set; } //odmiana
    //    public string Forma { get; set; } //forma skrót: f.

    //}
}
