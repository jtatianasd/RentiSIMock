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
        IOrganismoTransitoRepository OrganismoTransito { get; }
        IGestionImprontaRepository GestionImpronta { get; }
        ITipoCasuisticaRepository TipoCasuistica { get; }
        ITramiteCasuisticaRepository TramiteCasuistica { get; }
        ITipoGestionRepository TipoTramite { get; }
        IRevisionCasuisticaRepository RevisionCasuistica { get; }
        IGestionCasuisticaRepository GestionCasuistica { get; }
        IGestionTramiteRepository GestionTramite { get; }
        ITipoRechazoRepository TipoRechazo { get; }
        IReasignacionRepository Reasignacion { get; }

        ITipoGestionRepository TipoGestion { get; }
        void Save();
    }
}
