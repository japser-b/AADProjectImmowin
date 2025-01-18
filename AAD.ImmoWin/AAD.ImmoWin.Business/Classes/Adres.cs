using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AAD.ImmoWin.Business.Classes
{
    public class Adres
    {
        [Key]
        public int Id { get; set; }
        public string Straat { get; set; }
        public string Nummer { get; set; }
        public int Postnummer { get; set; }
        public string Gemeente { get; set; }

        public Adres(string straat, string nummer, int postnummer, string gemeente)
        {
            Straat = straat;
            Nummer = nummer;
            Postnummer = postnummer;
            Gemeente = gemeente;
        }

        public Adres() { }
    }
}



