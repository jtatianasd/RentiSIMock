using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using System.Security.Claims;

namespace RentiSI.Areas.Coordinador.Controllers
{
    [Area("Coordinador")]
    public class RecepcionController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public RecepcionController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var recepciones = _contenedorTrabajo.Recepcion.ObtenerRecepciones();

            return View(recepciones);

        }

        [HttpGet]
        public IActionResult ConsultarPorPlaca(string Placa)
        {
            return View(_contenedorTrabajo.Tramite.GetAll(r => r.NumeroPlaca == Placa));

        }

        [HttpGet("/Coordinador/Recepcion/Edit/{recepcionId}")]
        public IActionResult Edit(int recepcionId)
        {
            var recepciones = _contenedorTrabajo.Recepcion.ObtenerRecepcionesPorId(recepcionId);
            return View(recepciones);
        }


    }
}
