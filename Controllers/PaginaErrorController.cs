using Microsoft.AspNetCore.Mvc;

namespace MiProgressApp.Controllers
{
    public class PaginaErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
