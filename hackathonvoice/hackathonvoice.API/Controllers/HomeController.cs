using Microsoft.AspNetCore.Mvc;

namespace hackathonvoice.API.Controllers
{
    public class HomeController : Controller
    {
        /// <summary/>
        [HttpGet]
        [Route("{*catchall}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}