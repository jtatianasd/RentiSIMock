using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.AccesoDatos.Data.Repository
{
    public class TramiteRepository : Repository<Tramite>, ITramiteRepository
    {
        private readonly ApplicationDbContext _db;

        public TramiteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void guardarTramite()
        {

        }

    }
}
