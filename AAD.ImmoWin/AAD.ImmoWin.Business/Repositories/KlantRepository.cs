using System;
using System.Collections.Generic;
using System.Linq;
using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AAD.ImmoWin.Business.Repositories
{
    public class KlantRepository : IKlantRepository
    {
        private readonly EFContect _context;

        public KlantRepository(EFContect context)
        {
            _context = context;
            //_context.Database.EnsureDeleted();
            //_context.Database.EnsureCreated();
        }

        public IEnumerable<Klant> GetAllKlanten()
        {
            List<Klant> klanten = _context.Klanten.Include(k => k.Woningen).ToList();
            return klanten;
        }

        public Klant GetKlantById(int id)
        {
            Klant klant = _context.Klanten.Include(k => k.Woningen).FirstOrDefault(k => k.Id == id);
            return klant;
        }

        public void AddKlant(Klant klant)
        {
            _context.Klanten.Add(klant);
            _context.SaveChanges();
        }

        public void UpdateKlant(Klant klant)
        {
            _context.Klanten.Update(klant);
            _context.SaveChanges();
        }

        public void DeleteKlant(int id)
        {
            Klant klant = _context.Klanten.Find(id);
            if (klant != null)
            {
                _context.Klanten.Remove(klant);
                _context.SaveChanges();
            }
        }
    }
}
