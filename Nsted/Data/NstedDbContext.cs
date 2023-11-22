using Microsoft.EntityFrameworkCore;
using Nsted.Models;

namespace Nsted.Data
{
    public class NstedDbContext : DbContext
    {
        public NstedDbContext(DbContextOptions<NstedDbContext> options) : base(options)
        {
        }

        public DbSet<Kunde> Kunder { get; set; }

        public DbSet<Service> Servicer { get; set; }

        public DbSet<Sjekkliste> Sjekklister { get; set; }

    }
}