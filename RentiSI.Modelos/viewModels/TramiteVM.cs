using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentiSI.Modelos.viewModels
{
    public class TramiteVM
    {
        public Tramite Tramite { get; set; }
        public IEnumerable<SelectListItem>? ListaOrganismosTransito { get; set; }

        public IEnumerable<SelectListItem>? ListaTipoGestion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar al menos un tipo de gestión.")]
        [MinLength(1, ErrorMessage = "Debe seleccionar al menos un tipo de gestión.")]
        public int[]? SelectedTipoGestionIds { get; set; }

        public TipoGestion? TipoGestion { get; set; }
    }
}
