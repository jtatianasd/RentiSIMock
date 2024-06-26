﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentiSI.Modelos;

namespace RentiSI.AccesoDatos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Tramite> Tramite { get; set; }
        public DbSet<Gestion> Gestion { get; set; }
        public DbSet<Revision> Revision { get; set; }
        public DbSet<Recepcion> Recepcion { get; set; }
        public DbSet<Reasignacion> Reasignacion { get; set; }
        public DbSet<Impronta> Impronta { get; set; }
        public DbSet<OrganismosDeTransito> OrganismosDeTransito { get; set; }
        public DbSet<TipoCasuistica> TipoCasuistica { get; set; }
        public DbSet<TramiteCasuistica> TramiteCasuistica { get; set; }
        public DbSet<RevisionCasuistica> RevisionCasuistica { get; set; }

        public DbSet<GestionCasuistica> GestionCasuistica { get; set; }
        public DbSet<TipoGestion> TipoTramite { get; set; }
        public DbSet<TipoDetalleEstado> TipoDetalleEstado { get; set; }

        public DbSet<TipoGestion> TipoGestion { get; set; }




    }
}
