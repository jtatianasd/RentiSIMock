using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using System.Security.Claims;

namespace RentiSI.Areas.Operativo.Controllers
{
    [Area("Operativo")]
    public class GestionImprontaController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public GestionImprontaController(IContenedorTrabajo contenedorTrabajo)
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
            return Json(new { data = _contenedorTrabajo.GestionImpronta.ObtenerImprontas() });
        }

        [HttpGet("/Operativo/GestionImpronta/Edit/{revisionId}")]
        public IActionResult Edit(int revisionId)
        {
            var recepciones = _contenedorTrabajo.Revision.ObtenerRevisionesPorId(revisionId);
            return View(recepciones);
        }

    }
}
