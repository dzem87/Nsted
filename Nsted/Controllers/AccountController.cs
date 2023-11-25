using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nsted.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

//Kontroller som har ansvaret for bruker-relatert autentisering med bruk av Identity Framework

namespace Nsted.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        //Tjenseser kontrolleren bruker for innlogging av avlogging
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

       
        //Returnerer Login Viewet
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //Håndterer HTTP POST forespørsel fra Login formet
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

           var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.Username,
                loginViewModel.Password, false, false);

            if (signInResult != null && signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //Håndterer HTTP GET forespørsel for å logge ut brukeren
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}

