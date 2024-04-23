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
        public DateTime? FechaCreacion { get; set; }
        [Required(ErrorMessage = "El numero de placa es requerido")]
        public string NumeroPlaca { get; set; }
        public bool Financiacion { get; set; }
        public bool Impronta { get; set; }
        public DateTime? FechaNegocio { get; set; }
        public string? Observaciones { get; set; }
        [Display(Name = "Organismo de Transito Id")]
        [Required(ErrorMessage = "El campo Organismo De Transito es requerido")]
        public int? OrganismoDeTransitoId { get; set; }
        [ForeignKey("OrganismoDeTransitoId")]
        public OrganismosDeTransito? OrganismosDeTransito { get; set; }
        public string? IdUsuarioAsignacion { get; set; }
        [ForeignKey("IdUsuarioAsignacion")]
        public ApplicationUser? UsuarioAsignacion { get; set; }

    }
}
