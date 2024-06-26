﻿using RentiSI.Modelos;
using RentiSI.Modelos.viewModels;

namespace RentiSI.AccesoDatos.Data.Repository.IRepository
{
    public interface IRecepcionRepository : IRepository<Recepcion>
    {
        IEnumerable<ResponseViewModel> ObtenerRecepciones();

        ResponseViewModel ObtenerRecepcionesPorId(int RevisionId);

        void Actualizar(Recepcion recepcion);
    }

}
