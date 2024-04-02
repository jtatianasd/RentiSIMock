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
        [Display(Name = "Fecha de recepción")]
        public string? FechaRecepcion { get; set; }
        public string? IdUsuarioRecibe { get; set; }

        [ForeignKey("IdUsuarioRecibe")]
        public ApplicationUser? UsuarioRecibe { get; set; }

        [Display(Name = "Fecha de resultado")]
        public string? FechaResultado { get; set; }

        public string? IdUsuarioResuelve { get; set; }

        [ForeignKey("IdUsuarioResuelve")]
        public ApplicationUser? UsuarioResuelve { get; set; }
        [Display(Name = "Tipificación de impronta")]
        public string? TipificacionImpronta { get; set; }
        [Display(Name = "Tipificación casuistica impronta")]
        public string? TipificacionCasuisticaImpronta { get; set; }
        [Display(Name = "Fecha de revisión")]
        public string? FechaRevision { get; set; }
        public string? IdUsuarioRevision { get; set; }

        [ForeignKey("IdUsuarioRevision")]
        public ApplicationUser? UsuarioRevision { get; set; }
        [Display(Name = "Tipificación trámite en revisión ")]
        public string? TipificacionTramiteRevision { get; set; }
        [Display(Name = "Estado revisión")]
        public string? EstadoRevision { get; set; }
        [Display(Name = "Organismo de transito")]
        public string? OrganismoTransito { get; set; }
        [Display(Name = "Numero Guia")]
        public string? NumeroGuia { get; set; }
        [Display(Name = "Tipificación casuistica revision")]
        public string? TipificacionCasuisticaRevision { get; set; }
        [Display(Name = "Fecha de gestión del tramite")]
        public string? FechaGestion { get; set; }
        [Display(Name = "Estado gestion revisión")]
        public string? EstadoGestion { get; set; }
      
        public string? IdUsuarioGestion { get; set; }

        [ForeignKey("IdUsuarioGestion")]
        public ApplicationUser? UsuarioGestion { get; set; }
        [Display(Name = "Fecha de reasignación")]
        public string? FechaReasignacion { get; set; }
        public string? IdUsuarioReasignacion { get; set; }

        [ForeignKey("IdUsuarioReasignacion")]
        public ApplicationUser? UsuarioReasignacion { get; set; }

    }
}
