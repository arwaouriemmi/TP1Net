using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Data.SQLite;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using WebApplication4.Models;
using static System.Net.Mime.MediaTypeNames;


namespace WebApplication4.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PersonController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
        public IActionResult Index(int id)
        {
            List<Person> l = (new Personal_info()).GetPerson(id);

            return View(l);
        }
        [HttpGet]
        public IActionResult search()
        {
            ViewBag.notFound = false;
            return View();
        }
        [HttpPost]
        public RedirectToActionResult search(Person p)
        {
            Personal_info pi= new Personal_info();
            int id = pi.trouvePerson(p.first_name, p.country);
          
         
                
                return RedirectToAction("Index", "Person", new { id = id });
            
            
        }
      
        public IActionResult All()
        {
            List<Person> l = (new Personal_info()).GetAllPerson();
            return View(l);
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
