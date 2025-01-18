using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAD.ImmoWin.Business.Interfaces;

namespace AAD.ImmoWin.Business.Classes
{
    public enum Soort
    {
        Rijhuis,
        Driegevel,
        Alleenstaand
    }
    public class Huis : Woning
    {

        public Soort Soort { get; set; }
    }

}

