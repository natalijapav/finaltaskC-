using APISystem.Entity;

namespace UniAPISystem.Interface
{
    public interface IUlogaService
    {
        Task<Uloga> GetUlogeByIdAsync(int id);
        Task <Uloga>AddUlogaAsync(Uloga uloga);
        Task<IEnumerable<Uloga>> GetAllUlogeAsync();
        
       
    }
}
