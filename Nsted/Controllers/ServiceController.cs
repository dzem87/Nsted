using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nsted.Interfaces;
using Nsted.Models;
using System.Linq;
using System.Text.Encodings.Web;

namespace Nsted.Controllers
{
    //Kontroller som muliggjør CRUD operasjoner på servicer
    //Bruker IServiceRepository for å kommunisere med databasen
    //Bruker autorisasjon for å sikre at kun autoriserte brukere har tilgang til metodene


    [Authorize]
    public class ServiceController : Controller
    {

       
        private readonly IServiceRepository serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            //Dependencies
            this.serviceRepository = serviceRepository;
        }

        //Add-metode for å returnere et view 
        public IActionResult Add()
        {
            return View();
        }

        //Add metode som tar imot instanser fra Service og viser view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Service service)
        {
            await serviceRepository.AddAsync(service);

            //redirect to the list page
            return RedirectToAction("List");
        }

        //Henter alle ut all informasjon fra Servicer-tabellen, setter det i en variabel og returnerer dette til view 
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var servicer = await serviceRepository.GetAllAsync();

            return View(servicer);
        }

        //Tar imot en instans av Service, hetner informasjon fra ServiceRepository for å slette barest på ID. Omdirigerer til view List
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Service service)
        {
            var deletedService = await serviceRepository.DeleteAsync(service.ID);

            if (deletedService != null)
            {
                //Sucess notification
                return RedirectToAction("List");
            }

            //Show an error notification if Kunde is not found
            return View(null);
        }

        //Håndterer visingen for redigering basert på gitt id. Dersom den ikke er null blir edit viewet vist
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var service = await serviceRepository.GetAsync(id);

            if (service != null)
            {
                //Sucess notifictaion
                return View(service);
            }

            //Error notification
            return View(null);
        }

        //Håndeter visningen for et gitt søkeresultat, viser bare relevante søkeresultat 
        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            var service = await serviceRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                service = service.Where(service => service.Serienummer.Contains(searchString));
            }

            return View("List", service);
        }

        //Håndterer visningen for søkeresultatet basert på status. Filtrere etter status
        [HttpGet]
        public async Task<IActionResult> SearchStatus(string searchString)
        {
            var service = await serviceRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                service = service.Where(service => service.Status.Contains(searchString));
            }

            return View("List", service);
        }

        //Håndterer lagringen av endringer i tabellen etter redigering. Dersom den ikke er lik null blir viewet redirigert til List
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Service service)
        {
            var UpdatedService = await serviceRepository.UpdateAsync(service);

            if (UpdatedService != null)
            {
                //sucess notification
                return RedirectToAction("List");
            }

            //error notification
            return View(null);
        }
    }
}