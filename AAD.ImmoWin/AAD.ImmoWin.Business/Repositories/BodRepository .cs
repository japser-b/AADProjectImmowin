using AAD.ImmoWin.Business.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Repositories
{
    public class BodRepository
    {
        private readonly EFContect _context;

        public BodRepository(EFContect context)
        {
            _context = context;
        }

        public void VoegBodToe(Bod bod)
        {
            _context.Boden.Add(bod);
            _context.SaveChanges();
        }
    }
}
