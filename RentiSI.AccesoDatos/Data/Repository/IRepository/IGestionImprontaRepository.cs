using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;

namespace RentiSI.AccesoDatos.Data.Repository.IRepository
{
    public interface IGestionImprontaRepository : IRepository<Impronta>
    {
        IEnumerable<ImprontaVM> ObtenerImprontas();
        IEnumerable<ImprontaVM> ObtenerImprontasPorId(int? id);
        void Actualizar(ImprontaVM impronta);
    }

}
