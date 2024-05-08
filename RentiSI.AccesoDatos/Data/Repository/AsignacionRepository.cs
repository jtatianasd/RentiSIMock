using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
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
        public void Actualizar(Tramite tramite)
        {
            var objDesdeDb = _db.Tramite.FirstOrDefault(s => s.Id == tramite.Id);
            objDesdeDb.NumeroPlaca = tramite.NumeroPlaca;
            objDesdeDb.Financiacion = tramite.Financiacion;
            objDesdeDb.Impronta = tramite.Impronta;
            objDesdeDb.FechaNegocio = tramite.FechaNegocio;
            objDesdeDb.Observaciones = tramite.Observaciones;
            objDesdeDb.OrganismoDeTransitoId = tramite.OrganismoDeTransitoId;
            objDesdeDb.IdUsuarioAsignacion=tramite.IdUsuarioAsignacion;
            _db.SaveChanges();
        }
        public string validarPlacas(string placa)
        {
            string Error = "";

            if (Regex.IsMatch(placa, @"^[A-Za-z]{3}-\d{3}$"))
            {
                Error = "";
            }
            else if(Regex.IsMatch(placa, @"^[sS]\d{5}$"))
            {
                Error = "";
            }
            else if(Regex.IsMatch(placa, @"^[rR]\d{5}$"))
            {
                Error = "";
            }
            else
            {
                Error = "Placa no válida, los formatos admitidos son: ABC-123 o S12345 o R12345";
            }
            return Error;
        }

        public void ActualizarOrganismoTransito(Tramite tramite)
        {
            var ObjTramite = _db.Tramite.FirstOrDefault(s => s.Id == tramite.Id);
            if(ObjTramite != null)
            {
                ObjTramite.OrganismoDeTransitoId = tramite.OrganismoDeTransitoId;
                _db.SaveChanges();
            }
        }
    }
}
