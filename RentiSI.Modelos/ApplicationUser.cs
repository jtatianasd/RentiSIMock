using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    public class ApplicationUser: IdentityUser
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        /*[Required(ErrorMessage = "El correo es obligatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El correo no tiene un formato válido.")]
        [Display(Name = "Correo")]
        public string Email { get; set; }*/

        /*[Required(ErrorMessage = "El usuario es obligatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El usaurio no tiene un formato válido.")]
        public string UserName { get; set; }

        /*[Required(ErrorMessage = "La contraseña es obligatorio")]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres y maximo {1} caracteres de longitud .", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        public string PasswordHash { get; set; }*/

    }
}
