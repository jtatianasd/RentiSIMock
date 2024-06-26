﻿using Microsoft.AspNetCore.Mvc.Rendering;
using RentiSI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentiSI.AccesoDatos.Data.Repository.IRepository
{
    public interface ITipoCasuisticaRepository : IRepository<TipoCasuistica>
    {
        IEnumerable<SelectListItem> GetListaTipoCasuistica();
        IEnumerable<SelectListItem> GetListaTipoCasuisticaPorModulo(string modulo);
    }
}
