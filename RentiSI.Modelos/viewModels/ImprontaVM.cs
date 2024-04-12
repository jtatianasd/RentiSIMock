using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos.viewModels
{
    public class ImprontaVM
    {
        public Tramite Tramite { get; set; }
        public Recepcion Recepcion { get; set; }
        public Impronta Impronta { get; set; }
        public TipoCasuistica TipoCasuistica { get; set; }
        public OrganismosDeTransito OrganismosDeTransito { get; set; }
        public TramiteCasuistica TramiteCasuistica { get; set; }
        public IEnumerable<SelectListItem>? ListaOrganismosTransito { get; set; }
        public IEnumerable<SelectListItem>? ListaCasuisticas { get; set; }

    }
}
