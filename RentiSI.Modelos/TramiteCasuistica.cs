﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{  
    [PrimaryKey(nameof(ImprontaId), nameof(CasuisticaId))]
    public class TramiteCasuistica
    {
        public int ImprontaId { get; set; }
        public int CasuisticaId { get; set; }
        [ForeignKey("ImprontaId")]
        public virtual Impronta? Impronta { get; set; }
        [ForeignKey("CasuisticaId")]
        public virtual TipoCasuistica? TipoCasuistica { get; set; }
    }
}
