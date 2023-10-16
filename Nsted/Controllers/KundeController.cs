using Microsoft.AspNetCore.Mvc;
using Nsted.Models;
using System.Linq;

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
    }
}
