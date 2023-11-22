using Nsted.Models;

namespace Nsted.Repositories
{
    public interface ISjekklisteRepository
    {
        Task<IEnumerable<Sjekkliste>> GetAllAsync();

        Task<Sjekkliste?> GetAsync(int id);

        Task<Sjekkliste?> AddAsync(Sjekkliste sjekkliste);

        Task<Sjekkliste?> UpdateAsync(Sjekkliste sjekkliste);

        Task<Sjekkliste?> DeleteAsync(int id);
    }
}
