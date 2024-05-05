using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Utilidades
{
    public class FechasHelper
    {
        public static int CalcularDiasHabiles(DateTime fechaInicio, DateTime? fechaFin)
        {

            DateTime fechaFinal = fechaFin ?? DateTime.Now;

            return ObtenerDiasHabiles(fechaInicio, fechaFinal);

        }

        private static int ObtenerDiasHabiles(DateTime fechaInicio, DateTime fechaFin)
        {
            int diasHabiles = 0;

            // Recorremos cada día entre las fechas
            for (DateTime fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
            {
                // Verificamos si el día actual es sábado o domingo
                if (fecha.DayOfWeek != DayOfWeek.Saturday && fecha.DayOfWeek != DayOfWeek.Sunday)
                {
                    // Si no es sábado ni domingo, incrementamos el contador de días hábiles
                    diasHabiles++;
                }
            }

            return diasHabiles;
        }
    }
}
