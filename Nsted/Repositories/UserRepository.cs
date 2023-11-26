using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nsted.Data;
using Nsted.Interfaces;

//Repository som implementerer metodene definert i UserRepository interfacet 
namespace Nsted.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext authDbContext;

        public UserRepository(AuthDbContext authDbContext)
        {
            this.authDbContext = authDbContext;
        }

        //Hente alle brukere fra databasen, men ekskluderer spesifikt superadmin-brukeren fra resultatet
        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users = await authDbContext.Users.ToListAsync();

            var superAdminUser = await authDbContext.Users
                .FirstOrDefaultAsync(x => x.Email == "superAdmin@nsted.com");


            // Sjekker om superadmin er i users tabellen og sletter den fra lista users

            if (superAdminUser != null)
            {
                users.Remove(superAdminUser);
            }
            return users;
        }
    }
}