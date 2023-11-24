using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nsted.Models.ViewModels;
using Nsted.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Nsted.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : Controller

    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<IdentityUser> userManager;

        public AdminUsersController(IUserRepository userRepository,
            UserManager<IdentityUser> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await userRepository.GetAll();

            var usersViewModel = new UserViewModel();
            usersViewModel.Users = new List<User>();

            foreach (var user in users)
            {
                usersViewModel.Users.Add(new Models.ViewModels.User
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    Email = user.Email
                });
            }

            return View(usersViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> List(UserViewModel request)
        {
            var identityUser = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            // Lager bruker med passord 
            var identityResult = await userManager.CreateAsync(identityUser, request.Password);

            if (identityResult != null)
            {
                if (identityResult.Succeeded)
                {
                    // lager liste med roller
                    var roles = new List<string> { "User" };

                    //Sjekker om admin checkboxen er huket av 
                    if (request.AdminRoleCheckbox)
                    {
                        roles.Add("Admin");
                    }

                    // tildeler rolle til brukeren   
                   identityResult =
                        await userManager.AddToRolesAsync(identityUser, roles);

                    // sjekker om brukeren er lagt til med roller = vellykket opperasjon 
                    if (identityResult != null && identityResult.Succeeded)
                     {

                        return RedirectToAction("List", "AdminUsers");
                     }
                }
            }

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            // Henter bruker basert på Id
            var user = await userManager.FindByIdAsync(id.ToString());

            if (user != null )

            {
                // Sletter brukeren
               var identityResult = await userManager.DeleteAsync(user);

                // Sjekker om brukeren blir slettet og returnerer oppdatert list
                if (identityResult != null && identityResult.Succeeded)
                {
                    return RedirectToAction("List", "AdminUsers");
                }
            }

            return View();
        }
    }
}





