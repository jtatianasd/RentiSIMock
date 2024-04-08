using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using System.Security.Claims;

namespace RentiSI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TramitesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public TramitesController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_contenedorTrabajo.Tramite.GetAll());
           
        }


    }
}
