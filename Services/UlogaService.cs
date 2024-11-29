using APISystem.Entity;
using Microsoft.EntityFrameworkCore;
using UniAPISystem.Interface;

namespace UniAPISystem.Models
{
    public class UlogaService : IUlogaService
    {
        private readonly UniverzitetContext _context;

        public UlogaService()
        {
            _context = new UniverzitetContext();
        }

        public async Task<Uloga> AddUlogaAsync(Uloga uloga)
        {
            _context.Uloge.Add(uloga);
            await _context.SaveChangesAsync();
            return uloga;
        }

        public async Task<IEnumerable<Uloga>> GetAllUlogeAsync()
        {
            return await _context.Uloge.ToListAsync();
        }

        public Task<Uloga> GetUlogeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
