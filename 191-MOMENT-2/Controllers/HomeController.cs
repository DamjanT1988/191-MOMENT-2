using _191_MOMENT_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _191_MOMENT_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //--VIEWS AND ROUTES

        //control route
        [Route("/")]
        //to page/view
        public IActionResult Index()
        {
            return View();
        }

        [Route("/add")]
        //to page/view
        public IActionResult Add()
        {
            return View();
        }

        [Route("/edit")]
        //to page/view
        public IActionResult Edit()
        {
            return View();
        }

        //--ERROR MANAGEMENT

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}