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
                         on gestionTramite.GestionId equals detalleEstado.IdTipoDetalleEstado into gestionCasuisticaLeftJoin
                         from detalleEstadoGestion in gestionCasuisticaLeftJoin.DefaultIfEmpty()
                         where revision.EsRevision == true 
                         select new ResponseViewModel
                         {
                             OrganismosDeTransito = transito,
                             Tramite = tramite,
                             Revision = revision,
                             GestionTramite = gestionTramite ?? new Gestion(),
                             NombreCasuisticas = string.Join(", ", casuisticaJoin.Select(rc => rc.TipoCasuistica.Descripcion)),
                             UsuarioRevision = gestionTramiteUsuarios.Nombre,
                             DetalleEstado = detalleEstadoGestion

                         };

            return result.ToList();

        }


        public ResponseViewModel ObtenerGestionesTramitesPorId(int GestionId)
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
                              FechaRecepcion = recepcion.FechaRecepcion.HasValue ? recepcion.FechaRecepcion.Value.ToString("dd-MM-yyyy") : null,
                              FechaAsignacion = tramite.FechaCreacion,
                              Observacion = recepcion.Observacion,
                              Revision = revision,
                              OrganismosDeTransito = transito,
                          }).FirstOrDefault();


            return result;
        }

        public void Actualizar(Gestion Gestion)
        {
            _db.Update(Gestion);
            _db.SaveChangesAsync();
        }
    }
}
