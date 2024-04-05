﻿using System;
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
        public int Id { get; set; }
        public int? Id_Tramite { get; set; }

        [ForeignKey("Id_Tramite")]
        public Tramite? Id_Tramite_Gestion { get; set; }
        [Display(Name = "Tipificación de impronta")]
        public string? TipificacionImpronta { get; set; }
        [Display(Name = "Tipificación casuistica impronta")]
        public string? TipificacionCasuisticaImpronta { get; set; }
    }
}