using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    public class Tramite
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Fecha de Creación")]
        public string FechaCreacion { get; set; }

        [Display(Name = "Numero de placa")]
        public string NumeroPlaca { get; set; }

        [Display(Name = "Financiación")]
        public string? Financiacion { get; set; }

        [Display(Name = "Impronta")]
        public string? Impronta { get; set; }
        [Display(Name = "Fecha de negocio")]
        public string? FechaNegocio { get; set; }
    }
}
