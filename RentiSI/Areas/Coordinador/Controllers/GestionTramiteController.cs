using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using System.Security.Claims;

namespace RentiSI.Areas.Coordinador.Controllers
{
    [Area("Coordinador")]
    public class GestionTramiteController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public GestionTramiteController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Tramite.GetAll() });
        }

        [HttpGet("/Operativo/GestionTramite/Edit/{revisionId}")]
        public IActionResult Edit(int revisionId)
        {
            var recepciones = _contenedorTrabajo.Revision.ObtenerRevisionesPorId(revisionId);
            return View(recepciones);
        }

    }
}
