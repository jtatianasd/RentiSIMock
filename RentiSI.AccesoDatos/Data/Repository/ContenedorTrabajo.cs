using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Usuario = new UsuarioRepository(_db);
            Tramite = new TramiteRepository(_db);
            Asignacion = new AsignacionRepository(_db);
            Revision = new RevisionRepository(_db);
            Recepcion = new RecepcionRepository(_db);
            OrganismoTransito= new OrganismoTransitoRepository(_db);
            GestionImpronta = new GestionImprontaRepository(_db);
            TipoCasuistica = new TipoCasuisticaRepository(_db);
            TramiteCasuistica = new TramiteCasuisticaRepository(_db);
            TipoTramite = new TipoTramiteRepository(_db);
            RevisionCasuistica = new RevisionCasuisticaRepository(_db);
            GestionTramite = new GestionTramiteRepository(_db);
            TipoRechazo = new TipoRechazoRepository(_db);
            GestionCasuistica = new GestionCasuisticaRepository(_db);
            Reasignacion = new ReasignacionRepository(_db);

        }
        public IUsuarioRepository Usuario { get; private set; }
        public ITramiteRepository Tramite { get; private set; }
        public IAsignacionRepository Asignacion { get; private set; }
        public IRevisionRepository Revision { get; private set; }
        public IRecepcionRepository Recepcion { get; private set; }
        public IOrganismoTransitoRepository OrganismoTransito { get; private set; }
        public IGestionImprontaRepository GestionImpronta { get; private set; }
        public ITipoCasuisticaRepository TipoCasuistica { get; private set; }
        public ITramiteCasuisticaRepository TramiteCasuistica { get; private set; }
        public ITipoTramiteRepository TipoTramite { get; private set; }
        public IRevisionCasuisticaRepository RevisionCasuistica { get; private set; }
        public IGestionCasuisticaRepository GestionCasuistica { get; private set; }
        public IGestionTramiteRepository GestionTramite { get; private set; }
        public ITipoRechazoRepository TipoRechazo { get; private set; }
        public IReasignacionRepository Reasignacion { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
