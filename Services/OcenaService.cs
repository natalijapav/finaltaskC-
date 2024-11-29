using APISystem.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using UniAPISystem.Interface;

namespace UniAPISystem.Models
{
    public class OcenaService : IOcenaService
    {
        private readonly UniverzitetContext _context;

        public OcenaService()
        {
            _context = new UniverzitetContext();
        }


        public async Task<Ocena> GetOcenaByIdAsync(int id)
        {
            return await _context.Ocene.FindAsync(id);
        }

        public async Task AddOcenaAsync(Ocena ocena)
        {
            await _context.Ocene.AddAsync(ocena);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOcenaAsync(Ocena ocena)
        {
            _context.Entry(ocena).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOcenaAsync(int id)
        {
            var ocena = await _context.Ocene.FindAsync(id);
            if (ocena != null)
            {
                _context.Ocene.Remove(ocena);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Ocena>> GetAllOceneAsync()
        {
            return await _context.Ocene.ToListAsync();
        }

        
    }
}

