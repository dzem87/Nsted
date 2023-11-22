using Microsoft.EntityFrameworkCore;
using Nsted.Data;
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


        public async Task<Kunde?> AddAsync(Kunde kunde)
        {
            await nstedDbContext.Kunder.AddAsync(kunde);
            await nstedDbContext.SaveChangesAsync();
            return kunde;
        }

        public async Task<Kunde?> DeleteAsync(int id)
        {
            var eksistingKunde = await nstedDbContext.Kunder.FindAsync(id);

            if (eksistingKunde != null)
            {
                nstedDbContext.Kunder.Remove(eksistingKunde);
                await nstedDbContext.SaveChangesAsync();
                return eksistingKunde;
            }
            return null;
        }

        public async Task<IEnumerable<Kunde>> GetAllAsync()
        {
            return await nstedDbContext.Kunder.ToListAsync();
        }

        public async Task<Kunde?> GetAsync(int id)
        {
            return await nstedDbContext.Kunder.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Kunde?> UpdateAsync(Kunde kunde)
        {
            var eksistingKunde = await nstedDbContext.Kunder.FindAsync(kunde.ID);
            
            if (eksistingKunde != null)
            {
                eksistingKunde.Fornavn = kunde.Fornavn;
                eksistingKunde.Etternavn = kunde.Etternavn;
                eksistingKunde.Adresse = kunde.Adresse;
                eksistingKunde.Telefon = kunde.Telefon;
                eksistingKunde.Epost = kunde.Epost;

                await nstedDbContext.SaveChangesAsync();

                return eksistingKunde;
            }
            return null;
        }
    }
}
