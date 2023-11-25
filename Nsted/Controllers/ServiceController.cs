using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nsted.Interfaces;
using Nsted.Models;
using System.Linq;
using System.Text.Encodings.Web;

namespace Nsted.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {

        //Constructor for repository
        private readonly IServiceRepository serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            
            this.serviceRepository = serviceRepository;
        }


        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Service service)
        {
            await serviceRepository.AddAsync(service);

            //redirect to the list page
            return RedirectToAction("List");
        }
        public async Task<IActionResult> List()
        {
            var servicer = await serviceRepository.GetAllAsync();

            return View(servicer);
        }

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

        //Hvordan fungerer id parameteren her?
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