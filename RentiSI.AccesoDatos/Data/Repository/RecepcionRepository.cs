using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RentiSI.AccesoDatos.Data.Repository
{
    public class RecepcionRepository : Repository<Recepcion>, IRecepcionRepository
    {
        private readonly ApplicationDbContext _db;

        public RecepcionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public ResponseViewModel Actualizar(ResponseViewModel responseViewModel)
        {
            throw new NotImplementedException();
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
                         on tramite.Id equals recepcion.Id_Tramite
                         join usuarios in _db.ApplicationUser
                         on recepcion.IdUsuarioRecepcion equals usuarios.Id into usuariosLeftJoin
                         from recepcionRecepcion in usuariosLeftJoin.DefaultIfEmpty()
                         join transito in _db.OrganismosDeTransito
                         on tramite.OrganismoDeTransitoId equals transito.Id
                         select new ResponseViewModel
                         {
                             NumeroPlaca = tramite.NumeroPlaca,
                             FechaRecepcion = recepcion.FechaRecepcion,
                             RecepcionId = recepcion.Id,
                             Impronta = tramite.Impronta != null ? "Si": "NO",
                             OrganismoTransito = transito.Municipio,
                             FechaAsignacion = tramite.FechaCreacion,
                             UsuarioRecibe = recepcionRecepcion.Nombre

                         };

            return result.ToList();

        }

        public ResponseViewModel ObtenerRecepcionesPorId(int RecepcionId)
        {
            var result = (from tramite in _db.Tramite
                          join recepcion in _db.Recepcion
                          on tramite.Id equals recepcion.Id_Tramite
                          where recepcion.Id == RecepcionId
                          select new ResponseViewModel
                          {
                              NumeroPlaca = tramite.NumeroPlaca,
                              FechaRecepcion = recepcion.FechaRecepcion,
                              FechaAsignacion = tramite.FechaCreacion,
                              Observacion = recepcion.Observacion,
                              RecepcionId = recepcion.Id,
                          }).FirstOrDefault();


            return result;
        }
    }
}
