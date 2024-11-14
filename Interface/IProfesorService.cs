using APISystem.Entity;

namespace UniAPISystem.Interface
{
    public interface IProfesorService
    {
        
        Task AddProfesorAsync(Profesor profesor);
        Task UpdateProfesorAsync(Profesor profesor);
        Task DeleteProfesorAsync(int id);
        Task<Profesor> GetProfesorByIdAsync(int id);
        Task<IEnumerable<Profesor>> GetAllProfesoriAsync();
    }
}
