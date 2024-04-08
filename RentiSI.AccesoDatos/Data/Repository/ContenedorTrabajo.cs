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
        }
        public IUsuarioRepository Usuario { get; private set; }

        public ITramiteRepository Tramite { get; private set; }

        public IAsignacionRepository Asignacion { get; private set; }
        public IRevisionRepository Revision { get; private set; }

        public IRecepcionRepository Recepcion { get; private set; }

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
