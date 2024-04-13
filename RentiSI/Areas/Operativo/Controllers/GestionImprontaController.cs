using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
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
        [HttpGet("/Operativo/GestionImpronta/Create/{data}")]
        public IActionResult Create(string data)
        {


            ImprontaVM improntaVM = new ImprontaVM()
            {

                Tramite = new RentiSI.Modelos.Tramite(),
                Recepcion = new RentiSI.Modelos.Recepcion(),
                Impronta = new RentiSI.Modelos.Impronta(),
                TramiteCasuistica = new RentiSI.Modelos.TramiteCasuistica(),
                ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("GESTION_IMPRONTAS"),
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito(),
                SelectedCasuisticasIds = new int[]{}
            };
           improntaVM.Tramite.NumeroPlaca = data;
            return View(improntaVM);
        }
        [HttpPost]
        public IActionResult Create(ImprontaVM improntaVM)
        {
            if (!ModelState.IsValid)
            {
              
                    _contenedorTrabajo.GestionImpronta.Add(improntaVM.Impronta);
                    _contenedorTrabajo.Save();
                    if (improntaVM.SelectedCasuisticasIds != null)
                    {
                        foreach (var casuisticaId in improntaVM.SelectedCasuisticasIds)
                        {
                            _contenedorTrabajo.TramiteCasuistica.Add(new TramiteCasuistica()
                            {
                                ImprontaId   = improntaVM.Impronta.ImprontaId,
                                CasuisticaId = casuisticaId
                            });
                         _contenedorTrabajo.Save();
                        }
                    }
                
                return RedirectToAction(nameof(Index));
            }
            improntaVM.ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuistica();
            improntaVM.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
            return View(improntaVM);
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Json(new { data = _contenedorTrabajo.GestionImpronta.ObtenerImprontas() });
        }

        [HttpGet("/Operativo/GestionImpronta/Edit/{gestionId}")]
        public IActionResult Edit(int gestionId)
        {
            var gestionImprontas = _contenedorTrabajo.GestionImpronta.ObtenerImprontasPorId(gestionId);
            if(gestionImprontas != null)
            {
                gestionImprontas.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
            }
          
            return View(gestionImprontas);
        }

    }
}
