﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentiSI.AccesoDatos;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240412051234_RenombrarKeyReasignacion")]
    partial class RenombrarKeyReasignacion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RentiSI.Modelos.Gestion", b =>
                {
                    b.Property<int>("GestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GestionId"));

                    b.Property<string>("EstadoGestion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaGestion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaResultado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUsuarioGestion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdUsuarioResuelve")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Id_Tramite")
                        .HasColumnType("int");

                    b.HasKey("GestionId");

                    b.HasIndex("IdUsuarioGestion");

                    b.HasIndex("IdUsuarioResuelve");

                    b.HasIndex("Id_Tramite");

                    b.ToTable("Gestion");
                });

            modelBuilder.Entity("RentiSI.Modelos.Impronta", b =>
                {
                    b.Property<int>("ImprontaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImprontaId"));

                    b.Property<bool?>("EsResultado")
                        .HasColumnType("bit");

                    b.Property<int?>("Id_Tramite")
                        .HasColumnType("int");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganismoDeTransitoId")
                        .HasColumnType("int");

                    b.Property<string>("TipificacionImpronta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImprontaId");

                    b.HasIndex("Id_Tramite");

                    b.HasIndex("OrganismoDeTransitoId");

                    b.ToTable("Impronta");
                });

            modelBuilder.Entity("RentiSI.Modelos.OrganismosDeTransito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Municipio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrganismosDeTransito");
                });

            modelBuilder.Entity("RentiSI.Modelos.Reasignacion", b =>
                {
                    b.Property<int>("ReasignacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReasignacionId"));

                    b.Property<string>("FechaReasignacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUsuarioReasignacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Id_Tramite")
                        .HasColumnType("int");

                    b.HasKey("ReasignacionId");

                    b.HasIndex("IdUsuarioReasignacion");

                    b.HasIndex("Id_Tramite");

                    b.ToTable("Reasignacion");
                });

            modelBuilder.Entity("RentiSI.Modelos.Recepcion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FechaRecepcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUsuarioRecepcion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Id_Tramite")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioRecepcion");

                    b.HasIndex("Id_Tramite");

                    b.ToTable("Recepcion");
                });

            modelBuilder.Entity("RentiSI.Modelos.Revision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EstadoRevision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaRevision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUsuarioRevision")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Id_Tramite")
                        .HasColumnType("int");

                    b.Property<string>("NumeroGuia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganismoTransito")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipificacionCasuisticaRevision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipificacionTramiteRevision")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioRevision");

                    b.HasIndex("Id_Tramite");

                    b.ToTable("Revision");
                });

            modelBuilder.Entity("RentiSI.Modelos.TipoCasuistica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoCasuistica");
                });

            modelBuilder.Entity("RentiSI.Modelos.Tramite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FechaCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaNegocio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Financiacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Impronta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroPlaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganismoDeTransitoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganismoDeTransitoId");

                    b.ToTable("Tramite");
                });

            modelBuilder.Entity("RentiSI.Modelos.TramiteCasuistica", b =>
                {
                    b.Property<int>("Id_tramite")
                        .HasColumnType("int");

                    b.Property<int>("Id_Casuistica")
                        .HasColumnType("int");

                    b.HasKey("Id_tramite", "Id_Casuistica");

                    b.HasIndex("Id_Casuistica");

                    b.ToTable("TramiteCasuistica");
                });

            modelBuilder.Entity("RentiSI.Modelos.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentiSI.Modelos.Gestion", b =>
                {
                    b.HasOne("RentiSI.Modelos.ApplicationUser", "UsuarioGestion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioGestion");

                    b.HasOne("RentiSI.Modelos.ApplicationUser", "UsuarioResuelve")
                        .WithMany()
                        .HasForeignKey("IdUsuarioResuelve");

                    b.HasOne("RentiSI.Modelos.Tramite", "Id_Tramite_Gestion")
                        .WithMany()
                        .HasForeignKey("Id_Tramite");

                    b.Navigation("Id_Tramite_Gestion");

                    b.Navigation("UsuarioGestion");

                    b.Navigation("UsuarioResuelve");
                });

            modelBuilder.Entity("RentiSI.Modelos.Impronta", b =>
                {
                    b.HasOne("RentiSI.Modelos.Tramite", "Id_Tramite_Gestion")
                        .WithMany()
                        .HasForeignKey("Id_Tramite");

                    b.HasOne("RentiSI.Modelos.OrganismosDeTransito", "OrganismosDeTransito")
                        .WithMany()
                        .HasForeignKey("OrganismoDeTransitoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Id_Tramite_Gestion");

                    b.Navigation("OrganismosDeTransito");
                });

            modelBuilder.Entity("RentiSI.Modelos.Reasignacion", b =>
                {
                    b.HasOne("RentiSI.Modelos.ApplicationUser", "UsuarioReasignacion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioReasignacion");

                    b.HasOne("RentiSI.Modelos.Tramite", "Id_Tramite_Gestion")
                        .WithMany()
                        .HasForeignKey("Id_Tramite");

                    b.Navigation("Id_Tramite_Gestion");

                    b.Navigation("UsuarioReasignacion");
                });

            modelBuilder.Entity("RentiSI.Modelos.Recepcion", b =>
                {
                    b.HasOne("RentiSI.Modelos.ApplicationUser", "UsuarioRecepcion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioRecepcion");

                    b.HasOne("RentiSI.Modelos.Tramite", "Id_Tramite_Gestion")
                        .WithMany()
                        .HasForeignKey("Id_Tramite");

                    b.Navigation("Id_Tramite_Gestion");

                    b.Navigation("UsuarioRecepcion");
                });

            modelBuilder.Entity("RentiSI.Modelos.Revision", b =>
                {
                    b.HasOne("RentiSI.Modelos.ApplicationUser", "UsuarioRevision")
                        .WithMany()
                        .HasForeignKey("IdUsuarioRevision");

                    b.HasOne("RentiSI.Modelos.Tramite", "Id_Tramite_Gestion")
                        .WithMany()
                        .HasForeignKey("Id_Tramite");

                    b.Navigation("Id_Tramite_Gestion");

                    b.Navigation("UsuarioRevision");
                });

            modelBuilder.Entity("RentiSI.Modelos.Tramite", b =>
                {
                    b.HasOne("RentiSI.Modelos.OrganismosDeTransito", "OrganismosDeTransito")
                        .WithMany()
                        .HasForeignKey("OrganismoDeTransitoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganismosDeTransito");
                });

            modelBuilder.Entity("RentiSI.Modelos.TramiteCasuistica", b =>
                {
                    b.HasOne("RentiSI.Modelos.TipoCasuistica", "TipoCasuistica")
                        .WithMany()
                        .HasForeignKey("Id_Casuistica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentiSI.Modelos.Tramite", "Tramite")
                        .WithMany()
                        .HasForeignKey("Id_tramite")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoCasuistica");

                    b.Navigation("Tramite");
                });
#pragma warning restore 612, 618
        }
    }
}
