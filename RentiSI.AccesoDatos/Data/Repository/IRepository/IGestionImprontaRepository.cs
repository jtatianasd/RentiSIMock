using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;

namespace RentiSI.AccesoDatos.Data.Repository.IRepository
{
    public interface IGestionImprontaRepository : IRepository<Impronta>
    {
        IEnumerable<ResponseViewModel> ObtenerImprontas();

        ResponseViewModel ObtenerImpronrasPorId(int improntaId);

        void Actualizar(Impronta impronta);
    }

}
