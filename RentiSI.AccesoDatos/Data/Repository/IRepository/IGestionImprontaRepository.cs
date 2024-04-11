using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;

namespace RentiSI.AccesoDatos.Data.Repository.IRepository
{
    public interface IGestionImprontaRepository : IRepository<Gestion>
    {
        IEnumerable<ResponseViewModel> ObtenerImprontas();

        ResponseViewModel ObtenerImprontasPorId(int improntaId);

        void Actualizar(Gestion impronta);
    }

}
