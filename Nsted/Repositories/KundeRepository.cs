using Microsoft.EntityFrameworkCore;
using Nsted.Data;
using Nsted.Interfaces;
using Nsted.Models;

//Repository som implementerer metodene definert i KundeRepository interfacet 
namespace Nsted.Repositories
{

    public class KundeRepository : IKundeRepository
    {
        //contructor for DbContext som gir tilgang til databasekonteksten for kundedata
        private readonly NstedDbContext nstedDbContext;

        public KundeRepository(NstedDbContext nstedDbContext)
        {
            this.nstedDbContext = nstedDbContext;
        }


        //Denne metoden legger til et kundeobjekt (Kunde) i databasen asynkront.
        public async Task<Kunde?> AddAsync(Kunde kunde)
        {
            await nstedDbContext.Kunder.AddAsync(kunde);
            await nstedDbContext.SaveChangesAsync();
            return kunde;
        }

        //Denne metoden sletter en kunde basert på en gitt ID.
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

        //Denne metoden henter alle kunder fra databasen asynkront ved å bruke Entity Frameworks 
        public async Task<IEnumerable<Kunde>> GetAllAsync()
        {
            return await nstedDbContext.Kunder.ToListAsync();
        }

        //Denne metoden henter en kunde basert på en gitt ID asynkront og returnerer den første kunden som matcher ID-en.
        public async Task<Kunde?> GetAsync(int id)
        {
            return await nstedDbContext.Kunder.FirstOrDefaultAsync(x => x.ID == id);
        }

        //Denne metoden oppdaterer en eksisterende kunde med informasjonen fra en gitt kundeobjekt.
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