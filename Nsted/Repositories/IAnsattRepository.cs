using Nsted.Models;

namespace Nsted.Repositories
{
    public interface IAnsattRepository
    {
        //Hente ut alle ansatte
        Task<IEnumerable<Ansatt>> GetAllAsync();

        //Hente ut en ansatt
        Task<Ansatt?> GetAsync(int ansattNr);

        //Legge til ansatt
        Task<Ansatt?> AddAsync(Ansatt ansatt);

        //Oppdatere ansatt
        Task<Ansatt?> UpdateAsync(Ansatt ansatt);

        //Slette ansatt
        Task<Ansatt?> DeleteAsync(int ansattNr);
    }
}
