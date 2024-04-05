using Microsoft.AspNetCore.Mvc;

namespace RentiSI.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class AsignacionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
