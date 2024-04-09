using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Index()
        {
            var recepciones = _contenedorTrabajo.Recepcion.ObtenerRecepciones();

            return View(recepciones);

        }

        [HttpGet]
        public IActionResult ConsultarPorPlaca(string Placa)
        {
            return View(_contenedorTrabajo.Tramite.GetAll(r => r.NumeroPlaca == Placa));

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
                var usuario = _userManager.GetUserId(User);


                var recepcion = _contenedorTrabajo.Recepcion.GetAll(recepcion => recepcion.Id == responseViewModel.RecepcionId).FirstOrDefault();
                recepcion.Observacion = responseViewModel.Observacion;
                recepcion.FechaRecepcion = DateTime.Now.ToString("yyy-MM-dd");
                recepcion.IdUsuarioRecepcion = usuario;

                _contenedorTrabajo.Recepcion.Actualizar(recepcion);

            }

            return RedirectToAction(nameof(Index));
        }




    }
}
