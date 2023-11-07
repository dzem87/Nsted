using Microsoft.EntityFrameworkCore;
using Nsted.Models;


namespace Nsted.Repositories
{
    public class AnsattRepository : IAnsattRepository
    {
        //constructor for dbcontext
        private readonly NstedDbContext nstedDbContext;

        public AnsattRepository(NstedDbContext nstedDbContext)
        {
            this.nstedDbContext = nstedDbContext;
        }

        public async Task<Ansatt?> AddAsync(Ansatt ansatt)
        {
            await nstedDbContext.Ansatte.AddAsync(ansatt);
            await nstedDbContext.SaveChangesAsync();
            return ansatt;
        }

        public async Task<Ansatt?> DeleteAsync(int ansattNr)
        {
            var eksistingAnsatt = await nstedDbContext.Ansatte.FindAsync(ansattNr);

            if (eksistingAnsatt != null)
            {
                nstedDbContext.Ansatte.Remove(eksistingAnsatt);
                await nstedDbContext.SaveChangesAsync();
                return eksistingAnsatt;
            }
            return null;
        }

        public async Task<IEnumerable<Ansatt>> GetAllAsync()
        {
            return await nstedDbContext.Ansatte.ToListAsync();
        }

        public async Task<Ansatt> GetAsync(int ansattNr)
        {
            return await nstedDbContext.Ansatte.FirstOrDefaultAsync(x => x.AnsattNr == ansattNr);
        }


        public async Task<Ansatt?> UpdateAsync(Ansatt ansatt)
        {
            var eksistingAnsatt = await nstedDbContext.Ansatte.FindAsync(ansatt.AnsattNr);

            if (eksistingAnsatt != null)
            {
                eksistingAnsatt.AnsattNr = ansatt.AnsattNr;
                eksistingAnsatt.Fornavn = ansatt.Fornavn;
                eksistingAnsatt.Etternavn = ansatt.Etternavn;

                await nstedDbContext.SaveChangesAsync();

                return eksistingAnsatt;
            }
            return null;
        }
    }
}
