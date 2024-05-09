using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;

namespace RentiSI.AccesoDatos.Data.Repository
{
    public class GestionTramiteRepository : Repository<Gestion>, IGestionTramiteRepository
    {
        private readonly ApplicationDbContext _db;

        public GestionTramiteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<ResponseViewModel> ObtenerGestionesTramites()
        {
            var result = from tramite in _db.Tramite
                         join gestion in _db.Gestion
                         on tramite.Id equals gestion.Id_Tramite into gestionTramiteLeftJoin
                         from gestionTramite in gestionTramiteLeftJoin.DefaultIfEmpty()
                         join revision in _db.Revision
                         on tramite.Id equals revision.Id_Tramite
                         join gestionCasuistica in _db.GestionCasuistica
                         on gestionTramite.GestionId equals gestionCasuistica.GestionId into casuisticaJoin
                         join transito in _db.OrganismosDeTransito
                         on tramite.OrganismoDeTransitoId equals transito.Id
                         join usuarios in _db.ApplicationUser
                         on gestionTramite.IdUsuarioGestion equals usuarios.Id into usuariosLeftJoin
                         from gestionTramiteUsuarios in usuariosLeftJoin.DefaultIfEmpty()
                         join detalleEstado in _db.TipoDetalleEstado
                         on gestionTramite.IdDetalleEstado equals detalleEstado.IdTipoDetalleEstado into detalleEstadoLeftJoin
                         from detalleEstadoGestion in detalleEstadoLeftJoin.DefaultIfEmpty()
                         where revision.EsRevision == true && (gestionTramite.EsGestionTramite == false || gestionTramite.EsGestionTramite == null)
                         && gestionTramite.EsReasignacion != true
                         select new ResponseViewModel
                         {
                             OrganismosDeTransito = transito,
                             Tramite = tramite,
                             Revision = revision,
                             GestionTramite = gestionTramite ?? new Gestion(),
                             NombreCasuisticas = string.Join(", ", casuisticaJoin.Select(rc => rc.TipoCasuistica.Descripcion)),
                             UsuarioTramite = gestionTramiteUsuarios.Nombre,
                             DetalleEstado = detalleEstadoGestion,
                             TiempoGestionTramite = Utilidades.FechasHelper.CalcularDiasHabiles(revision.FechaRevision, gestionTramite.FechaResultado),

                         };

            return result.ToList();

        }


        public ResponseViewModel ObtenerGestionesTramitesPorId(int gestionId)
        {
            var result = (from tramite in _db.Tramite
                          join gestion in _db.Gestion
                          on tramite.Id equals gestion.Id_Tramite
                          join revision in _db.Revision
                          on tramite.Id equals revision.Id_Tramite
                          join transito in _db.OrganismosDeTransito
                          on tramite.OrganismoDeTransitoId equals transito.Id
                          join usuarios in _db.ApplicationUser
                          on gestion.IdUsuarioGestion equals usuarios.Id into usuariosLeftJoin
                          from gestionTramiteUsuarios in usuariosLeftJoin.DefaultIfEmpty()
                          join detalleEstado in _db.TipoDetalleEstado
                          on gestion.GestionId equals detalleEstado.IdTipoDetalleEstado into gestionCasuisticaLeftJoin
                          from detalleEstadoGestion in gestionCasuisticaLeftJoin.DefaultIfEmpty()
                          where gestion.GestionId == gestionId

                          select new ResponseViewModel
                          {
                              OrganismosDeTransito = transito,
                              Tramite = tramite,
                              GestionTramite = gestion,
                              DetalleEstado = detalleEstadoGestion ,
                              UsuarioTramite = gestionTramiteUsuarios.Nombre,
                          }).FirstOrDefault();


            return result;
        }


        public void Actualizar(Gestion Gestion)
        {
            _db.SaveChanges();
        }

        public void ActualizarEsRevision(int? TramiteId)
        {
            var objRevision = _db.Gestion.FirstOrDefault(s => s.Id_Tramite == TramiteId);
            if (objRevision == null)
            {
                return;
            }


            objRevision.EsReasignacion = false;

            _db.SaveChanges();
        }
    }
}
