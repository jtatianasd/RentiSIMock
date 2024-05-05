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

        [HttpPost]
        public IActionResult Edit(ResponseViewModel responseViewModel)
        {
            if (ModelState.IsValid)
            {
                var gestionTramite = _contenedorTrabajo.GestionTramite.GetAll(gestion => gestion.GestionId == responseViewModel.GestionTramite.GestionId).FirstOrDefault();
                if (gestionTramite != null)
                {

                    if(!EsTramiteFinalizado(responseViewModel))
                    {
                        gestionTramite.EsReasignacion = true;
                    }
                   
                    gestionTramite.IdUsuarioGestion = _userManager.GetUserId(User);
                    gestionTramite.Observacion = responseViewModel.GestionTramite.Observacion;
                    gestionTramite.EsGestionTramite = responseViewModel.GestionTramite.EsGestionTramite;
                    gestionTramite.IdDetalleEstado = responseViewModel.GestionTramite.IdDetalleEstado;
                    gestionTramite.FechaResultado = responseViewModel.GestionTramite.FechaResultado = DateTime.Now;

                    InsertarCasuistica(responseViewModel);

                    _contenedorTrabajo.GestionTramite.Actualizar(gestionTramite);

                }

                return RedirectToAction(nameof(Index));
            }

            var responView = ObtenerDatosVistaEditar(responseViewModel.GestionTramite.GestionId);
            return View(responView);

        }



        [HttpGet("/Coordinador/GestionTramite/Create/{tramiteId}")]
        public IActionResult Create(int tramiteId)
        {
            return View(ObtenerDatosVistaCrear(tramiteId));
        }

        [HttpPost]
        public IActionResult Create(ResponseViewModel responseViewModel)
        {

            if (ModelState.IsValid)
            {
                if (responseViewModel.GestionTramite.EsGestionTramite)
                {
                    responseViewModel.GestionTramite.FechaResultado = DateTime.Now;
                }

                if (!EsTramiteFinalizado(responseViewModel))
                {
                    responseViewModel.GestionTramite.EsReasignacion = true;
                }

                responseViewModel.GestionTramite.IdUsuarioGestion = _userManager.GetUserId(User);
                responseViewModel.GestionTramite.Id_Tramite = responseViewModel.Tramite.Id;
                _contenedorTrabajo.GestionTramite.Add(responseViewModel.GestionTramite);

                _contenedorTrabajo.Save();

                InsertarCasuistica(responseViewModel);
                return RedirectToAction(nameof(Index));

            }


            responseViewModel = ObtenerDatosVistaCrear(responseViewModel.Tramite.Id);

            return View(responseViewModel);


        }

        
        private void InsertarCasuistica(ResponseViewModel responseViewModel)
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

            if (responseViewModel.SelectedCasuisticasIds != null)
            {
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

        private ResponseViewModel ObtenerDatosVistaCrear(int TramiteId)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel()
            {
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito(),
                Tramite = _contenedorTrabajo.Tramite.Get(TramiteId),
                ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("REVISION_GESTION_TRAMITES"),
                TipoDetalleEstado = _contenedorTrabajo.TipoRechazo.GetListaTipoRechazo()

            };

            return responseViewModel;

        }

        private ResponseViewModel ObtenerDatosVistaEditar(int GestioinId)
        {

            var gestionTramites = _contenedorTrabajo.GestionTramite.ObtenerGestionesTramitesPorId(GestioinId);
            if (gestionTramites != null)
            {
                gestionTramites.TipoDetalleEstado = _contenedorTrabajo.TipoRechazo.GetListaTipoRechazo();
                gestionTramites.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
                gestionTramites.ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("REVISION_GESTION_TRAMITES");
                gestionTramites.SelectedCasuisticasIds = _contenedorTrabajo.GestionCasuistica.GetAll(gestionCasuistica => gestionCasuistica.GestionId == GestioinId)
                                                     .Select(gestionCasuistica => gestionCasuistica.CasuisticaId)
                                                     .ToArray();
            }

            return gestionTramites;
        }

        private bool EsTramiteFinalizado(ResponseViewModel responseViewModel)
        {
            return responseViewModel.GestionTramite.IdDetalleEstado == 13;
        }


    }
}
