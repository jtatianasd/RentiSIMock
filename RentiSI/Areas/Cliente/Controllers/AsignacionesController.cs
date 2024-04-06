using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;

namespace RentiSI.Areas.Cliente.Controllers
{
    [Authorize(Roles = "Cliente")]
    [Area("Cliente")]
    public class AsignacionesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public AsignacionesController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tramite tramite)
        {
            if (ModelState.IsValid)
            {
                if (!_contenedorTrabajo.Asignacion.ExistePlaca(tramite.NumeroPlaca)) 
                {
                    _contenedorTrabajo.Asignacion.Add(tramite);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return View(ModelState);
            }
            return View(tramite);
        }
    }
}
