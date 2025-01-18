using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Classes
{
    public class Klant
    {
        [Key]
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }

        [ForeignKey("Adres")]
        public int AdresId { get; set; }
        public Adres Adres { get; set; }
        public List<Woning> Woningen { get; set; }
        public override string ToString()
        {
            return $"{Voornaam} {Familienaam}";
        }

    }

}


