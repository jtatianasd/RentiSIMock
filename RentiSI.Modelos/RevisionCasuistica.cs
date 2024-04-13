using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    [PrimaryKey(nameof(RevisionId), nameof(CasuisticaId))]
    public class RevisionCasuistica
    {
        public int RevisionId { get; set; }
        public int CasuisticaId { get; set; }
        [ForeignKey("RevisionId")]
        public virtual Revision? Revision { get; set; }
        [ForeignKey("CasuisticaId")]
        public virtual TipoCasuistica? TipoCasuistica { get; set; }
    }
}
