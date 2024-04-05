using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using System.Security.Claims;

namespace RentiSI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RevisionController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public RevisionController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_contenedorTrabajo.Tramite.GetAll(r => r.Impronta != null));

        }

        [HttpGet]
        public IActionResult ConsultarPorPlaca(string Placa)
        {
            return View(_contenedorTrabajo.Tramite.GetAll(r => r.NumeroPlaca == Placa));

        }


    }
}
