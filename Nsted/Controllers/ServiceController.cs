﻿using Microsoft.AspNetCore.Mvc;
using Nsted.Models;
using Nsted.Repositories;
using System.Linq;
using System.Text.Encodings.Web;

namespace Nsted.Controllers
{

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