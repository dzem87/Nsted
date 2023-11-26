using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nsted.Interfaces;
using Nsted.Models;

namespace Nsted.Controllers
{
    //Kontroller som kommuniserer med SjekklisteRepository
    [Authorize]
    public class SjekklisteController : Controller
    {
        //Konstrukrø for repository som bruker ISjekklisteRepository som en instans
        private readonly ISjekklisteRepository sjekklisteRepository;

        public SjekklisteController(ISjekklisteRepository sjekklisteRepository)
        {
            this.sjekklisteRepository = sjekklisteRepository;
        }

        //Add-metode som returenrer et view
        public IActionResult Add()
        {
            return View();
        }

        //Add-metode for å håndtere skjemaet for å legge til en ny Sjekkliste (HTTP POST)
        // await som gjør et kall på metode i repository for å asynkront legge til en ny Sjekkliste
        // Return som gjør en omdirigering til listen etter en Sjekkliste er lagt til
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Sjekkliste sjekkliste)
        {
            await sjekklisteRepository.AddAsync(sjekkliste);
            
            return RedirectToAction("List");
        }
        
        //List-metode for å vise liste over sjekklister
        //Metodekall i repository for å asynkront hente alle Sjekklister
        //Return som lister de hentede Sjekklister til visningen
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var sjekklister = await sjekklisteRepository.GetAllAsync();
            
            return View(sjekklister);
        }

        //Metode for å vise redigeringsvisningen for en spesifikk Sjekkliste
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var sjekkliste = await sjekklisteRepository.GetAsync(id);

            if (sjekkliste != null)
            {   
                //Sucess notifictaion
                return View(sjekkliste);
            }

            //Error notification
            return View(null);
        }

        //Metode som viser redigeringsvisning for en spesifikk sjekkliste 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Sjekkliste sjekkliste)
        {
            var UpdatedSjekkliste = await sjekklisteRepository.UpdateAsync(sjekkliste);

            if (UpdatedSjekkliste != null)
            {
                //sucess notification
                return RedirectToAction("List");
            }

            //error notification
            return View(null);
        }

        //Tar imot en instans av Sjekkliste, henter informasjon fra SjekklisteRepository for å slette barest på ID. Omdirigerer til view List
        public async Task<IActionResult> Delete(Sjekkliste sjekkliste)
        {
            var deletedSjekkliste = await sjekklisteRepository.DeleteAsync(sjekkliste.Id);

            if (deletedSjekkliste != null)
            {   
                //Sucess notification
                return RedirectToAction("List");
            }

            //Show an error notification if Sjekkliste is not found
            //Finne en bedre måte å vise error på
            return View(null);
        }

        //Hånderer visning for gitt søkeresultat, viser bare relevante søkeresultat
        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            var sjekklister = await sjekklisteRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //Filtrerer Sjekklister basert på søkestrengen
                sjekklister = sjekklister.Where(kunde => kunde.Serienummer.Contains(searchString));
            }

            //Returner listen med filtrerte Sjekklister til visningen
            return View("List", sjekklister);
        }
    }
}
