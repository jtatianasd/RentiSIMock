using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        public GestionImprontaController(IContenedorTrabajo contenedorTrabajo, UserManager<ApplicationUser> userManager)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet()]
        public IActionResult Create(int? id)
        {
            ImprontaVM improntaVM = new ImprontaVM()
            {

                Tramite = new RentiSI.Modelos.Tramite(),
                Recepcion = new RentiSI.Modelos.Recepcion(),
                Impronta = new RentiSI.Modelos.Impronta(),
                TramiteCasuistica = new RentiSI.Modelos.TramiteCasuistica(),
                ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("GESTION_IMPRONTAS"),
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito(),
                SelectedCasuisticasIds = new int[] { }
            };
            if (id != null)
            {
                improntaVM.Tramite = _contenedorTrabajo.Tramite.Get(id.GetValueOrDefault());
            }

            return View(improntaVM);
        }
        [HttpPost]
        public IActionResult Create(ImprontaVM improntaVM)
        {
            improntaVM.Impronta.Id_Tramite = improntaVM.Tramite.Id;
            if (ModelState.IsValid)
            {
                if (improntaVM.Impronta.EsResuelto.Equals("true"))
                {
                    improntaVM.Impronta.FechaResultadoImpronta = DateTime.Now;
                    improntaVM.Impronta.IdUsuarioResuelveImpronta = _userManager.GetUserId(User);
                }

                _contenedorTrabajo.GestionImpronta.Add(improntaVM.Impronta);
                _contenedorTrabajo.Save();
                if (improntaVM.SelectedCasuisticasIds != null)
                {
                    foreach (var casuisticaId in improntaVM.SelectedCasuisticasIds)
                    {
                        _contenedorTrabajo.TramiteCasuistica.Add(new TramiteCasuistica()
                        {
                            ImprontaId = improntaVM.Impronta.ImprontaId,
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

        [HttpGet("/Operativo/GestionImpronta/Edit/{id}")]
        public IActionResult Edit(int? id)
        {
            ImprontaVM improntaVM = new ImprontaVM()
            {
                Tramite = new Tramite(),
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito(),
                ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("GESTION_IMPRONTAS"),
                SelectedCasuisticasIds = _contenedorTrabajo.TramiteCasuistica.GetAll(impronta => impronta.ImprontaId == id)
                                                 .Select(impronta => impronta.CasuisticaId)
                                                 .ToArray()
            };
            if (id != null)
            {
                var result = _contenedorTrabajo.GestionImpronta.ObtenerImprontasPorId(id.GetValueOrDefault());
                foreach (var item in result)
                {
                    improntaVM.Tramite = item.Tramite;
                    improntaVM.Impronta = item.Impronta;
                }
            }

            return View(improntaVM);
        }
        public IActionResult Edit(ImprontaVM improntaVM)
        {
            if (ModelState.IsValid)
            {
                if (improntaVM.Impronta.EsResuelto.Equals("true"))
                {
                    improntaVM.Impronta.FechaResultadoImpronta = DateTime.Now;
                    improntaVM.Impronta.IdUsuarioResuelveImpronta = _userManager.GetUserId(User);
                }
                else
                {
                    improntaVM.Impronta.FechaResultadoImpronta = DateTime.MinValue;
                    improntaVM.Impronta.IdUsuarioResuelveImpronta = null;
                }
                _contenedorTrabajo.GestionImpronta.Actualizar(improntaVM);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            improntaVM.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
            improntaVM.ListaCasuisticas = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuistica();
            return View(improntaVM);
        }
    }
}
