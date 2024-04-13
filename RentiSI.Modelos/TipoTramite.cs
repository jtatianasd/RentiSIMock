using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    public class TipoTramite
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tipo de Tramite")]
        public string Descripcion { get; set; }
        

    }
}
