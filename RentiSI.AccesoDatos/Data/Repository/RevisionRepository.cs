using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.AccesoDatos.Data.Repository
{
    public class RevisionRepository : Repository<Revision>, IRevisionRepository
    {
        private readonly ApplicationDbContext _db;

        public RevisionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<object> ObtenerRevisiones()
        {
            var result = from tramite in _db.Tramite
                             join revision in _db.Revision
                             on tramite.Id equals revision.Id_Tramite
                             select new
                             {
                                 tramite.NumeroPlaca,
                                 revision.FechaRevision,
                                 revision.TipificacionTramiteRevision,
                                 revision.OrganismoTransito,

                             };
                                
            return result.ToList();

        }




    }
}
