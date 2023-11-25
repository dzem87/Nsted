using Microsoft.EntityFrameworkCore;
using Nsted.Data;
using Nsted.Interfaces;
using Nsted.Models;


//Repository som implementerer metodene definert i ServiceRepository interfacet 
namespace Nsted.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        //contructor for dbcontext  
        private readonly NstedDbContext nstedDbContext;

        public ServiceRepository(NstedDbContext nstedDbContext)
        {
            this.nstedDbContext = nstedDbContext;
        }

        //Denne metoden legger til et tjenesteobjekt (Service) i databasen asynkront.
        public async Task<Service?> AddAsync(Service service)
        {
            await nstedDbContext.Servicer.AddAsync(service);
            await nstedDbContext.SaveChangesAsync();
            return service;
        }

        //Denne metoden sletter en tjeneste basert på en gitt ID.
        public async Task<Service?> DeleteAsync(int id)
        {
            var eksistingService = await nstedDbContext.Servicer.FindAsync(id);

            if (eksistingService != null)
            {
                nstedDbContext.Servicer.Remove(eksistingService);
                await nstedDbContext.SaveChangesAsync();
                return eksistingService;
            }

            return null;

        }

        //Denne metoden henter alle tjenester fra databasen asynkront ved å bruke Entity Frameworks.
        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await nstedDbContext.Servicer.ToListAsync();
        }

        //Denne metoden henter en tjeneste basert på en gitt ID asynkront og returnerer den første tjenesten som matcher ID-en.
        public async Task<Service?> GetAsync(int id)
        {
            return await nstedDbContext.Servicer.FirstOrDefaultAsync(x => x.ID == id);
        }

        //Denne metoden oppdaterer en eksisterende tjeneste med informasjonen fra en gitt tjenesteobjekt.
        public async Task<Service?> UpdateAsync(Service service)
        {
            var eksistingService = await nstedDbContext.Servicer.FindAsync(service.ID);

            if (eksistingService != null)
            {
                eksistingService.Produkttype = service.Produkttype;
                eksistingService.ServiceRep = service.ServiceRep;
                eksistingService.Årsmodell = service.Årsmodell;
                eksistingService.Serienummer = service.Serienummer;
                eksistingService.Notat = service.Notat;
                eksistingService.Status = service.Status;

                await nstedDbContext.SaveChangesAsync();

                return eksistingService;
            }
            return null;
        }
    }
}