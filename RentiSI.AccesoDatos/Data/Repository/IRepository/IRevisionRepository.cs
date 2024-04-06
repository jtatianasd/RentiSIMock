using RentiSI.Modelos;

namespace RentiSI.AccesoDatos.Data.Repository.IRepository
{
    public interface IRevisionRepository : IRepository<Revision>
    {
        IEnumerable<object> ObtenerRevisiones();
    }

}
