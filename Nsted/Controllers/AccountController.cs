using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nsted.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

//Kontroller som bruker Identity Framework for autentisering av brukere

namespace Nsted.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        //Dependencies
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
            //Prøver å logge inn bruker basert på brukernavn og passord
            var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.Username,
                 loginViewModel.Password, false, false);

            if (signInResult != null && signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            else if (signInResult == null || !signInResult.Succeeded)
            {
                return View("LoggInnError");
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

