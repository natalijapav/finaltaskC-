using APISystem.Entity;

namespace UniAPISystem.Interface
{
    public interface IOcenaService
    {
        Task AddOcenaAsync(Ocena ocena);
        Task UpdateOcenaAsync(Ocena Ocena);
        Task DeleteOcenaAsync(int id);
        Task<Ocena> GetOcenaByIdAsync(int id);
        Task<IEnumerable<Ocena>> GetAllOceneAsync();

    }
}
