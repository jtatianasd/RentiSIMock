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
    public class TipoCasuisticaRepository : Repository<TipoCasuistica>, ITipoCasuisticaRepository
    {
        private readonly ApplicationDbContext _db;

        public TipoCasuisticaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaTipoCasuistica()
        {
            return _db.TipoCasuistica.Select(tc => new SelectListItem()
            {
                Value = tc.Id.ToString(),
                Text = tc.Descripcion
            });
        }
        public IEnumerable<SelectListItem> GetListaTipoCasuisticaPorModulo(string modulo)
        {
            return _db.TipoCasuistica
              .Where(tc => tc.Modulo == modulo)
              .OrderBy(tc => tc.Descripcion)
              .Select(tc => new SelectListItem
              {
                  Value = tc.Id.ToString(),
                  Text = tc.Descripcion
              })
              .ToList();
        }

    }
}
