using System;
using System.Collections.Generic;
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
    }
}
