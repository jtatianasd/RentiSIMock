﻿using Microsoft.AspNetCore.Mvc.Rendering;
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

        public void Actualizar(Gestion impronta)
        {
            _db.Update(impronta);
            _db.SaveChangesAsync();
        }

        /// <summary>
        /// To Do
        /// </summary>
        /// <returns></returns>
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
                         on impronta.ImprontaId equals tramiteCasuistica.Id_tramite into tramiteCasuisticaLeftJoin
                         from tramiteCasuistica in tramiteCasuisticaLeftJoin.DefaultIfEmpty()
                         join tipoCasuistica in _db.TipoCasuistica
                         on tramiteCasuistica.Id_Casuistica equals tipoCasuistica.Id into tipoCasuisticaLeftJoin
                         from tipoCasuistica in tipoCasuisticaLeftJoin.DefaultIfEmpty()
                         where tramite.Impronta == "true"
                         select new ImprontaVM
                         {
                             Tramite = tramite,
                             Recepcion = recepcion,
                             Impronta = impronta ?? new Impronta(),
                             OrganismosDeTransito = transito,
                             TramiteCasuistica = tramiteCasuistica ?? new TramiteCasuistica(),
                             TipoCasuistica = tipoCasuistica ?? new TipoCasuistica(),
                         };

            return result.ToList();
        }

        public ResponseViewModel ObtenerImprontasPorId(int gestionId)
        {
            var result = (from tramite in _db.Tramite
                          join recepcion in _db.Recepcion
                          on tramite.Id equals recepcion.Id_Tramite
                          join gestion in _db.Gestion
                          on tramite.Id equals gestion.Id_Tramite
                          where recepcion.RecepcionId == gestionId
                          select new ResponseViewModel
                          {
                              NumeroPlaca = tramite.NumeroPlaca,
                              FechaRecepcion = recepcion.FechaRecepcion,
                              FechaAsignacion = tramite.FechaCreacion,
                              Observacion = recepcion.Observacion,
                              GestionId = gestion.GestionId,
                          }).FirstOrDefault();


            return result;
        }

    }
}