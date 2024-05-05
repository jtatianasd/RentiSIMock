using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Areas.Cliente.Controllers;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using RentiSI.Utilidades;

namespace RentiSI.Areas.Coordinador.Controllers
{
    [Area("Coordinador")]
    public class ReasignacionController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly UserManager<ApplicationUser> _userManager;

        private ErrorLog errorLog = new ErrorLog();

        public ReasignacionController(IContenedorTrabajo contenedorTrabajo, UserManager<ApplicationUser> userManager)
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
            return Json(new { data = _contenedorTrabajo.Reasignacion.ObtenerReasignaciones() });
        }

        [HttpGet("/Coordinador/Reasignacion/Create/{tramiteId}")]
        public IActionResult Create(int tramiteId)
        {
            return View(ObtenerDatosVistaCrear(tramiteId));
        }

        [HttpPost]
        public IActionResult Create(ReasignacionVM  reasignacionVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                 
                    reasignacionVM.Reasignacion.EsReasignado = true;
                    reasignacionVM.Reasignacion.FechaReasignacion = DateTime.Now;
                    reasignacionVM.Reasignacion.Id_Tramite = reasignacionVM.Tramite.Id;
                    reasignacionVM.Reasignacion.IdUsuarioReasignacion = _userManager.GetUserId(User);
                    _contenedorTrabajo.Reasignacion.Add(reasignacionVM.Reasignacion);


                    //Actualizar organismo tránsito
                    _contenedorTrabajo.Asignacion.ActualizarOrganismoTransito(reasignacionVM.Tramite);


                    //Actualizar usuario revisión
                    _contenedorTrabajo.Revision.ActualizarUsuarioRevision(reasignacionVM.Tramite.Id, reasignacionVM.Gestion.IdUsuarioGestion);


                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {

                errorLog.RegistrarError(ex.Message, nameof(AsignacionesController));
            }

            return View(ObtenerDatosVistaCrear(reasignacionVM.Tramite.Id));


        }

        private ReasignacionVM ObtenerDatosVistaCrear(int TramiteId)
        {

            var usuariosRole = _userManager.GetUsersInRoleAsync("Administrador").Result.ToList();
            var selectListItems = usuariosRole.Select(user => new SelectListItem
            {
                Text = user.Nombre,
                Value = user.Id
            });

            ReasignacionVM responseViewModel = new ReasignacionVM()
            {
                ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito(),
                Gestion = _contenedorTrabajo.GestionTramite.GetAll(gestion => gestion.Id_Tramite == TramiteId).FirstOrDefault(),
                ListaUsuarios = new UsariosRoles(_userManager).ObtenerUsuariosPorRol("Administrador"),
                Tramite = _contenedorTrabajo.Tramite.Get(TramiteId)
            };

            return responseViewModel;
        }
    }
}
