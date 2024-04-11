using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    public class TipoCasuistica
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Modulo")]
        public string? Modulo { get; set; }
        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }
    }
}
