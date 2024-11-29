using APSystem.Entity;
using UniAPISystem.DtoModels;

namespace UniAPISystem.Interface
{
    //public interface IDepartmantService
    //{
    //    Task<IEnumerable<Departmant>> GetAllDepartmantiAsync();
    //    Task<Departmant> GetDepartmantByIdAsync(int id);
    //    Task AddDepartmantAsync(Departmant departman);
    //    Task UpdateDepartmantAsync(Departmant departman);
    //    Task DeleteDepartmantAsync(int id);
    //    Task GetDepartmanWithIdAsync(int id);
    //    Task<object?> GetAllDepartmaniAsync();
    //    Task AddDepartmantAsync(Departmants.API.Controllers.DepartmantCreateDto departmantDto);
    //}

    public interface IDepartmantService
    {
        Task<IEnumerable<Departmant>> GetAllDepartmantiAsync();
        Task<Departmant> GetDepartmantByIdAsync(int id);
        Task AddDepartmantAsync(DepartmantCreateDto departmantDto);
        Task UpdateDepartmantAsync(Departmant departman);
        Task DeleteDepartmantAsync(int id);
    }
}
