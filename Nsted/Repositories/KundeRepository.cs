using Nsted.Models;

namespace Nsted.Repositories
{
    public class KundeRepository : IKundeRepository
    {
        //contructor for dbcontext  
        private readonly NstedDbContext nstedDbContext;

        public KundeRepository(NstedDbContext nstedDbContext)
        {
            this.nstedDbContext = nstedDbContext;
        }


        public Task<Kunde?> AddAsync(Kunde kunde)
        {
            throw new NotImplementedException();
        }

        public Task<Kunde?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Kunde>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Kunde?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Kunde?> UpdateAsync(Kunde kunde)
        {
            throw new NotImplementedException();
        }
    }
}
