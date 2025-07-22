using Microsoft.AspNetCore.Mvc;
namespace Projet_5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
