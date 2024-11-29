using APISystem.Entity;

namespace UniAPISystem.Interface
{
    public interface IPredmetService
    {
        Task AddPredmetAsync(Predmet predmet);
        Task UpdatePredmetAsync(Predmet predmet);
        Task DeletePredmetAsync(int id);
        Task<Predmet> GetPredmetByIdAsync(int id);
        Task<IEnumerable<Predmet>> GetAllPredmetiAsync();
    }
}
