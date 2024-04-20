using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos.viewModels
{
    public class ReasignacionVM
    {
        public Tramite? Tramite { get; set; }   
        public Gestion? Gestion { get; set; }
        public TipoDetalleEstado? DetalleEstado { get; set; }
        public Guid[] UsuariosTramiteIds { get; set; }
        public IEnumerable<SelectListItem>? ListaUsuarios { get; set; }
        public IEnumerable<SelectListItem>? ListaDetalleEstado { get; set; }
        public string? NombreCasuisticas { get; set; }
        public OrganismosDeTransito? OrganismosDeTransito { get; set; }
        public string? UsuarioGestion { get; set; }
    }
}
