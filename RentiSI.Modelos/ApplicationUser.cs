using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RentiSI.Modelos
{
    public class ApplicationUser: IdentityUser
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

    }
}
