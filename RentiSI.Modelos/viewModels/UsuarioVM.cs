﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos.viewModels
{
    public class UsuarioVM
    {
        public ApplicationUser? Usuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos 6 digitos", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
