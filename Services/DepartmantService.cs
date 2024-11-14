using APISystem.Entity;
using APSystem.Entity;
using Microsoft.EntityFrameworkCore;
using UniAPISystem.Interface;

namespace UniAPISystem.Services
{
    public class DepartmantService : IDepartmantService
    {
        private readonly UniverzitetContext _context;

        public DepartmantService()
        {
            _context = new UniverzitetContext();
        }

        public DepartmantService(UniverzitetContext context)
        {
            _context = context;
        }

        public async Task<Departmant> GetDepartmantByIdAsync(int id)
        {
            return await _context.Departmanti.FindAsync(id);
        }

        public async Task AddDepartmantAsync(Departmant departman)
        {
            await _context.Departmanti.AddAsync(departman);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDepartmantAsync(Departmant departman)
        {
            _context.Departmanti.Update(departman);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmantAsync(int id)
        {
            var departman = await GetDepartmantByIdAsync(id);


            _context.Departmanti.Remove(departman);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Departmant>> GetAllDepartmantiAsync()
        {
            return await _context.Departmanti.ToListAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
