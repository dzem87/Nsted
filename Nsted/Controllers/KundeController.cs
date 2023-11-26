using Microsoft.AspNetCore.Mvc;
using Nsted.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Text.Encodings.Web;
using Nsted.Interfaces;

//Kontroller som muliggjør CRUD operasjoner på kunder
//Bruker IKundeRepository for å kommunisere med databasen
//Bruker autorisasjon for å sikre at kun autoriserte brukere har tilgang til metodene


namespace Nsted.Controllers
{

    [Authorize]
    public class KundeController : Controller
    {

        private readonly IKundeRepository kundeRepository;
        
        //Dependencies
        public KundeController(IKundeRepository kundeRepository)
        {
            this.kundeRepository = kundeRepository;
        }

       
        //Returnerer view for å legge til nye kunder
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //Håndterer HTTP POST forespørsler for å legge til nye kunder
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Add(Kunde kunde)
        {
            await kundeRepository.AddAsync(kunde);

            return RedirectToAction("List");
        }
        
        //Håndterer HTTP GET forespørsler for å liste ut alle kunder
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var kunder = await kundeRepository.GetAllAsync();

            return View(kunder);
        }

        //Håndterer HTTP POST forespørsler for sletting av kunder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Kunde kunde)
        {
            var deletedKunde = await kundeRepository.DeleteAsync(kunde.ID);

            if (deletedKunde != null)
            {   
                //Sucess notification
                return RedirectToAction("List");
            }

            return View(null);
        }

        //Håndterer HTTP GET forespørsler for å hente ut en kunde til Edit viewt
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {    
            var kunde = await kundeRepository.GetAsync(id);

            if (kunde != null)
            {   
                //Sucess notifictaion
                return View(kunde);
            }

            //Error notification
            return View(null);
        }


        //Håndterer HTTP GET forespørsler for søk av kunder
        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            var kunder = await kundeRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                kunder = kunder.Where(kunde => kunde.Telefon.Contains(searchString));
            }

            return View("List", kunder);
        }


        //Håndterer HTTP POST forespørsler for oppdatering av kunder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Kunde kunde)
        {
            var UpdatedKunde = await kundeRepository.UpdateAsync(kunde);

            if (UpdatedKunde != null)
            {
                //sucess notification
                return RedirectToAction("List");
            }

            //error notification
            return View(null);
        }
    }
}
