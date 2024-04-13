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
    public class TipoTramiteRepository: Repository<TipoTramite>, ITipoTramiteRepository
    {
        private readonly ApplicationDbContext _db;

        public TipoTramiteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaTipoTramite()
        {
            return _db.TipoTramite.Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }
    }
}
