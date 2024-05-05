using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.AccesoDatos.Data.Repository
{
    public class ReasignacionRepository : Repository<Reasignacion>, IReasignacionRepository
    {
        private readonly ApplicationDbContext _db;

        public ReasignacionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<ReasignacionVM> ObtenerReasignaciones()
        {
            var result = from tramite in _db.Tramite
                         join gestion in _db.Gestion
                         on tramite.Id equals gestion.Id_Tramite
                         join reasignacion in _db.Reasignacion
                         on gestion.Id_Tramite equals reasignacion.Id_Tramite into reasignacionLeftJoin
                         from reasignacionTramite in reasignacionLeftJoin.DefaultIfEmpty()
                         join transito in _db.OrganismosDeTransito
                         on tramite.OrganismoDeTransitoId equals transito.Id
                         join detalleEstado in _db.TipoDetalleEstado
                         on gestion.IdDetalleEstado equals detalleEstado.IdTipoDetalleEstado
                         join gestionCasuistica in _db.GestionCasuistica
                         on gestion.GestionId equals gestionCasuistica.GestionId into casuisticaJoin
                         join usuarios in _db.ApplicationUser
                         on gestion.IdUsuarioGestion equals usuarios.Id into usuariosLeftJoin
                         from gestionUsuarios in usuariosLeftJoin.DefaultIfEmpty()
                         where gestion.EsGestionTramite == false && gestion.EsReasignacion == true && reasignacionTramite.EsReasignado == null
                         select new ReasignacionVM
                         {
                             Tramite = tramite,
                             Gestion = gestion,
                             Reasignacion = reasignacionTramite ?? new Reasignacion(),
                             OrganismosDeTransito = transito,
                             NombreCasuisticas = string.Join(", ", casuisticaJoin.Select(gc => gc.TipoCasuistica.Descripcion)),
                             UsuarioGestion= gestionUsuarios.Nombre,
                             DetalleEstado = detalleEstado,
                             TiempoGestionReasignacion = Utilidades.FechasHelper.CalcularDiasHabiles(gestion.FechaResultado, null )                      };

            return result.ToList();
        }
        public IEnumerable<ReasignacionVM> ObtenerReasignacionesPorId(int? id)
        {
            var result = from tramite in _db.Tramite
                         join gestion in _db.Gestion
                         on tramite.Id equals gestion.Id_Tramite
                         where gestion.GestionId == id
                         select new ReasignacionVM
                         {
                             Tramite = tramite,
                             Gestion = gestion
                         };
            return result.ToList();
        }
        //Actaulizar provisional
        public void Actualizar(ReasignacionVM reasignacion)
        {
            _db.SaveChanges();
        }   
    }
}
