using Microsoft.AspNetCore.Mvc;
using Nsted.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Text.Encodings.Web;
using Nsted.Interfaces;

//Kontroller som bruker KundeRepository for å kommunisere med Kunder tabllen i databasen
//og inneholder metoder for å 
//som tar imot ulike HTTP requests fra views og bruker KundeRepository
//for å kommunisere med Kunder tabellen i databasen


namespace Nsted.Controllers
{

    //Alle metoder i kontrolleren krever autorisasjon
    [Authorize]
    public class KundeController : Controller
    {

        private readonly IKundeRepository kundeRepository;
        
        public KundeController(IKundeRepository kundeRepository)
        {
            this.kundeRepository = kundeRepository;
        }

       
        //Returnerer et view for å legge til nye kunder
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Add(Kunde kunde)
        {
            await kundeRepository.AddAsync(kunde);

            //redirect to the list page
            return RedirectToAction("List");
        }
        
        [HttpGet]
        public async Task<IActionResult> List()
        {

            var kunder = await kundeRepository.GetAllAsync();

            return View(kunder);
        }

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

            //Show an error notification if Kunde is not found
            //Finne en bedre måte å vise error på
            return View(null);
        }

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
