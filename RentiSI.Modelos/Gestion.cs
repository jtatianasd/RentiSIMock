using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    public class Gestion
    {
        [Key]
        public int GestionId { get; set; }
        public int? Id_Tramite { get; set; }

        [ForeignKey("Id_Tramite")]
        public Tramite? Id_Tramite_Gestion { get; set; }
      
        public string? IdUsuarioGestion { get; set; }
        [ForeignKey("IdUsuarioGestion")]
        public ApplicationUser? UsuarioGestion { get; set; }

        [Display(Name = "Fecha de resultado")]
        public DateTime FechaResultado { get; set; }


        [Required(ErrorMessage = "El tipo estado trámite es requerido")]
        public int? IdDetalleEstado { get; set; }

        [ForeignKey("IdDetalleEstado")]
        public TipoDetalleEstado? IdTipoDetalleEstado { get; set; }
      
        public string? Observacion { get; set; }

        public bool EsGestionTramite { get; set; }

        public bool EsReasignacion { get; set; }


    }
}
