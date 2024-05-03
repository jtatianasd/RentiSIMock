using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.AccesoDatos.Migrations;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RentiSI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Area("Admin")]
    public class UsuariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly UserManager<ApplicationUser> _userManager;

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
            UsuarioVM usuarioVM = new UsuarioVM()
            {
                Usuario = user
            };

            return View(usuarioVM);
        }
        [HttpGet]
        public async Task<IActionResult> EditRol(string id)
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

            RolVM rolVM = new RolVM()
            {
                Usuario = user,
                Rol = roles.FirstOrDefault()
            };

            return View(rolVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioVM usuarioVM)
        {
            if (ModelState.IsValid)
            {
               
                var usuario =  await _userManager.FindByIdAsync(usuarioVM.Usuario.Id);
                if (usuario != null)
                {
                    var newPasswordHash = _contenedorTrabajo.Usuario.HashPassword(usuarioVM.Password);
                    usuario.PasswordHash = newPasswordHash;
                    var resultado= await _userManager.UpdateAsync(usuario);

                    if (resultado.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditRol(RolVM rolVM)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByIdAsync(rolVM.Usuario.Id);
                if (usuario != null)
                {
                    var rol = ObtenerRoles(rolVM.Usuario.Id).Result;

                    var respuestaEliminarRol = await RemoveRoleFromUserAsync(usuario, rol.FirstOrDefault());
                    if (respuestaEliminarRol)
                    {
                        await AgregarRol(usuario, rolVM.Rol);
                    }

                    usuario.Nombre = rolVM.Usuario.Nombre;
                    usuario.Email = rolVM.Usuario.Email;
                    var resultado = await _userManager.UpdateAsync(usuario);
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
