using Microsoft.AspNetCore.Mvc;
using Nsted.Models;
using System.Linq;
using System.Text.Encodings.Web;

namespace Nsted.Controllers
{

    public class KundeController : Controller
    {
        

        private readonly KundeContext _context;

        public KundeController(KundeContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Index(Kunde kunde)
        {
            if (ModelState.IsValid)
            {
                _context.Kunder.Add(kunde);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(kunde);
        }
        public IActionResult List()
        {
            return View(_context.Kunder.ToList());
        }

        public IActionResult Delete(int id)
        {
            var kunde = _context.Kunder.Find(id);

            if (kunde == null)
            {
                return NotFound(); // Eller en error side
            }

            _context.Kunder.Remove(kunde);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            var kunde = _context.Kunder.Find(id);

            if (kunde == null)
            {
                return NotFound(); // Or a suitable error page
            }

            return View(kunde);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Kunde kunde)
        {
            if (ModelState.IsValid)
            {
                _context.Kunder.Update(kunde);
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            return View(kunde);
        }
    }
}
