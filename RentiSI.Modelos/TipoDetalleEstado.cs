using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos
{
    public class TipoDetalleEstado
    {
        [Key]
        public int IdTipoDetalleEstado { get; set; }
        public string DescripcionDetalle { get; set; }
    }
}
