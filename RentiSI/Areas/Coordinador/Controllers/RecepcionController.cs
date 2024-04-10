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
            if (!string.IsNullOrEmpty(recepciones.FechaRecepcion))
            {
                recepciones.EsFechaRecepcion = true;
            }
            return View(recepciones);
        }

        [HttpPost]
        public IActionResult Update(ResponseViewModel responseViewModel)
        {

            if(responseViewModel.EsFechaRecepcion)
            {
                var recepcion = _contenedorTrabajo.Recepcion.GetAll(recepcion => recepcion.Id == responseViewModel.RecepcionId).FirstOrDefault();
                if(recepcion != null)
                {
                    recepcion.Observacion = responseViewModel.Observacion;
                    recepcion.FechaRecepcion = DateTime.Now.ToString("dd-MM-yyyy");
                    recepcion.IdUsuarioRecepcion = _userManager.GetUserId(User);

                    _contenedorTrabajo.Recepcion.Actualizar(recepcion);
                }

            }

            return RedirectToAction(nameof(Index));
        }




    }
}
