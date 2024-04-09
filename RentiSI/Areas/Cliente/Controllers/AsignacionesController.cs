using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tramite tramite)
        {
            tramite.FechaCreacion = DateTime.Now.ToShortDateString();
            if (ModelState.IsValid)
            {
                if (!_contenedorTrabajo.Asignacion.ExistePlaca(tramite.NumeroPlaca)) 
                {
                    _contenedorTrabajo.Asignacion.Add(tramite);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(tramite);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Asignacion.GetAll() });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Tramite tramite = new Tramite();
            tramite = _contenedorTrabajo.Asignacion.Get(id);
            if (tramite == null)
            {
                return NotFound();
            }

            return View(tramite);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tramite tramite)
        {
            if (ModelState.IsValid)
            {
                //Logica para actualizar en BD
                _contenedorTrabajo.Asignacion.Update(tramite);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(tramite);
        }
    }
}
