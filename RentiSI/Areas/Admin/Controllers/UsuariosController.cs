using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.AccesoDatos.Migrations;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;

namespace RentiSI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Area("Admin")]
    public class UsuariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<Role> _roleManager;

        public UsuariosController(IContenedorTrabajo contenedorTrabajo, UserManager<ApplicationUser> userManager)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_contenedorTrabajo.Usuario.GetAll());
        }

        [HttpGet]
        public IActionResult Bloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _contenedorTrabajo.Usuario.BloquearUsuario(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Desbloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _contenedorTrabajo.Usuario.DesbloquearUsuario(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            if (roles == null)
            {
                return NotFound();
            };

            UsuarioVM usuarioVM = new UsuarioVM()
            {
                Usuario = user,
                Rol = roles.FirstOrDefault()
            };

            return View(usuarioVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioVM usuarioVM)
        {
            IdentityResult result = default;

            if (ModelState.IsValid)
            {
                var user = _userManager.FindByIdAsync(usuarioVM.Usuario.Id);
                if (user != null)
                {

                    if (usuarioVM.Usuario.PasswordHash != null)
                    {
                        var token = await _userManager.GeneratePasswordResetTokenAsync(user.Result);
                        result = await _userManager.ResetPasswordAsync(user.Result, token, usuarioVM.Usuario.PasswordHash);

                    }

                    var rol = ObtenerRoles(usuarioVM.Usuario.Id).Result;

                    var respuestaEliminarRol = await RemoveRoleFromUserAsync(user, rol.FirstOrDefault());
                    if (respuestaEliminarRol)
                    {
                        await AgregarRol(user, usuarioVM.Rol);
                    }

                    user.Result.Nombre = usuarioVM.Usuario.Nombre;
                    user.Result.UserName = usuarioVM.Usuario.UserName;
                    var usuario = await _userManager.UpdateAsync(user.Result);
                    if (usuario.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }

            foreach (var campo in ModelState.Keys)
            {
                var erroresCampo = ModelState[campo].Errors;
                foreach (var error in erroresCampo)
                {
                    // Aquí puedes hacer lo que necesites con los errores, como registrarlos o mostrarlos en la vista
                    var mensajeError = error.ErrorMessage;
                    // Puedes hacer algo con el mensaje de error, como agregarlo a una lista para mostrar en la vista
                }
            }

            return View();
        }

        private async Task<IList<string>> ObtenerRoles(string usuarioId)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioId);
            return await _userManager.GetRolesAsync(usuario);
        }
        private async Task<bool> RemoveRoleFromUserAsync(Task<ApplicationUser>usuarioId, string rol)
        {
            var result = await _userManager.RemoveFromRoleAsync(usuarioId.Result, rol);
            return result.Succeeded;

         }


         private async Task<bool> AgregarRol(Task<ApplicationUser> usuario, string rol)
         {
             var resultado = await _userManager.AddToRoleAsync(usuario.Result, rol);
             return resultado.Succeeded;
        }


    }
}
