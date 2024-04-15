using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Utilidades
{
    public class Fechas
    {
        public string ObtenerFechaActual()
        {
            return DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
}
