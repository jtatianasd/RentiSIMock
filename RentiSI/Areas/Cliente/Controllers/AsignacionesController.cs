using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentiSI.Areas.Cliente.Controllers
{
    [Authorize(Roles = "Cliente, Administrador")]
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
            TramiteVM tramiteVM = new TramiteVM()
            {
                Tramite = new RentiSI.Modelos.Tramite(),
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito()
            };
            return View(tramiteVM);
        }
        [HttpPost]
        public IActionResult Create(TramiteVM tramiteVM)
        {
            if (ModelState.IsValid)
            {
                tramiteVM.Tramite.FechaCreacion = DateTime.Now.ToShortDateString();
                if (!_contenedorTrabajo.Asignacion.ExistePlaca(tramiteVM.Tramite.NumeroPlaca))
                {
                    _contenedorTrabajo.Asignacion.Add(tramiteVM.Tramite);
                    _contenedorTrabajo.Save();

                    //Se crea el trámite en la recepción
                    saveRecepcion(tramiteVM.Tramite.Id);

                    return RedirectToAction(nameof(Index));
                }
            }
            tramiteVM.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
            return View(tramiteVM);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Asignacion.GetAll(includeProperties: "OrganismosDeTransito") });
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            TramiteVM tramiteVM = new TramiteVM()
            {
                Tramite = new RentiSI.Modelos.Tramite(),
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito()
            };

            if (id != null)
            {
                tramiteVM.Tramite = _contenedorTrabajo.Tramite.Get(id.GetValueOrDefault());
            }

            return View(tramiteVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TramiteVM tramiteVM)
        {
            if (ModelState.IsValid)
            {
                //Logica para actualizar en BD
                _contenedorTrabajo.Asignacion.Update(tramiteVM.Tramite);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            tramiteVM.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
            return View(tramiteVM);
        }

        private void saveRecepcion(int tramiteId)
        {
            _contenedorTrabajo.Recepcion.Add(
                       new Recepcion()
                       {
                           Id_Tramite = tramiteId
                       });

            _contenedorTrabajo.Save();
        }
    }
}
