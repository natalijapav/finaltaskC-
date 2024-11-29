using APISystem.Entity;
using Microsoft.EntityFrameworkCore;
using UniAPISystem.Interface;

namespace UniAPISystem.Models
{
    public class KorisnikService : IKorisnikService
    {
        private readonly UniverzitetContext _context;

        public KorisnikService()
        {
            _context = new UniverzitetContext();
        }

        public async Task<IEnumerable<Korisnik>> GetAllKorisnikAsync()
        {
            return await _context.Korisnici.Include(x=>x.UlogaKorisnik).ToListAsync();
            
                
        }
    }
}
