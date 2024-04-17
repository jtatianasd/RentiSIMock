using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    public class Impronta
    {
        [Key]
        public int ImprontaId { get; set; }
        public int? Id_Tramite { get; set; }

        [ForeignKey("Id_Tramite")]
        public Tramite? Id_Tramite_Gestion { get; set; }
        [Display(Name = "Tipificación de impronta")]
        public string? TipificacionImpronta { get; set; }

        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }
        public string? EsResuelto { get; set; }
        public DateTime FechaResultadoImpronta { get; set; }
        public string? IdUsuarioResuelveImpronta { get; set; }

        [ForeignKey("IdUsuarioResuelveImpronta")]
        public ApplicationUser? UsuarioImpronta { get; set; }
    }
}
