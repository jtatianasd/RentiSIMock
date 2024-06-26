﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    public class Reasignacion
    {
        [Key]
        public int ReasignacionId { get; set; }
        public int? Id_Tramite { get; set; }

        [ForeignKey("Id_Tramite")]
        public Tramite? Id_Tramite_Gestion { get; set; }
        [Display(Name = "Fecha de reasignación")]
        public DateTime FechaReasignacion { get; set; }
        public string? IdUsuarioReasignacion { get; set; }
        [ForeignKey("IdUsuarioReasignacion")]
        public ApplicationUser? UsuarioReasignacion { get; set; }
        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }
        public bool EsReasignado { get; set; }
    }
}
