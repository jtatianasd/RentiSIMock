using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.AccesoDatos.Data.Repository.IRepository
{
    public interface IReasignacionRepository : IRepository<Reasignacion>
    {
        IEnumerable<ReasignacionVM> ObtenerReasignaciones();
        IEnumerable<ReasignacionVM> ObtenerReasignacionesPorId(int? id);
        void Actualizar(ReasignacionVM reasignacion);
    }
}
