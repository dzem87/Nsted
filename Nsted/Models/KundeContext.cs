using Microsoft.EntityFrameworkCore;
using Nsted.Models;

namespace Nsted.Models
{
    public class KundeContext : DbContext
    {
        public KundeContext(DbContextOptions<KundeContext> options) : base(options)
        {
        }

        public DbSet<Kunde> Kunder { get; set; }

        public DbSet<OpprettService> Servicer { get; set; }

    }
}