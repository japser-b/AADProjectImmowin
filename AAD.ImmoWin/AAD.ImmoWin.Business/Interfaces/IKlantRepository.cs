using AAD.ImmoWin.Business.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IKlantRepository
    {
        IEnumerable<Klant> GetAllKlanten();
        Klant GetKlantById(int id);
        void AddKlant(Klant klant);
        void UpdateKlant(Klant klant);
        void DeleteKlant(int id);
    }
}
