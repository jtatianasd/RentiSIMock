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
                var usuario =  await _userManager.FindByIdAsync(usuarioVM.Usuario.Id);
                if (usuario != null)
                {

                    if (usuarioVM.Usuario.PasswordHash != null)
                    {
                        result = await _userManager.ChangePasswordAsync(usuario, usuario.PasswordHash, usuarioVM.Usuario.PasswordHash);

                    }

                    var rol = ObtenerRoles(usuarioVM.Usuario.Id).Result;

                    var respuestaEliminarRol = await RemoveRoleFromUserAsync(usuario, rol.FirstOrDefault());
                    if (respuestaEliminarRol)
                    {
                        await AgregarRol(usuario, usuarioVM.Rol);
                    }

                    usuario.Nombre = usuarioVM.Usuario.Nombre;
                    usuario.UserName = usuarioVM.Usuario.UserName;
                    usuario.Email = usuarioVM.Usuario.Email;
                    var resultado =  await _userManager.UpdateAsync(usuario);
                    if (resultado.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }

            return View();
        }

        private async Task<IList<string>> ObtenerRoles(string usuarioId)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioId);
            return await _userManager.GetRolesAsync(usuario);
        }
        private async Task<bool> RemoveRoleFromUserAsync(ApplicationUser usuarioId, string rol)
        {
            var result = await _userManager.RemoveFromRoleAsync(usuarioId, rol);
            return result.Succeeded;

         }


         private async Task<bool> AgregarRol(ApplicationUser usuario, string rol)
         {
             var resultado = await _userManager.AddToRoleAsync(usuario, rol);
             return resultado.Succeeded;
        }


    }
}
