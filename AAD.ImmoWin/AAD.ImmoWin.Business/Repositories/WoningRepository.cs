using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAD.ImmoWin.Business.Classes;
using Microsoft.EntityFrameworkCore;

namespace AAD.ImmoWin.Business.Repositories
{
    public class WoningRepository
    {
        private readonly EFContect _context;

        public WoningRepository(EFContect context)
        {
            _context = context;
        }

        public IEnumerable<Woning> GetAllWoningen()
        {
            return _context.Woningen
                .Include(w => w.Eigenaar)
                .Include(w => w.Adres)
                .Include(w => w.Biedingen)
                .ToList();
        }

        public Woning GetWoningById(int id)
        {
            return _context.Woningen
                .Include(w => w.Eigenaar)
                .Include(w => w.Adres) 
                .FirstOrDefault(w => w.Id == id);
        }

        public void AddWoning(Woning woning)
        {
            _context.Woningen.Add(woning);
            _context.SaveChanges();
        }

        public void UpdateWoning(Woning woning)
        {
            _context.Woningen.Update(woning);
            _context.SaveChanges();
        }

        public void DeleteWoning(int id)
        {
            var woning = _context.Woningen.Find(id);
            if (woning != null)
            {
                _context.Woningen.Remove(woning);
                _context.SaveChanges();
            }
        }
    }
}
