using Microsoft.EntityFrameworkCore;
using Nsted.Data;
using Nsted.Interfaces;
using Nsted.Models;

//Repository som implementerer metodene definert i SjekklisteRepository interfacet 
namespace Nsted.Repositories
{
    public class SjekklisteRepository : ISjekklisteRepository
    {
        private readonly NstedDbContext nstedDbContext;

        public SjekklisteRepository(NstedDbContext nstedDbContext)
        {
            this.nstedDbContext = nstedDbContext;
        }

        //Denne metoden legger til en sjekklisteobjekt (Sjekkliste) i databasen asynkront.
        public async Task<Sjekkliste?> AddAsync(Sjekkliste sjekkliste)
        {
            await nstedDbContext.Sjekklister.AddAsync(sjekkliste);
            await nstedDbContext.SaveChangesAsync();
            return sjekkliste;
        }
        //Denne metoden sletter en sjekkliste basert på en gitt ID.
        public async Task<Sjekkliste?> DeleteAsync(int id)

        {
            var eksistingSjekkliste = await nstedDbContext.Sjekklister.FindAsync(id);

            if (eksistingSjekkliste != null)
            {
                nstedDbContext.Sjekklister.Remove(eksistingSjekkliste);
                await nstedDbContext.SaveChangesAsync();
                return eksistingSjekkliste;
            }

            return null;
        }

        //Denne metoden henter alle sjekklister fra databasen asynkront ved å bruke Entity Frameworks ToListAsync()-metode på nstedDbContext.Sjekklister.
        public async Task<IEnumerable<Sjekkliste>> GetAllAsync()
        {
            return await nstedDbContext.Sjekklister.ToListAsync();
        }

        //Denne metoden henter en sjekkliste basert på en gitt ID asynkront og returnerer den første sjekklisten som matcher ID-en.
        public async Task<Sjekkliste?> GetAsync(int id)
        {
            return await nstedDbContext.Sjekklister.FirstOrDefaultAsync(x => x.Id == id);
        }

        //Denne metoden oppdaterer en eksisterende sjekkliste med informasjonen fra en gitt sjekklisteobjekt.
        public async Task<Sjekkliste?> UpdateAsync(Sjekkliste sjekkliste)
        {
            var eksistingSjekkliste = await nstedDbContext.Sjekklister.FindAsync(sjekkliste.Id);

            if (eksistingSjekkliste != null)
            {
                eksistingSjekkliste.Serienummer = sjekkliste.Serienummer;
                eksistingSjekkliste.SjekkClutchLamellerForSlitasje = sjekkliste.SjekkClutchLamellerForSlitasje;
                eksistingSjekkliste.SjekkBremser = sjekkliste.SjekkBremser;
                eksistingSjekkliste.SjekkLagerForTrommel = sjekkliste.SjekkLagerForTrommel;
                //eksistingSjekkliste.SjekkPTO = sjekkliste.SjekkPTO;
                eksistingSjekkliste.SjekkKjedestrammer = sjekkliste.SjekkKjedestrammer;
                eksistingSjekkliste.SjekkWire = sjekkliste.SjekkWire;
                eksistingSjekkliste.SjekkPinonLager = sjekkliste.SjekkPinonLager;
                eksistingSjekkliste.SjekkKile = sjekkliste.SjekkKile;
                eksistingSjekkliste.SjekkHydrauliskSylinder = sjekkliste.SjekkHydrauliskSylinder;
                eksistingSjekkliste.SjekkSlanger = sjekkliste.SjekkSlanger;
                eksistingSjekkliste.TestHydraulikkblokk = sjekkliste.TestHydraulikkblokk;
                eksistingSjekkliste.SkifteOljeTank = sjekkliste.SkifteOljeTank;
                eksistingSjekkliste.SkifteOljeGirBoks = sjekkliste.SkifteOljeGirBoks;
                eksistingSjekkliste.SjekkRyngsylinder = sjekkliste.SjekkRyngsylinder;
                eksistingSjekkliste.SjekkBremsesylinder = sjekkliste.SjekkBremsesylinder;
                eksistingSjekkliste.SjekkLedningsnett = sjekkliste.SjekkLedningsnett;
                eksistingSjekkliste.SjekkRadio = sjekkliste.SjekkRadio;
                eksistingSjekkliste.SjekkKnappekasse = sjekkliste.SjekkKnappekasse;
                eksistingSjekkliste.ServiceID = sjekkliste.ServiceID;


                await nstedDbContext.SaveChangesAsync();

                return eksistingSjekkliste;
            }
            return null;
        }
    }
}