using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos.viewModels
{
    public class RevisionViewModel
    {
        public string NumeroPlaca { get; set; }
        public int RevisionId { get; set; }

        public string FechaRevision { get; set; }

        public string TipificacionTramiteRevision { get; set; }

        public string OrganismoTransito { get; set; }

    }
}
