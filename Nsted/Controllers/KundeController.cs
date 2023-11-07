using Microsoft.AspNetCore.Mvc;
using Nsted.Models;
using Nsted.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Text.Encodings.Web;

namespace Nsted.Controllers
{


    public class KundeController : Controller
    {
        
        private readonly IKundeRepository kundeRepository;

        public KundeController(IKundeRepository kundeRepository)
        {
            this.kundeRepository = kundeRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Add(Kunde kunde)
        {
            await kundeRepository.AddAsync(kunde);

            //redirect to the list page
            return RedirectToAction("List");
        }
        public async Task<IActionResult> List()
        {
            var kunder = await kundeRepository.GetAllAsync();

            return View(kunder);
        }

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
