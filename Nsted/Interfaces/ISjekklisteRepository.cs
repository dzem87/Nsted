using Nsted.Models;

// Interface som består av definisjoner som implementeres i SjekklisteRepository
namespace Nsted.Interfaces
{
    //ISjekklisteRepository grensesnittet
    public interface ISjekklisteRepository
    {
        // Metode for å hente alle sjekklister asynkront
        Task<IEnumerable<Sjekkliste>> GetAllAsync();
        
        // Metode for å hente en sjekkliste basert på ID asynkront
        Task<Sjekkliste?> GetAsync(int id);

        // Metode for å legge til en sjekkliste asynkront
        Task<Sjekkliste?> AddAsync(Sjekkliste sjekkliste);

        // Metode for å oppdatere en sjekkliste asynkront
        Task<Sjekkliste?> UpdateAsync(Sjekkliste sjekkliste);

        // Metode for å slette en sjekkliste basert på ID asynkront
        Task<Sjekkliste?> DeleteAsync(int id);
    }
}
