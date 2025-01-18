using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Classes
{
    public class Bod
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Klant")]
        public int KlantId { get; set; }
        public Klant Klant { get; set; }

        [ForeignKey("Woning")]
        public int WoningId { get; set; }
        public Woning Woning { get; set; }

        public decimal BodBedrag { get; set; }

        public DateOnly BodDatum { get; set; }
    }
}
