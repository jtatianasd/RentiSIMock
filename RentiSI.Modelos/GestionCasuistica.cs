using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    [PrimaryKey(nameof(GestionId), nameof(CasuisticaId))]
    public class GestionCasuistica
    {
        public int GestionId { get; set; }
        public int CasuisticaId { get; set; }
        [ForeignKey("GestionId")]
        public virtual Gestion? Gestion { get; set; }
        [ForeignKey("CasuisticaId")]
        public virtual TipoCasuistica? TipoCasuistica { get; set; }
    }
}
