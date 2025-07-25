using Microsoft.AspNetCore.Mvc;
namespace Projet_5.Controllers
{
    public class HomeController : Controller
    {
        // Ce controller sert à centraliser la gestion des erreurs pour renvoyer vers la bonne view, ça évite de polluer les autres controllers
        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
