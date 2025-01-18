using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Exceptions
{
    public class FamilienaamIsLeegOfNullException : Exception
    {
        public FamilienaamIsLeegOfNullException(): base("Familienaam is leeg of Null")
        {

        }

    }
}
