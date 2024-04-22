using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;

namespace RentiSI.AccesoDatos.Data.Repository.IRepository
{
    public interface IRevisionRepository : IRepository<Revision>
    {
        IEnumerable<ResponseViewModel> ObtenerRevisiones(string UserId, string Rol);

        ResponseViewModel ObtenerRevisionesPorId(int RevisionId);

        void Actualizar(Revision Revision);
    }

}
