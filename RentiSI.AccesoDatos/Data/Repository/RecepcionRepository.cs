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


        public IEnumerable<ResponseViewModel> ObtenerRecepciones()
        {
            var result = from tramite in _db.Tramite
                             join recepcion in _db.Recepcion
                             on tramite.Id equals recepcion.Id_Tramite
                             join impronta in _db.Impronta
                             on tramite.Id equals impronta.Id_Tramite
                             join usuarios in _db.ApplicationUser
                             on recepcion.IdUsuarioRecepcion equals usuarios.Id into recepciono
                             from recepcionRecepcion in recepciono.DefaultIfEmpty()
                         select new ResponseViewModel
                             {
                                 NumeroPlaca = tramite.NumeroPlaca,
                                 FechaRecepcion = recepcion.FechaRecepcion,
                                 RecepcionId = recepcion.Id,
                                 Impronta    = tramite.Impronta,
                                 FechaAsignacion = tramite.FechaCreacion,
                                 UsuarioRecibe = recepcionRecepcion.Nombre

                         };
                                
            return result.ToList();

        }




    }
}
