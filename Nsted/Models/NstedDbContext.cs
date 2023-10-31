using Microsoft.EntityFrameworkCore;
using Nsted.Models;

namespace Nsted.Models
{
    public class NstedDbContext : DbContext
    {
        public NstedDbContext(DbContextOptions<NstedDbContext> options) : base(options)
        {
        }

        public DbSet<Kunde> Kunder { get; set; }

        public DbSet<OpprettService> Servicer { get; set; }

    }
}