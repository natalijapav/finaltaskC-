using APISystem.Entity;
using APSystem.Entity;
using Microsoft.EntityFrameworkCore;
using UniAPISystem.DtoModels;
using UniAPISystem.Interface;

namespace UniAPISystem.Models
{

    public class DepartmantService : IDepartmantService
    {
        private readonly UniverzitetContext _context;

     
        public DepartmantService()
        {
            _context = new UniverzitetContext();
        }

        public async Task<Departmant> GetDepartmantByIdAsync(int id)
        {
            return await _context.Departmanti.FindAsync(id);
        }

        public async Task AddDepartmantAsync(DepartmantCreateDto departmantDto)
        {
            var departmant = new Departmant
            {
                DepartmantIme = departmantDto.DepartmantIme,
                DepartmantId = departmantDto.DepartmantId,
            };

            await _context.Departmanti.AddAsync(departmant);
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
            if (departman != null)
            {
                _context.Departmanti.Remove(departman);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Departmant>> GetAllDepartmantiAsync()
        {
            return await _context.Departmanti.ToListAsync();
        }
    }
}