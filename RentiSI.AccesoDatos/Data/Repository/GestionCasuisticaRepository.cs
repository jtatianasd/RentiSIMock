using Microsoft.AspNetCore.Mvc.Rendering;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.AccesoDatos.Data.Repository
{
    public class GestionCasuisticaRepository : Repository<GestionCasuistica>, IGestionCasuisticaRepository
    {
        private readonly ApplicationDbContext _db;

        public GestionCasuisticaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
