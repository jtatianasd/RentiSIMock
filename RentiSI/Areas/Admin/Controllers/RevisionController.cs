using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
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
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var revisiones = _contenedorTrabajo.Revision.ObtenerRevisiones();

            return View(revisiones);

        }

        [HttpGet]
        public IActionResult ConsultarPorPlaca(string Placa)
        {
            return View(_contenedorTrabajo.Tramite.GetAll(r => r.NumeroPlaca == Placa));

        }


    }
}
