using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    public class Revision
    {
        [Key]
        public int RevisionId { get; set; }
        public int? Id_Tramite { get; set; }

        [ForeignKey("Id_Tramite")]
        public Tramite? Id_Tramite_Gestion { get; set; }
        public string? IdUsuarioRevision { get; set; }

        [ForeignKey("IdUsuarioRevision")]
        public ApplicationUser? UsuarioRevision { get; set; }

        [Display(Name = "Tipificación trámite en revisión ")]
        public string? TipificacionTramiteRevision { get; set; }

        [Display(Name = "Número Guia")]
        public string? NumeroGuia { get; set; }

        [Display(Name = "Fecha Revision")]
        public DateTime FechaRevision { get; set; }

        [Display(Name = "Observación")]
        public string? Observacion { get; set; }

        public bool EsRevision { get; set; }

        public bool EsReasignacion { get; set; }

    }
}
