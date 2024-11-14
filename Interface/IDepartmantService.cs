using APSystem.Entity;

namespace UniAPISystem.Interface
{
    public interface IDepartmantService
    {
        Task<IEnumerable<Departmant>> GetAllDepartmantiAsync();
        Task<Departmant> GetDepartmantByIdAsync(int id);
        Task AddDepartmantAsync(Departmant departman);
        Task UpdateDepartmantAsync(Departmant departman);
        Task DeleteDepartmantAsync(int id);
    }
}
