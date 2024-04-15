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
        [Display(Name = "Estado revisión")]
        public string? EstadoRevision { get; set; }
        [Display(Name = "Tipificación casuistica revision")]
        public string? TipificacionCasuisticaRevision { get; set; }
        [Display(Name = "Organismo de transito")]
        public string? OrganismoTransito { get; set; }
        [Display(Name = "Numero Guia")]
        public string? NumeroGuia { get; set; }

        [Display(Name = "Fecha Revision")]
        public string? FechaRevision { get; set; }

        public string? Observacion { get; set; }

        public bool EsRevision { get; set; }

    }
}
