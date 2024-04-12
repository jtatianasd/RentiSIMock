using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{  
    [PrimaryKey(nameof(Id_tramite), nameof(Id_Casuistica))]
    public class TramiteCasuistica
    {
        public int Id_tramite { get; set; }

        public int Id_Casuistica { get; set; }

        [ForeignKey("Id_tramite")]
        public virtual Tramite? Tramite { get; set; }

        [ForeignKey("Id_Casuistica")]
        public virtual TipoCasuistica? TipoCasuistica { get; set; }
        [ForeignKey("Id_tramite")]
        public virtual Impronta? Impronta { get; set; }
        [ForeignKey("Id_tramite")]
        public virtual Revision? Revision { get; set; }

    }
}
