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
        [Required(ErrorMessage = "La Direccion es obligatoria")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "La Ciudad es obligatoria")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "El pais es obligatorio")]
        public string Pais { get; set; }

    }
}
