using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Areas.Cliente.Controllers;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using RentiSI.Utilidades;

namespace RentiSI.Areas.Coordinador.Controllers
{
    [Area("Coordinador")]
    public class RecepcionController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly UserManager<ApplicationUser> _userManager;

        private ErrorLog errorLog = new ErrorLog();

        public RecepcionController(IContenedorTrabajo contenedorTrabajo, UserManager<ApplicationUser> userManager)
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
            return Json(new { data = _contenedorTrabajo.Recepcion.ObtenerRecepciones() });

        }

        [HttpGet("/Coordinador/Recepcion/Edit/{recepcionId}")]
        public IActionResult Edit(int recepcionId)
        {
            var recepciones = _contenedorTrabajo.Recepcion.ObtenerRecepcionesPorId(recepcionId);
            if (recepciones != null)
            {
                recepciones.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
            }
            return View(recepciones);
        }

        [HttpPost]
        public IActionResult Update(ResponseViewModel responseViewModel)
        {
            try
            {

                var recepcion = _contenedorTrabajo.Recepcion.GetAll(recepcion => recepcion.RecepcionId == responseViewModel.Recepcion.RecepcionId).FirstOrDefault();
                if (recepcion != null)
                {
                    recepcion.Observacion = responseViewModel.Recepcion.Observacion;
                    recepcion.FechaRecepcion = DateTime.Now;
                    recepcion.IdUsuarioRecepcion = _userManager.GetUserId(User);
                    recepcion.EsRecepcion = responseViewModel.Recepcion.EsRecepcion;

                    _contenedorTrabajo.Recepcion.Actualizar(recepcion);
                }
            }
            catch (Exception ex)
            {

                errorLog.RegistrarError(ex.Message, nameof(RecepcionController));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Create(ResponseViewModel responseViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    responseViewModel.Recepcion.FechaRecepcion = DateTime.Now;
                    responseViewModel.Recepcion.IdUsuarioRecepcion = _userManager.GetUserId(User);
                    responseViewModel.Recepcion.Id_Tramite = responseViewModel.Tramite.Id;
                    _contenedorTrabajo.Recepcion.Add(responseViewModel.Recepcion);
                    _contenedorTrabajo.Save();
                }

            }
            catch (Exception ex)
            {
                errorLog.RegistrarError(ex.Message, nameof(RecepcionController));
            }

            return RedirectToAction(nameof(Index));

        }

        [HttpGet("/Coordinador/Recepcion/Create/{tramiteId}")]
        public IActionResult Create(int tramiteId)
        {
            var tramite = _contenedorTrabajo.Tramite.Get(tramiteId);
            ResponseViewModel responseViewModel = new ResponseViewModel()
            {
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito(),
                Tramite = tramite,
                FechaAsignacion = tramite.FechaCreacion.Value.ToString("dd-MM-yyyy")
            };

            return View(responseViewModel);
        }
    }
}
