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
    public class OrganismoTransitoRepository: Repository<OrganismosDeTransito>, IOrganismoTransitoRepository
    {
        private readonly ApplicationDbContext _db;

        public OrganismoTransitoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaOrganismosTransito()
        {
            return _db.OrganismosDeTransito.Select(i => new SelectListItem()
            {
                Text = i.Municipio,
                Value = i.Id.ToString()
            });
        }
    }
}
