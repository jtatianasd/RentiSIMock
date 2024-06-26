﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentiSI.AccesoDatos.Data.Repository.IRepository;
using RentiSI.Areas.Operativo.Controllers;
using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;
using RentiSI.Utilidades;
using System.Globalization;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentiSI.Areas.Cliente.Controllers
{
    [Authorize(Roles = "Cliente, Administrador")]
    [Area("Cliente")]
    public class AsignacionesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly UserManager<ApplicationUser> _userManager;
        private ErrorLog errorLog= new ErrorLog();
        public AsignacionesController(IContenedorTrabajo contenedorTrabajo, UserManager<ApplicationUser> userManager)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                TramiteVM tramiteVM = new TramiteVM()
                {
                    Tramite = new Tramite(),
                    ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito(),
                    ListaTipoGestion = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("TIPO_GESTION")
            };
                return View(tramiteVM);
            }
            catch (Exception ex)
            {
                
                return View();
            } 
        }
        [HttpPost]
        public IActionResult Create(TramiteVM tramiteVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tramiteVM.Tramite.FechaCreacion = DateTime.Now;
                    tramiteVM.Tramite.IdUsuarioAsignacion = _userManager.GetUserId(User);
                    string placaValida = _contenedorTrabajo.Asignacion.validarPlacas(tramiteVM.Tramite.NumeroPlaca);
                    if (string.IsNullOrEmpty(placaValida))
                    {
                        if (_contenedorTrabajo.Asignacion.ExistePlaca(tramiteVM.Tramite.NumeroPlaca))
                        {
                            TempData["Mensaje"] = "La placa ya se encuentra registrada, aun asi se creó en el sistema.";
                        }
                            _contenedorTrabajo.Asignacion.Add(tramiteVM.Tramite);
                            _contenedorTrabajo.Save();

                            InsertarTipoGestion(tramiteVM);

                            return RedirectToAction(nameof(Index));   
                    }
                    else
                    {
                     
                        ModelState.AddModelError("Tramite.NumeroPlaca", placaValida);
                    }
                }
            }
            catch (Exception ex)
            {
               
            }

            tramiteVM.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
            tramiteVM.ListaTipoGestion = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("TIPO_GESTION");
            return View(tramiteVM);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Asignacion.GetAll(includeProperties: "OrganismosDeTransito") });
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                TramiteVM tramiteVM = new TramiteVM()
                {
                    Tramite = new Tramite(),
                    ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito(),
                    ListaTipoGestion = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("TIPO_GESTION"),
                    SelectedTipoGestionIds = _contenedorTrabajo.TipoGestion.GetAll(tipoGestion => tipoGestion.TramiteId == id)
                                                     .Select(tipoGestion => tipoGestion.TipoGestionId)
                                                     .ToArray()
            };

                if (id != null)
                {
                    tramiteVM.Tramite = _contenedorTrabajo.Tramite.Get(id.GetValueOrDefault());
                }

                return View(tramiteVM);
            }
            catch (Exception ex)
            {
               
                return View();
            }

        }

        [HttpPost]
        public IActionResult Edit(TramiteVM tramiteVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tramiteVM.Tramite.IdUsuarioAsignacion = _userManager.GetUserId(User);

                    //Logica para actualizar en BD
                    _contenedorTrabajo.Asignacion.Actualizar(tramiteVM.Tramite);
                    _contenedorTrabajo.Save();

                    InsertarTipoGestion(tramiteVM);

                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
               
            }

            tramiteVM.ListaOrganismosTransito = _contenedorTrabajo.OrganismoTransito.GetListaOrganismosTransito();
            tramiteVM.ListaTipoGestion = _contenedorTrabajo.TipoCasuistica.GetListaTipoCasuisticaPorModulo("TIPO_GESTION");
            return View(tramiteVM);
        }

        private void InsertarTipoGestion(TramiteVM tramiteVM)
        {
            try
            {
                if (tramiteVM.Tramite.Id != 0)
                {
                    var tipoRevision = _contenedorTrabajo.TipoGestion.
                                               GetAll(tipoGestion => tipoGestion.TramiteId == tramiteVM.Tramite.Id).ToArray();

                    if (tipoRevision.Any())
                    {
                        //Se remueven antes de actualizarlos
                        _contenedorTrabajo.TipoGestion.RemoveRange(tipoRevision);
                        _contenedorTrabajo.Save();
                    }
                }

                if (tramiteVM.SelectedTipoGestionIds != null)
                {
                    foreach (var tipoGestionId in tramiteVM.SelectedTipoGestionIds)
                    {
                        _contenedorTrabajo.TipoGestion.Add(new TipoGestion()
                        {
                            TramiteId = tramiteVM.Tramite.Id,
                            TipoGestionId = tipoGestionId
                        });
                        _contenedorTrabajo.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                errorLog.RegistrarError(ex.Message, nameof(AsignacionesController));
            }
        }
    }
}
