using Microsoft.AspNetCore.Mvc;
using Nsted.Models;
using System.Linq;
using System.Text.Encodings.Web;

namespace Nsted.Controllers
{

    public class ServiceController : Controller
    {


        private readonly NstedDbContext _context;

        public ServiceController(NstedDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(OpprettService service)
        {
            if (ModelState.IsValid)
            {
                _context.Servicer.Add(service);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(service);
        }
        public IActionResult List()
        {
            return View(_context.Servicer.ToList());
        }
    }
}