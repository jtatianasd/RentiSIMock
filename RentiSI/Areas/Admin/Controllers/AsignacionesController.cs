using Microsoft.AspNetCore.Mvc;

namespace RentiSI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AsignacionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
