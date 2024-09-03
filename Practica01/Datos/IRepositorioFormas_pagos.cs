using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public  interface IRepositorioFormas_pagos
    {
        List<Formas_pagos> GetAll();

        Formas_pagos GetById(int id);

        bool Guardar(Formas_pagos oFormas_pagos);

        bool Borrar(int id);
    }
}
