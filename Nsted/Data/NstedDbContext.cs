using Microsoft.EntityFrameworkCore;
using Nsted.Models;

//DbContext klasse for EntityFrameworkCore som brukes som en kobling mellom applikasjonen og databasen
//Definerer entitetene (Kunde, Service og Sjekkliste) og deres tabeller i databasen
//

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