using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.Modelos.viewModels
{
    public class ResponseViewModel
    {

        public Tramite? Tramite { get; set; }

        public Recepcion? Recepcion { get; set; }

        public Revision? Revision { get; set; }

        public string NumeroPlaca { get; set; }
        public int RevisionId { get; set; }

        public int GestionId { get; set; }
        public int ImprontaId { get; set; }

        public int TramiteId { get; set; }

        public string? FechaRevision { get; set; }

        public string TipificacionTramiteRevision { get; set; }

        public OrganismosDeTransito? OrganismosDeTransito { get; set; }

        public string? FechaRecepcion { get; set; }

        public int RecepcionId { get; set; }

        public string Impronta { get; set; }

        public string FechaAsignacion { get; set; }

        public string? UsuarioRecibe { get; set; }

        public string? Observacion { get; set; }

        public bool EsFechaRecepcion { get; set; }

        public bool EsResuelto { get; set; }

        public IEnumerable<SelectListItem>? ListaOrganismosTransito { get; set; }

        public IEnumerable<SelectListItem>? ListaTipoTramite { get; set; }

        public int[]? SelectedCasuisticasIds { get; set; }


        public IEnumerable<SelectListItem>? ListaCasuisticas { get; set; }




    }
}
