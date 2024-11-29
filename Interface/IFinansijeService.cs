using APISystem.Entity;
using UniAPISystem.DtoModels;

namespace UniAPISystem.Interface
{
    public interface IFinansijeService
    {
        Task<Finansije> GetFinansijeByIdAsync(int id);
        Task AddFinansijeAsync(Finansije finansije);
        Task DeleteFinansijeAsync(int id);
        Task<IEnumerable<Finansije>> GetAllFinansijeAsync();
        
        Task GetAllFinansiranjeAsync();
        Task AddFinansijeAsync(FinansijeCreateDto finansijeDto);
    }
}
