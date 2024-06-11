using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{

    [PrimaryKey(nameof(TramiteId), nameof(TipoGestionId))]
    public class TipoGestion
    {
        public int TramiteId { get; set; }
        public int TipoGestionId { get; set; }
        [ForeignKey("TramiteId")]
        public virtual Tramite? Tramite { get; set; }
        [ForeignKey("TipoGestionId")]
        public virtual TipoCasuistica? TipoCasuistica { get; set; }

    }
}
