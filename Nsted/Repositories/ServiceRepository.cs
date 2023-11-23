using Microsoft.EntityFrameworkCore;
using Nsted.Data;
using Nsted.Models;

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

        //Metode for å legge til et Service objekt til databasen asynkront
        public async Task<Service?> AddAsync(Service service)
        {
            await nstedDbContext.Servicer.AddAsync(service);
            await nstedDbContext.SaveChangesAsync();
            return service;
        }


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

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await nstedDbContext.Servicer.ToListAsync();
        }

        public async Task<Service?> GetAsync(int id)
        {
            return await nstedDbContext.Servicer.FirstOrDefaultAsync(x => x.ID == id);
        }

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
