using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RentiSI.AccesoDatos.Data.Repository;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using System.Security.Claims;

namespace RentiSI.Areas.Coordinador.Controllers
{
    [Area("Coordinador")]
    public class RecepcionController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly UserManager<ApplicationUser> _userManager;

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

            var recepcion = _contenedorTrabajo.Recepcion.GetAll(recepcion => recepcion.RecepcionId == responseViewModel.RecepcionId).FirstOrDefault();
            if (recepcion != null)
            {
                recepcion.Observacion = responseViewModel.Observacion;
                recepcion.FechaRecepcion = DateTime.Now.ToString("dd-MM-yyyy");
                recepcion.IdUsuarioRecepcion = _userManager.GetUserId(User);
                recepcion.EsRecepcion = responseViewModel.Recepcion.EsRecepcion;

                _contenedorTrabajo.Recepcion.Actualizar(recepcion);
            }



            return RedirectToAction(nameof(Index));
        }

        [HttpGet("/Coordinador/Recepcion/Create/{tramiteId}")]
        public IActionResult Create(int tramiteId)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel()
            {
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito(),
                Tramite = _contenedorTrabajo.Tramite.Get(tramiteId)
            };

            return View(responseViewModel);
        }




    }
}
