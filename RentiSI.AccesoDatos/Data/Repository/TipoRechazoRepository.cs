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
    public class TipoRechazoRepository : Repository<TipoDetalleEstado>, ITipoRechazoRepository
    {
        private readonly ApplicationDbContext _db;

        public TipoRechazoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaTipoRechazo()
        {
            return _db.TipoDetalleEstado.Select(i => new SelectListItem()
            {
                Text = i.DescripcionDetalle,
                Value = i.IdTipoDetalleEstado.ToString()
            });
        }
    }
}
