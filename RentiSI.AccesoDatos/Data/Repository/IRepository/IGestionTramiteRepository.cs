using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;

namespace RentiSI.AccesoDatos.Data.Repository.IRepository
{
    public interface IGestionTramiteRepository : IRepository<Gestion>
    {
        IEnumerable<ResponseViewModel> ObtenerGestionesTramites();

        ResponseViewModel ObtenerGestionesTramitesPorId(int GestionId);

        void Actualizar(Gestion Gestion);
    }

}
