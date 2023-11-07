using Microsoft.AspNetCore.Mvc;
using Nsted.Repositories;
using Nsted.Models;
using System.Linq;
using System.Text.Encodings.Web;


namespace Nsted.Controllers
{
    public class AnsattController : Controller
    {
        //constructor for the ansatt repository
        private readonly IAnsattRepository ansattRepository;

        public AnsattController(IAnsattRepository ansattRepository)
        {
            this.ansattRepository = ansattRepository;
        }

        public IActionResult Add()
        {
            return View();
        }

        //method that 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Ansatt ansatt)
        {

            //use repository to add an ansatt
            await ansattRepository.AddAsync(ansatt);

            //redirect to the List page
            return RedirectToAction("List");
        }

        //method responsilbe for retreving all entities from the database and presenting them in the view
        public async Task<IActionResult> List()
        {
            //use repository to read data from the database
            var ansatte = await ansattRepository.GetAllAsync();

            return View(ansatte);
        }

        //Method responsible retrieving a column in the database based on the primarykey
        [HttpGet]
        public async Task<IActionResult> Edit(int ansattNr)
        {
            var ansatt = await ansattRepository.GetAsync(ansattNr);

            
            if (ansatt != null)
            {
                //Sucess
                return View(ansatt);
            }

           
            return View(null);
        }

        //Method responsible editing a colum in the database
        [HttpPost]
        public async Task<IActionResult> Edit(Ansatt ansatt)
        {
           
            //using the repo to update the database
            var UpdatedAnsatt = await ansattRepository.UpdateAsync(ansatt);

            //check if the model is retrieved
            if (UpdatedAnsatt != null)
            {
                return RedirectToAction("List");
            }

            //show error notification
            return View(null);
        }
    }
}
