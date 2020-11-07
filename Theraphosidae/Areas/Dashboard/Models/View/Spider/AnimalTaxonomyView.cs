using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theraphosidae.Areas.Dashboard.Models.View.Spider
{
    public class AnimalTaxonomyView
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Regnum { get; set; } //królestwo  GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        public string Subregnum { get; set; } //podkrólestwo
        public string Superphylum { get; set; } //nadtyp
        public string Phylum { get; set; } //typ
        public string Subphylum { get; set; } //podtyp
        public string Infraphylum { get; set; } //infratyp
        public string Superclassis { get; set; } //nadgromada
        [Required]
        public string Classis { get; set; } //gromada   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        public string Subclassis { get; set; } //podgromada
        public string Infraclassis { get; set; } //infragromada
        public string Superordo { get; set; } //nadrząd
        [Required]
        public string Ordo { get; set; } //rząd skrót: ord., o.    GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        public string Subordo { get; set; } //podrząd skrót: subord., so.
        public string Infraordo { get; set; } //infrarząd
        public string Superfamilia { get; set; } //nadrodzina
        [Required]
        public string Familia { get; set; } //rodzina skrót: fam.    GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        public string Subfamilia { get; set; } //podrodzina skrót: subfam.
        public string Infrafamilia { get; set; } //infrarodzina? nie jestem pewien systematyki w Polsce
        public string Supertrubus { get; set; } //nadplemię
        public string Tribus { get; set; } //plemię
        public string Subtribus { get; set; } //podplemię
        public string Infratribus { get; set; } //infraplemię?? to samo co wyzej
        public string Supergenus { get; set; } //nadrodzaj
        [Required]
        public string Genus { get; set; } //rodzaj skrót: gen.    GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        public string Subgenus { get; set; } //podrodzaj skrót: subg., subgen.
        public string Infragenus { get; set; } //infrarodzaj?? brak wiedzy z systematyki
        [Required]
        public string Species { get; set; } //gatunek skrót: sp.    GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA   GŁÓWNA KATEGORIA  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        public string Subspecies { get; set; } //subsp., ssp.
        public string Natio { get; set; } //nacja
        public string Morpha { get; set; } //odmiana
        public string Forma { get; set; } //forma skrót: f.
    }
}
