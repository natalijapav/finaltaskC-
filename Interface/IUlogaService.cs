using APISystem.Entity;

namespace UniAPISystem.Interface
{
    public interface IUlogaService
    {
        Task<IEnumerable<Uloga>> GetAllUlogeAsync();
    }
}
