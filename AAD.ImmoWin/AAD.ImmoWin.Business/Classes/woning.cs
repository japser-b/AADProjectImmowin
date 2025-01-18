using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AAD.ImmoWin.Business.Classes
{
    public  class Woning
    {
        [Key]
        public int Id { get; set; }
        public Adres Adres { get; set; }

        [ForeignKey("Adres")]
        public int AdresId { get; set; }
        public decimal Waarde { get; set; }
        public DateOnly Bouwdatum { get; set; }
        public int AantalSlaapkamers { get; set; }
        public int Oppervlakte { get; set; }
        public int EigenaarId { get; set; }
        public Klant Eigenaar { get; set; }
        public string EigenaarNaam => $"{Eigenaar.Voornaam} {Eigenaar.Familienaam}";

        public string AdresString => $"{Adres.Straat} {Adres.Nummer}, {Adres.Postnummer} {Adres.Gemeente}";

        public ICollection<Bod> Biedingen { get; set; }  // Dit is nodig voor de relatie

    }
}


