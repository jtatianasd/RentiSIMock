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
        [Display(Name = "Fecha de gestión del tramite")]
        public string? FechaGestion { get; set; }
        [Display(Name = "Estado gestion revisión")]
        public string? EstadoGestion { get; set; }
        public string? IdUsuarioGestion { get; set; }
        [ForeignKey("IdUsuarioGestion")]
        public ApplicationUser? UsuarioGestion { get; set; }
        [Display(Name = "Fecha de resultado")]
        public string? FechaResultado { get; set; }
        public string? IdUsuarioResuelve { get; set; }

        [ForeignKey("IdUsuarioResuelve")]
        public ApplicationUser? UsuarioResuelve { get; set; }
    }
}
