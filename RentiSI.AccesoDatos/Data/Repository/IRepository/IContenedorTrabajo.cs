using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        IUsuarioRepository Usuario { get; }

        ITramiteRepository Tramite { get; }
        void Save();
    }
}
