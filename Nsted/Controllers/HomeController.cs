using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nsted.Models;
using System.Diagnostics;


//Kontroller som viser hjemside med klokke
// [Authorize] betyr at bare autentiserte brukere har tilgang til metodene i denne kontrolleren
namespace Nsted.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Denne loggeren blir injisert i HomeController ved opprettelse.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Metode for å vise hjemmesiden
        public IActionResult Index()
        {
            return View();
        }

        // Metode for å vise personvernsiden
        public IActionResult Privacy()
        {
            return View();
        }

        // Metode for å håndtere feil og vise feilsiden
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //error notification
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}