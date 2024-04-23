using Microsoft.AspNetCore.Mvc.Rendering;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RentiSI.AccesoDatos.Data.Repository
{
    public class GestionImprontaRepository : Repository<Impronta>, IGestionImprontaRepository
    {
        private readonly ApplicationDbContext _db;

        public GestionImprontaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(ImprontaVM improntaVM)
        {
            var objDesdeDb = _db.Impronta.FirstOrDefault(s => s.ImprontaId == improntaVM.Impronta.ImprontaId);
            objDesdeDb.TipificacionImpronta = improntaVM.Impronta.TipificacionImpronta;
            objDesdeDb.Observaciones = improntaVM.Impronta.Observaciones;
            objDesdeDb.EsResuelto = improntaVM.Impronta.EsResuelto;
            objDesdeDb.IdUsuarioResuelveImpronta = improntaVM.Impronta.IdUsuarioResuelveImpronta;
            objDesdeDb.FechaResultadoImpronta = improntaVM.Impronta.FechaResultadoImpronta;
            _db.SaveChanges();

            var tramiteCasuistica = _db.TramiteCasuistica.Where(tc => tc.ImprontaId == improntaVM.Impronta.ImprontaId);
            _db.TramiteCasuistica.RemoveRange(tramiteCasuistica);
            _db.SaveChanges();

            if (improntaVM.SelectedCasuisticasIds != null)
            {
                foreach (var casuisticaId in improntaVM.SelectedCasuisticasIds)
                {
                    _db.TramiteCasuistica.Add(new TramiteCasuistica
                    {
                        ImprontaId = improntaVM.Impronta.ImprontaId,
                        CasuisticaId = casuisticaId
                    });
                }
                _db.SaveChanges();
            }
        }

        public IEnumerable<ImprontaVM> ObtenerImprontas()
        {
            var result = from tramite in _db.Tramite
                         join recepcion in _db.Recepcion
                         on tramite.Id equals recepcion.Id_Tramite
                         join usuarios in _db.ApplicationUser
                         on recepcion.IdUsuarioRecepcion equals usuarios.Id into usuariosLeftJoin
                         from recepcionRecepcion in usuariosLeftJoin.DefaultIfEmpty()
                         join transito in _db.OrganismosDeTransito
                         on tramite.OrganismoDeTransitoId equals transito.Id
                         join Impronta in _db.Impronta
                         on tramite.Id equals Impronta.Id_Tramite into improntaLeftJoin
                         from impronta in improntaLeftJoin.DefaultIfEmpty()
                         join tramiteCasuistica in _db.TramiteCasuistica
                         on impronta.ImprontaId equals tramiteCasuistica.ImprontaId into casuisticaJoin
                         where recepcion.EsRecepcion == true && (impronta.EsResuelto == false || impronta.EsResuelto == null)
                         select new ImprontaVM
                         {
                             Tramite = tramite,
                             Recepcion = recepcion,
                             Impronta = impronta ?? new Impronta(),
                             OrganismosDeTransito = transito,
                             NombreCasuisticas = string.Join(", ", casuisticaJoin.Select(rc => rc.TipoCasuistica.Descripcion))
                         };

            return result.ToList();
        }
        public IEnumerable<ImprontaVM> ObtenerImprontasPorId(int? id)
        {
            var result = from tramite in _db.Tramite
                         join impronta in _db.Impronta
                         on tramite.Id equals impronta.Id_Tramite
                         where impronta.ImprontaId == id
                         select new ImprontaVM
                         {
                             Tramite = tramite,
                             Impronta = impronta
                         };
            return result.ToList();
        }
    }
}
