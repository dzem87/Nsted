using Nsted.Models;

//Interface som definerer et sett med asynkrone metoder som blir implementert i KundeRepositoryen

namespace Nsted.Interfaces

{
    public interface IKundeRepository
    {
        //Hente ut alle kunder
        Task<IEnumerable<Kunde>> GetAllAsync();
        //Hente ut en kunde
        Task<Kunde?> GetAsync(int id);
        //Legge til en kunde
        Task<Kunde?> AddAsync(Kunde kunde);
        //Oppdatere en kunde
        Task<Kunde?> UpdateAsync(Kunde kunde);
        //Slette kunde
        Task<Kunde?> DeleteAsync(int id);
    }
}
