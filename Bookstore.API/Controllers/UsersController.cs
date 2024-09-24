using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
