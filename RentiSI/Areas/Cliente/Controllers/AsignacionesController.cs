using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using System.Globalization;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentiSI.Areas.Cliente.Controllers
{
    [Authorize(Roles = "Cliente, Administrador")]
    [Area("Cliente")]
    public class AsignacionesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly UserManager<ApplicationUser> _userManager;
        public AsignacionesController(IContenedorTrabajo contenedorTrabajo, UserManager<ApplicationUser> userManager)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _userManager = userManager;
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
                tramiteVM.Tramite.FechaCreacion = DateTime.Now;
                tramiteVM.Tramite.IdUsuarioAsignacion = _userManager.GetUserId(User);
                string placaValida= _contenedorTrabajo.Asignacion.validarPlacas(tramiteVM.Tramite.NumeroPlaca);
                if(string.IsNullOrEmpty(placaValida))
                {
                    if (!_contenedorTrabajo.Asignacion.ExistePlaca(tramiteVM.Tramite.NumeroPlaca))
                    {
                        _contenedorTrabajo.Asignacion.Add(tramiteVM.Tramite);
                        _contenedorTrabajo.Save();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("Tramite.NumeroPlaca", "La placa ya existe");
                    }
                }
                else
                {
                    ModelState.AddModelError("Tramite.NumeroPlaca", placaValida);
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
                Tramite = new Tramite(),
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito()
            };

            if (id != null)
            {
                tramiteVM.Tramite = _contenedorTrabajo.Tramite.Get(id.GetValueOrDefault());
            }

            return View(tramiteVM);
        }

        [HttpPost]
        public IActionResult Edit(TramiteVM tramiteVM)
        {
            if (ModelState.IsValid)
            {
                tramiteVM.Tramite.IdUsuarioAsignacion = _userManager.GetUserId(User);

                //Logica para actualizar en BD
                _contenedorTrabajo.Asignacion.Actualizar(tramiteVM.Tramite);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            tramiteVM.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
            return View(tramiteVM);
        }
    }
}
