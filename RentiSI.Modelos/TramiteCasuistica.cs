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
    }
}
