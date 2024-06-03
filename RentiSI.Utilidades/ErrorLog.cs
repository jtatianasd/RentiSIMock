using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Utilidades
{
    public class ErrorLog
    {
        const string rutaArchivoLog = "C:/Logs";
        private void CrearDirectorio()
        {
            try
            {
                // Verificar si el directorio de logs no existe
                if (!System.IO.Directory.Exists(rutaArchivoLog))
                {
                    System.IO.Directory.CreateDirectory(rutaArchivoLog);
                }
            }
            catch (Exception)
            {

            }
        }
        public void RegistrarError(string ex, string nombreArchivo)
        {
            try
            {
                CrearDirectorio();

                // Obtener la fecha y hora actual
                string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Construir el mensaje de registro con la fecha, hora y detalles del error
                string mensajeLog = $"\n[{fechaHora}] Error: {ex}";

                string Archivo = nombreArchivo + "." + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                // Crear el archivo en el directorio predeterminado
                string fullPath = Path.Combine(rutaArchivoLog, Archivo);
                if (!File.Exists(fullPath))
                {
                    using (FileStream fs = File.Create(fullPath))
                    {
                        // Cerrar el FileStream después de crear el archivo
                        fs.Close();
                    }
                }
                // Escribir el mensaje de registro en el archivo de registro
                File.AppendAllText(fullPath, mensajeLog);
            }
            catch (Exception)
            {

            }
        }
    }
}
