using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Exceptions
{
    public class WaardeIsNegatiefOfNullException : Exception
    {
        public WaardeIsNegatiefOfNullException() : base("Waarde is negatief of Null") { }
    }

    public class BouwdatumInToekomstException : Exception
    {
        public BouwdatumInToekomstException() : base("Bouwdatum mag niet in de toekomst liggen") { }
    }

    public class AantalSlaapkamersNegatiefOfNullException : Exception
    {
        public AantalSlaapkamersNegatiefOfNullException() : base ("Aantal slaapkamers is negatief of leeg") { }
    }
}
