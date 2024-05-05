using Microsoft.AspNetCore.Identity;
using RentiSI.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentiSI.Utilidades
{
    public class UsariosRoles
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsariosRoles(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public IEnumerable<SelectListItem> ObtenerUsuariosPorRol(string Rol)
        {
           var usuariosRole = _userManager.GetUsersInRoleAsync(Rol).Result.ToList();
           var selectListItems =  usuariosRole.Select(user => new SelectListItem
            {
                Text = user.Nombre,
                Value = user.Id
            });

            return selectListItems;

        }
    }
}
