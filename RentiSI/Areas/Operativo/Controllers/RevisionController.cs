using Microsoft.AspNetCore.Identity;
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
       
            return Json(new { data = _contenedorTrabajo.Revision.ObtenerRevisiones() });
        }

        [HttpGet("/Operativo/Revision/Edit/{revisionId}")]
        public IActionResult Edit(int revisionId)
        {
            var recepciones = _contenedorTrabajo.Revision.ObtenerRevisionesPorId(revisionId);
            if (recepciones != null)
            {
                recepciones.ListaTipoTramite = _contenedorTrabajo.TipoTramite.GetListaTipoTramite();
                recepciones.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
                recepciones.ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("REVISION_GESTION_TRAMITES");
                recepciones.SelectedCasuisticasIds = _contenedorTrabajo.RevisionCasuistica.GetAll(revision => revision.RevisionId == revisionId)
                                                     .Select(revision => revision.CasuisticaId)
                                                     .ToArray();
            }
            return View(recepciones);
        }

        [HttpPost]
        public IActionResult Update(ResponseViewModel responseViewModel)
        {

            var revision = _contenedorTrabajo.Revision.GetAll(revision => revision.RevisionId == responseViewModel.Revision.RevisionId).FirstOrDefault();
            if (revision != null)
            {
                revision.FechaRevision = DateTime.Now.ToString("dd-MM-yyyy");
                revision.EsRevision = responseViewModel.Revision.EsRevision;
                revision.Observacion = responseViewModel.Revision.Observacion;
                revision.IdUsuarioRevision = _userManager.GetUserId(User);

                if (responseViewModel.SelectedCasuisticasIds.Any())
                {

                    var revisionCasuistica = _contenedorTrabajo.RevisionCasuistica.
                                               GetAll(revision => revision.RevisionId == responseViewModel.Revision.RevisionId).ToArray();

                    if(revisionCasuistica.Any())
                    {
                        //Se remueven antes de actualizarlos
                        _contenedorTrabajo.RevisionCasuistica.RemoveRange(revisionCasuistica);
                        _contenedorTrabajo.Save();
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

                _contenedorTrabajo.Revision.Actualizar(revision);

            }

            return RedirectToAction(nameof(Index));


        }

    }
}
