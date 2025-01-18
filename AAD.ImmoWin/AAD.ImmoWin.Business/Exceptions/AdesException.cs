using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Exceptions
{
    public class StraatIsLeegOfNUllException : Exception
    {
        public StraatIsLeegOfNUllException() : base("Straat is leeg of Null") { }
    }

    public class GemeenteIsLeegOfNullException : Exception
    {
        public GemeenteIsLeegOfNullException() : base("Gemeente is leeg of null") { }
    }

    public class HuisnummerIsLeegOfNullException : Exception
    {
        public HuisnummerIsLeegOfNullException() : base("Huisnummer is leeg of null") { }
    }

    public class PostcodeIsKleinerOfGelijkAanNullException : Exception
    {
        public PostcodeIsKleinerOfGelijkAanNullException() : base("Postcode is kleiner of gelijk aan null") { }
    }
}
