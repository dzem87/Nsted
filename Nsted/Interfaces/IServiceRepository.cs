using Nsted.Models;

// Interface som består av definisjoner som implementeres i ServiceRepository
namespace Nsted.Interfaces
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
