using APISystem.Entity;
using Microsoft.EntityFrameworkCore;
using UniAPISystem.Interface;

namespace UniAPISystem.Models
{
    public class OsobaService : IOsobaService
    {
        private readonly UniverzitetContext _context;

        public OsobaService()
        {
            _context = new UniverzitetContext();
        }

        public async Task AddOsobaAsync(Osoba osoba)
        {
            await _context.Osobe.AddAsync(osoba);
            await _context.SaveChangesAsync();
        }
        public async Task<Osoba> GetOsobaAsync(int id)
        {
            return await _context.Osobe.FindAsync(id);
        }
        public async Task UpdateOsobaAsync(Osoba osoba)
        {
            _context.Entry(osoba).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOsobaAsync(int id)
        {
            var osoba = await _context.Osobe.FindAsync(id);
            if(osoba != null)
            {
                _context.Osobe.Remove(osoba);
                await _context.SaveChangesAsync();
            }

        }
    }
}