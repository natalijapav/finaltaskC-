using APISystem.Entity;
using Microsoft.EntityFrameworkCore;
using UniAPISystem.DtoModels;
using UniAPISystem.Interface;

namespace UniAPISystem.Models
{
    public class FinansijeService : IFinansijeService
    {
        private readonly UniverzitetContext _context;

        public FinansijeService()
        {
            _context = new UniverzitetContext();
        }

        public async Task<Finansije> GetFinansijeByIdAsync(int id)
        {
            return await _context.Finansiranje.FindAsync(id);
        }

        public async Task AddFinansijeAsync(Finansije finansije)
        {
            if (finansije == null)
                throw new ArgumentNullException(nameof(finansije));

            await _context.Finansiranje.AddAsync(finansije);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFinansijeAsync(int id)
        {
            var finansije = await _context.Finansiranje.FirstOrDefaultAsync(f => f.FinId == id);
            if (finansije == null)
                throw new KeyNotFoundException($"Finansije sa ID {id} nisu pronadjene.");

            _context.Finansiranje.Remove(finansije);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Finansije>> GetAllFinansijeAsync()
        {
            return await _context.Finansiranje.ToListAsync();
        }

        //public async Task UpdateFinansijeAsync(Finansije finansije)
        //{
        //    _context.Entry(finansije).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //}

        public Task GetAllFinansiranjeAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddFinansijeAsync(FinansijeCreateDto finansijeDto)
        {
            throw new NotImplementedException();
        }
    }
}
