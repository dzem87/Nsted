using Nsted.Models;

namespace Nsted.Repositories
{
    public interface IServiceRepository
    {
        
        Task<IEnumerable<Service>> GetAllAsync();

        Task<Service?> GetAsync(int id);

        Task<Service?> AddAsync(Service service);

        Task<Service?> UpdateAsync(Service service);

        Task<Service?> DeleteAsync(int id);
    }
}
