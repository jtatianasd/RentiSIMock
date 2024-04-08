using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos.viewModels
{
    public class ResponseViewModel
    {
        public string NumeroPlaca { get; set; }
        public int RevisionId { get; set; }

        public string FechaRevision { get; set; }

        public string TipificacionTramiteRevision { get; set; }

        public string OrganismoTransito { get; set; }

        public string FechaRecepcion { get; set; }

        public int RecepcionId { get; set; }

        public string Impronta { get; set; }

        public string FechaAsignacion { get; set; }

        public string UsuarioRecibe { get; set; }



    }
}
