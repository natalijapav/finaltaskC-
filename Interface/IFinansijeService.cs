using APISystem.Entity;

namespace UniAPISystem.Interface
{
    public interface IFinansijeService
    {
        Task<IEnumerable<Finansije>> GetAllFinansiranjeAsync();
    }
}
