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
        IAsignacionRepository Asignacion { get; }

        IRevisionRepository Revision { get; }

        IRecepcionRepository Recepcion { get; }
        void Save();
    }
}
