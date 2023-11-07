using Microsoft.EntityFrameworkCore;

namespace Nsted.Models
{
    public class NstedDbContext : DbContext
    {
        public NstedDbContext(DbContextOptions<NstedDbContext> options) : base(options)
        {
        }

        public DbSet<Kunde> Kunder { get; set; }

        public DbSet<Service> Servicer { get; set; }

        public DbSet<Ansatt> Ansatte { get; set; }

    }
}