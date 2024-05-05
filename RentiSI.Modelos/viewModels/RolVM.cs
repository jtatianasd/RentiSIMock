using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos.viewModels
{
    public class RolVM
    {
        public ApplicationUser? Usuario { get; set; }
        public string Rol { get; set; }
    }
}
