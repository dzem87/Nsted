﻿using Microsoft.AspNetCore.Mvc;
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
        
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var sjekklister = await sjekklisteRepository.GetAllAsync();

            return View(sjekklister);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            var sjekklister = await sjekklisteRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                sjekklister = sjekklister.Where(kunde => kunde.Serienummer.Contains(searchString));
            }

            return View("List", sjekklister);
        }
    }
}
