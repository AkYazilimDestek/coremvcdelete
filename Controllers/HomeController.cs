using DataSilmeCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataSilmeCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KisilerContext _context;
        public HomeController(ILogger<HomeController> logger, KisilerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.KisiListe = _context.Kisilers.ToList();
            return View();
        }

        [Route("/ajax/kisi/delete/{0}")]
        [HttpPost]
        public IActionResult KisiSilme()
        {
            int dataid = Convert.ToInt16(RouteData.Values["0"]);
            var gelendata = _context.Kisilers.Find(dataid);

            _context.Remove(gelendata);
            _context.SaveChanges();

            return Ok("true");
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}