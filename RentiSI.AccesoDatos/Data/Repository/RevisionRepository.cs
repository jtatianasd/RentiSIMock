using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
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


        public IEnumerable<RevisionViewModel> ObtenerRevisiones()
        {
            var result = from tramite in _db.Tramite
                             join revision in _db.Revision
                             on tramite.Id equals revision.Id_Tramite
                             select new RevisionViewModel
                             {
                                 NumeroPlaca = tramite.NumeroPlaca,
                                 FechaRevision = revision.FechaRevision,
                                 TipificacionTramiteRevision = revision.TipificacionTramiteRevision,
                                 OrganismoTransito = revision.OrganismoTransito,
                                 RevisionId = revision.Id

                             };
                                
            return result.ToList();

        }




    }
}
