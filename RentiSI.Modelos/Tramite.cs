﻿using System;
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
        [Display(Name = "Numero de placa")]
        public string NumeroPlaca { get; set; }
        [Display(Name = "Financiación")]
        public bool Financiacion { get; set; }
        [Display(Name = "Impronta")]
        public bool Impronta { get; set; }
        [Display(Name = "Fecha de negocio")]
        [Required(ErrorMessage = "La fecha de negocio es requerida")]
        public DateTime? FechaNegocio { get; set; }
        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }
        [Required(ErrorMessage = "El organismo de transito es requerido")]
        public int OrganismoDeTransitoId { get; set; }
        [ForeignKey("OrganismoDeTransitoId")]
        public OrganismosDeTransito? OrganismosDeTransito { get; set; }
        public string? IdUsuarioAsignacion { get; set; }
        [ForeignKey("IdUsuarioAsignacion")]
        public ApplicationUser? UsuarioAsignacion { get; set; }

    }
}
