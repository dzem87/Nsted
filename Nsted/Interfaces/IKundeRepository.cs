using Nsted.Models;

namespace Nsted.Interfaces

{
    public interface IKundeRepository
    {
        //Hente ut alle kunder
        Task<IEnumerable<Kunde>> GetAllAsync();

        //Hente ut en kunde
        Task<Kunde?> GetAsync(int id);

        Task<Kunde?> AddAsync(Kunde kunde);

        Task<Kunde?> UpdateAsync(Kunde kunde);

        Task<Kunde?> DeleteAsync(int id);
    }
}
