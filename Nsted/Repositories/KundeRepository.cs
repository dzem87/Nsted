using Microsoft.EntityFrameworkCore;
using Nsted.Data;
using Nsted.Interfaces;
using Nsted.Models;

//Repository får håndtering av kunder, som implementerer de asynkrone metodene definert i IKundeRepository interfacet 

namespace Nsted.Repositories
{

    public class KundeRepository : IKundeRepository
    {
        //contructor for DbContext klassen som gjør det mulig å kommunisere med databasen
        private readonly NstedDbContext nstedDbContext;

        public KundeRepository(NstedDbContext nstedDbContext)
        {
            this.nstedDbContext = nstedDbContext;
        }


        //Legger til en ny kunde i databasen
        public async Task<Kunde?> AddAsync(Kunde kunde)
        {
            await nstedDbContext.Kunder.AddAsync(kunde);
            await nstedDbContext.SaveChangesAsync();
            return kunde;
        }

        //Sletter en kunde basert på en gitt ID.
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

        //Henter alle kunder fra databasen 
        public async Task<IEnumerable<Kunde>> GetAllAsync()
        {
            return await nstedDbContext.Kunder.ToListAsync();
        }

        //Henter en kunde basert på en gitt ID og returnerer den første kunden som matcher ID-en.
        public async Task<Kunde?> GetAsync(int id)
        {
            return await nstedDbContext.Kunder.FirstOrDefaultAsync(x => x.ID == id);
        }

        //Oppdaterer en eksisterende kunde med informasjonen fra et gitt kundeobjekt.
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