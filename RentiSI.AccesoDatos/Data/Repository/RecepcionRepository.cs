using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;

namespace RentiSI.AccesoDatos.Data.Repository
{
    public class RecepcionRepository : Repository<Recepcion>, IRecepcionRepository
    {
        private readonly ApplicationDbContext _db;

        public RecepcionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Recepcion recepcion)
        {
            _db.Update(recepcion);
            _db.SaveChangesAsync();
        }

        public IEnumerable<ResponseViewModel> ObtenerRecepciones()
        {
            var result = from tramite in _db.Tramite
                         join recepcion in _db.Recepcion
                         on tramite.Id equals recepcion.Id_Tramite into tr
                         from recepcionTramite in tr.DefaultIfEmpty()
                         join usuarios in _db.ApplicationUser
                         on recepcionTramite.IdUsuarioRecepcion equals usuarios.Id into usuariosLeftJoin
                         from recepcionRecepcion in usuariosLeftJoin.DefaultIfEmpty()
                         join transito in _db.OrganismosDeTransito
                         on tramite.OrganismoDeTransitoId equals transito.Id
                         select new ResponseViewModel
                         {
                             NumeroPlaca = tramite.NumeroPlaca,
                             FechaRecepcion = recepcionTramite.FechaRecepcion.HasValue ? recepcionTramite.FechaRecepcion.Value.ToString("dd-MM-yyyy") : null,
                             Recepcion = recepcionTramite != null ? recepcionTramite : new Recepcion(),
                             EsImpronta = tramite.Impronta != false ? "Si" : "No",
                             OrganismosDeTransito = transito,
                             FechaAsignacion = tramite.FechaCreacion.HasValue ? tramite.FechaCreacion.Value.ToString("dd-MM-yyyy") : null,
                             UsuarioRecibe = recepcionRecepcion.Nombre,
                             TramiteId = tramite.Id

                         };


            return result.ToList();
        }

        public ResponseViewModel ObtenerRecepcionesPorId(int RecepcionId)
        {
            var result = (from tramite in _db.Tramite
                          join recepcion in _db.Recepcion
                          on tramite.Id equals recepcion.Id_Tramite
                          join transito in _db.OrganismosDeTransito
                          on tramite.OrganismoDeTransitoId equals transito.Id
                          where recepcion.RecepcionId == RecepcionId
                          select new ResponseViewModel
                          {
                              OrganismosDeTransito = transito,
                              Tramite = tramite,
                              Recepcion = recepcion,
                              FechaAsignacion = tramite.FechaCreacion.HasValue ? tramite.FechaCreacion.Value.ToString("dd-MM-yyyy") : null,

                          }).FirstOrDefault();


            return result;
        }
    }
}
