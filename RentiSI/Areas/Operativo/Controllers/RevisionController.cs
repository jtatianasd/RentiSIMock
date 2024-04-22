﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using System.Security.Claims;

namespace RentiSI.Areas.Operativo.Controllers
{
    [Area("Operativo")]
    public class RevisionController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly UserManager<ApplicationUser> _userManager;

        public RevisionController(IContenedorTrabajo contenedorTrabajo, UserManager<ApplicationUser> userManager)
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
       
            return Json(new { data = _contenedorTrabajo.Revision.ObtenerRevisiones(_userManager.GetUserId(User))});
        }

        [HttpGet("/Operativo/Revision/Edit/{revisionId}")]
        public IActionResult Edit(int revisionId)
        {
            var revisiones = _contenedorTrabajo.Revision.ObtenerRevisionesPorId(revisionId);
            if (revisiones != null)
            {
                revisiones.ListaTipoTramite = _contenedorTrabajo.TipoTramite.GetListaTipoTramite();
                revisiones.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
                revisiones.ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("REVISION_GESTION_TRAMITES");
                revisiones.SelectedCasuisticasIds = _contenedorTrabajo.RevisionCasuistica.GetAll(revision => revision.RevisionId == revisionId)
                                                     .Select(revision => revision.CasuisticaId)
                                                     .ToArray();
                revisiones.Impronta = _contenedorTrabajo.GestionImpronta.GetAll(impronta => impronta.Id_Tramite == revisiones.Tramite.Id).FirstOrDefault();
            }
            return View(revisiones);
        }

        [HttpPost]
        public IActionResult Update(ResponseViewModel responseViewModel)
        {

            var revision = _contenedorTrabajo.Revision.GetAll(revision => revision.RevisionId == responseViewModel.Revision.RevisionId).FirstOrDefault();
            if (revision != null)
            {
                revision.FechaRevision = DateTime.Now;
                revision.EsRevision = responseViewModel.Revision.EsRevision;
                revision.Observacion = responseViewModel.Revision.Observacion;
                revision.IdUsuarioRevision = _userManager.GetUserId(User);
                revision.TipificacionTramiteRevision = responseViewModel.Revision.TipificacionTramiteRevision;
                revision.NumeroGuia = responseViewModel.Revision.NumeroGuia;

                InsertarRevisionCasuistica(responseViewModel);

                _contenedorTrabajo.Revision.Actualizar(revision);

            }

            return RedirectToAction(nameof(Index));


        }

        private void InsertarRevisionCasuistica(ResponseViewModel responseViewModel)
        {

            if (responseViewModel.SelectedCasuisticasIds != null)
            {

                if (responseViewModel.Revision.RevisionId != 0)
                {
                    var revisionCasuistica = _contenedorTrabajo.RevisionCasuistica.
                                               GetAll(revision => revision.RevisionId == responseViewModel.Revision.RevisionId).ToArray();

                    if (revisionCasuistica.Any())
                    {
                        //Se remueven antes de actualizarlos
                        _contenedorTrabajo.RevisionCasuistica.RemoveRange(revisionCasuistica);
                        _contenedorTrabajo.Save();
                    }
                }


                foreach (var casuisticaId in responseViewModel.SelectedCasuisticasIds)
                {
                    _contenedorTrabajo.RevisionCasuistica.Add(new RevisionCasuistica()
                    {
                        RevisionId = responseViewModel.Revision.RevisionId,
                        CasuisticaId = casuisticaId
                    });
                    _contenedorTrabajo.Save();
                }
            }
        }

    }
}
