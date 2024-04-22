using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;

namespace RentiSI.AccesoDatos.Data.Repository
{
    public class RevisionRepository : Repository<Revision>, IRevisionRepository
    {
        private readonly ApplicationDbContext _db;

        public RevisionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<ResponseViewModel> ObtenerRevisiones(string UserId, string Rol)
        {
            var result = from tramite in _db.Tramite
                         join revision in _db.Revision
                         on tramite.Id equals revision.Id_Tramite 
                         join recepcion in _db.Recepcion
                         on tramite.Id equals recepcion.Id_Tramite
                         join impronta in _db.Impronta
                         on tramite.Id equals impronta.Id_Tramite
                         join transito in _db.OrganismosDeTransito
                         on tramite.OrganismoDeTransitoId equals transito.Id
                         join revisionCasuistica in _db.RevisionCasuistica
                         on revision.RevisionId equals revisionCasuistica.RevisionId into casuisticaJoin
                         where revision.EsRevision == false && (revision.IdUsuarioRevision == UserId || Rol == "Administrador")
                         select new ResponseViewModel
                         {
                             OrganismosDeTransito = transito,
                             Tramite = tramite,
                             Revision = revision,
                             Recepcion = recepcion,
                             NombreCasuisticas = string.Join(", ", casuisticaJoin.Select(rc => rc.TipoCasuistica.Descripcion)),
                             FechaRecepcion = recepcion.FechaRecepcion.HasValue ? recepcion.FechaRecepcion.Value.ToString("dd-MM-yyyy") : null,
                             FechaImpronta = impronta.FechaResultadoImpronta.ToString("dd-MM-yyyy"),
        };

            return result.ToList();

        }


        public ResponseViewModel ObtenerRevisionesPorId(int GestionId)
        {
            var result = (from tramite in _db.Tramite
                          join revision in _db.Revision
                          on tramite.Id equals revision.Id_Tramite
                          join recepcion in _db.Recepcion
                          on tramite.Id equals recepcion.Id_Tramite
                          join transito in _db.OrganismosDeTransito
                          on tramite.OrganismoDeTransitoId equals transito.Id
                          where revision.RevisionId == GestionId

                          select new ResponseViewModel
                          {
                              Tramite = tramite,
                              FechaRecepcion = recepcion.FechaRecepcion.HasValue ? recepcion.FechaRecepcion.Value.ToString("dd-MM-yyyy"): null,
                              FechaAsignacion = tramite.FechaCreacion.HasValue ? tramite.FechaCreacion.Value.ToString("dd-MM-yyyy") : null,
                              Observacion = recepcion.Observacion,
                              Revision = revision,
                              OrganismosDeTransito = transito,
                          }).FirstOrDefault();


            return result;
        }

        public void Actualizar(Revision revision)
        {
            _db.Update(revision);
            _db.SaveChangesAsync();
        }

    }
}
