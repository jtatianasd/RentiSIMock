using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    public class Recepcion
    {
        [Key]
        public int RecepcionId { get; set; }
        public int? Id_Tramite { get; set; }

        [ForeignKey("Id_Tramite")]
        public Tramite? Id_Tramite_Gestion { get; set; }
        [Display(Name = "Fecha de recepción")]
        public string? FechaRecepcion { get; set; }
        public string? IdUsuarioRecepcion { get; set; }

        public string? Observacion { get; set; }

        [ForeignKey("IdUsuarioRecepcion")]
        public ApplicationUser? UsuarioRecepcion { get; set; }

        public bool EsRecepcion { get; set; }
    }
}
