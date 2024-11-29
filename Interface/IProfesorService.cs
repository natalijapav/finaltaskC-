using APISystem.Entity;
using UniAPISystem.DtoModels;

namespace UniAPISystem.Interface
{
    public interface IProfesorService
    {
        
        Task AddProfesorAsync(Profesor profesor);
        Task UpdateProfesorAsync(Profesor profesor);
        Task DeleteProfesorAsync(int id);
        Task<Profesor> GetProfesorByIdAsync(int id);
        Task<IEnumerable<Profesor>> GetAllProfesoriAsync();
        Task AddProfesorAsync(ProfesorCreateDto profesorDto);
    }
}
