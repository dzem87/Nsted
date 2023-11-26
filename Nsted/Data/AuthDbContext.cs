using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;



namespace Nsted.Data
{
	public class AuthDbContext : IdentityDbContext
	{
		public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
		{

		}

        //bruker OnModelCreating metoden for å seede data om roller
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Definerer ID-er for forskjellige roller
            var adminRoleId = "fa60657c-7d5f-11ee-b962-0242ac120002";
            var superAdminRoleId = "fa608016-7d5f-11ee-b962-0242ac120002";
            var userRoleId = "fa609222-7d5f-11ee-b962-0242ac120002";

            //Definerer roller, lager liste med ulike roller som er av typen IdentityRole
            var roles = new List<IdentityRole>
            {
                //Legger til Adm-rolle
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                //Legger til SuperAdm-rolle
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                //Legger til User-rolle
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            //Seed Roles (User, Admin, SuperAdmin) i i builder objektet
            builder.Entity<IdentityRole>().HasData(roles);

            //Definerer SuperAdmin som er typen IdentityUser
            var superAdminId = "fa60936c-7d5f-11ee-b962-0242ac120002";

            var superAdminUser = new IdentityUser
            {
                UserName = "superAdmin@nsted.com",
                Email = "superAdmin@nsted.com",
                NormalizedEmail = "superAdmin@nsted.com".ToUpper(),
                NormalizedUserName = "superAdmin@nsted.com".ToUpper(),
                Id = superAdminId
            };

            //Gir SuperAdmin Passord
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Nsted@123");

            //Seed SuperAdminUser i builder objektet
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Bestemmer rollene til SuperAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                // Gir SuperAdmin Admin-rolle
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },

                // Gir SuperAdmin SuperAdmin-rolle
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },

                // Gir SuperAdmin User rolle
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };

            //Seed SupoerAdminUser med bestemte roller
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        }
    }
}

