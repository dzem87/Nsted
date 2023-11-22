using Microsoft.AspNetCore.Mvc;
using Nsted.Models;
using Nsted.Repositories;

namespace Nsted.Controllers
{
    public class SjekklisteController : Controller
    {
        private readonly ISjekklisteRepository sjekklisteRepository;

        public SjekklisteController(ISjekklisteRepository sjekklisteRepository)
        {
            this.sjekklisteRepository = sjekklisteRepository;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Sjekkliste sjekkliste)
        {
            await sjekklisteRepository.AddAsync(sjekkliste);

            //redirect to the list page
            return View(sjekkliste);
        }
    }
}
