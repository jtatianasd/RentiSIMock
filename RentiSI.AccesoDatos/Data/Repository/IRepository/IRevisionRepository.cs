using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;

namespace RentiSI.AccesoDatos.Data.Repository.IRepository
{
    public interface IRevisionRepository : IRepository<Revision>
    {
        IEnumerable<ResponseViewModel> ObtenerRevisiones();

        ResponseViewModel ObtenerRevisionesPorId(int RevisionId);
    }

}
