using _191_MOMENT_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _191_MOMENT_2.Controllers
{
    //use controlles base class from AspNetCore library
    public class HomeController : Controller
    {
        //--CONSTRUCTORS
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/



        //--VIEWS AND ROUTES

        //control route directly with [Route]
        //name same view folder as controller name standard = Home -> Home, then no
        //specification is needed
        [Route("/")]
        //to page/view
        public IActionResult Index()
        {
            //must return av view
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