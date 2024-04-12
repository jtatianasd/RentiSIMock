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
        [HttpGet]
        public IActionResult Create()
        {

            ImprontaVM improntaVM = new ImprontaVM()
            {
                
                Tramite = new RentiSI.Modelos.Tramite(),  
                Recepcion= new RentiSI.Modelos.Recepcion(),
                Impronta = new RentiSI.Modelos.Impronta(),
                TramiteCasuistica = new RentiSI.Modelos.TramiteCasuistica(),
                ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("GESTION_IMPRONTAS"),
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito()
            };
           
            return View(improntaVM);
        }
        [HttpPost]
        public IActionResult Create(ImprontaVM improntaVM)
        {
            if (ModelState.IsValid)
            {

                    _contenedorTrabajo.GestionImpronta.Add(improntaVM.Impronta);
                    _contenedorTrabajo.Save();
                    foreach (var item in improntaVM.ListaCasuisticas)
                    {

                    }

                    return RedirectToAction(nameof(Index));
            }
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
