using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using System.Security.Claims;

namespace RentiSI.Areas.Coordinador.Controllers
{
    [Area("Coordinador")]
    public class GestionTramiteController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly UserManager<ApplicationUser> _userManager;

        public GestionTramiteController(IContenedorTrabajo contenedorTrabajo, UserManager<ApplicationUser> userManager)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.GestionTramite.ObtenerGestionesTramites() });
        }

        [HttpGet("/Coordinador/GestionTramite/Edit/{gestionId}")]
        public IActionResult Edit(int gestionId)
        {
            var gestionTramites = _contenedorTrabajo.GestionTramite.ObtenerGestionesTramitesPorId(gestionId);
            if (gestionTramites != null)
            {
                gestionTramites.TipoDetalleEstado = _contenedorTrabajo.TipoRechazo.GetListaTipoRechazo();
                gestionTramites.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
                gestionTramites.ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("REVISION_GESTION_TRAMITES");
                gestionTramites.SelectedCasuisticasIds = _contenedorTrabajo.GestionCasuistica.GetAll(gestionCasuistica => gestionCasuistica.GestionId == gestionId)
                                                     .Select(gestionCasuistica => gestionCasuistica.CasuisticaId)
                                                     .ToArray();
            }

            return View(gestionTramites);
        }



        [HttpGet("/Coordinador/GestionTramite/Create/{tramiteId}")]
        public IActionResult Create(int tramiteId)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel()
            {
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito(),
                Tramite = _contenedorTrabajo.Tramite.Get(tramiteId),
                ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("REVISION_GESTION_TRAMITES"),
                TipoDetalleEstado = _contenedorTrabajo.TipoRechazo.GetListaTipoRechazo()

            };

            return View(responseViewModel);
        }

        [HttpPost]
        public IActionResult Create(ResponseViewModel responseViewModel)
        {
            if (!ModelState.IsValid)
            {
                responseViewModel.GestionTramite.FechaResultado = DateTime.Now;
                responseViewModel.GestionTramite.IdUsuarioGestion = _userManager.GetUserId(User);
            }

            responseViewModel.GestionTramite.Id_Tramite = responseViewModel.Tramite.Id;
            _contenedorTrabajo.GestionTramite.Add(responseViewModel.GestionTramite);

            _contenedorTrabajo.Save();

            InsertarCasuistica(responseViewModel);


            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public IActionResult Update(ResponseViewModel responseViewModel)
        {

            var gestionTramite = _contenedorTrabajo.GestionTramite.GetAll(gestion => gestion.GestionId == responseViewModel.GestionTramite.GestionId).FirstOrDefault();
            if (gestionTramite != null)
            {

                gestionTramite.IdUsuarioGestion = _userManager.GetUserId(User);
                gestionTramite.Observacion = responseViewModel.GestionTramite.Observacion;
                gestionTramite.EsGestionTramite = responseViewModel.GestionTramite.EsGestionTramite;
                gestionTramite.IdDetalleEstado = responseViewModel.GestionTramite.IdDetalleEstado;

                InsertarCasuistica(responseViewModel);

                _contenedorTrabajo.GestionTramite.Actualizar(gestionTramite);

            }

            return RedirectToAction(nameof(Index));


        }


        private void InsertarCasuistica(ResponseViewModel responseViewModel)
        {

            if (responseViewModel.SelectedCasuisticasIds != null)
            {

                if (responseViewModel.GestionTramite.GestionId != 0)
                {
                    var gestionCasuistica = _contenedorTrabajo.GestionCasuistica.
                                               GetAll(gestion => gestion.GestionId == responseViewModel.GestionTramite.GestionId).ToArray();

                    if (gestionCasuistica.Any())
                    {
                        //Se remueven antes de actualizarlos
                        _contenedorTrabajo.GestionCasuistica.RemoveRange(gestionCasuistica);
                        _contenedorTrabajo.Save();
                    }
                }

                foreach (var casuisticaId in responseViewModel.SelectedCasuisticasIds)
                {
                    _contenedorTrabajo.GestionCasuistica.Add(new GestionCasuistica()
                    {
                        GestionId = responseViewModel.GestionTramite.GestionId,
                        CasuisticaId = casuisticaId
                    });
                    _contenedorTrabajo.Save();
                }
            }
        }

    }
}
