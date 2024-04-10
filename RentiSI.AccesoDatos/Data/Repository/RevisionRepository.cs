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


        public IEnumerable<ResponseViewModel> ObtenerRevisiones()
        {
            var result = from tramite in _db.Tramite
                         join revision in _db.Revision
                         on tramite.Id equals revision.Id_Tramite
                         join recepcion in _db.Recepcion
                         on tramite.Id equals recepcion.Id_Tramite
                         join transito in _db.OrganismosDeTransito
                        on tramite.OrganismoDeTransitoId equals transito.Id
                         select new ResponseViewModel
                         {
                             NumeroPlaca = tramite.NumeroPlaca,
                             FechaRevision = revision.FechaRevision,
                             TipificacionTramiteRevision = revision.TipificacionTramiteRevision,
                             OrganismoTransito = transito.Municipio,
                             RevisionId = revision.Id,
                             FechaRecepcion =recepcion.FechaRecepcion,

                         };

            return result.ToList();

        }


        public ResponseViewModel ObtenerRevisionesPorId(int RevisionId)
        {
            var result = (from tramite in _db.Tramite
                          join revision in _db.Revision
                          on tramite.Id equals revision.Id_Tramite
                          join recepcion in _db.Recepcion
                          on tramite.Id equals recepcion.Id_Tramite
                          where revision.Id == RevisionId
                          select new ResponseViewModel
                          {
                              NumeroPlaca = tramite.NumeroPlaca,
                              FechaRecepcion = recepcion.FechaRecepcion,
                              FechaAsignacion = tramite.FechaCreacion,
                              Observacion = recepcion.Observacion,
                              RevisionId = revision.Id,
                          }).FirstOrDefault();


            return result;
        }




    }
}
