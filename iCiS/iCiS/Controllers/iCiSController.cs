using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


namespace iCiS.Controllers
{
    public class iCiSController : Controller
    {
        // GET: /iCiS/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /iCiS/bienvenido/
        public IActionResult Bienvenido(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
