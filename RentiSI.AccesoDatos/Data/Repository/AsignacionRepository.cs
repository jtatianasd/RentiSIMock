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
    public class AsignacionRepository : Repository<Tramite>, IAsignacionRepository
    {
        private readonly ApplicationDbContext _db;

        public AsignacionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public bool ExistePlaca(string NumeroPlaca)
        {
            bool valor = _db.Tramite.Any(c => c.NumeroPlaca.ToLower().Trim() == NumeroPlaca.ToLower().Trim());
            return valor;
        }
    }
}
