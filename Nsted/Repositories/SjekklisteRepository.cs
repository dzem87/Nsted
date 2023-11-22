using Nsted.Data;
using Nsted.Models;

namespace Nsted.Repositories
{
    public class SjekklisteRepository : ISjekklisteRepository
    {
        private readonly NstedDbContext nstedDbContext;

        public SjekklisteRepository(NstedDbContext nstedDbContext)
        {
            this.nstedDbContext = nstedDbContext;
        }

        //Asynkron metode for å legge til en sjekkliste til databasen
        public async Task<Sjekkliste?> AddAsync(Sjekkliste sjekkliste)
        {
            await nstedDbContext.Sjekklister.AddAsync(sjekkliste);
            await nstedDbContext.SaveChangesAsync();
            return sjekkliste;
        }

        public Task<Sjekkliste?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sjekkliste>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Sjekkliste?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Sjekkliste?> UpdateAsync(Sjekkliste sjekkliste)
        {
            throw new NotImplementedException();
        }
    }
}
