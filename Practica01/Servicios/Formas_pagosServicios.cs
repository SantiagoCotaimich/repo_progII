using Practica01.Datos;
using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Servicios
{
    public class Formas_pagosServicios
    {
        private IRepositorioFormas_pagos _repositorio;

        public Formas_pagosServicios()
        {
            _repositorio = new RepositorioFormas_pagos_ADO();
        }

        public List<Formas_pagos> GetAll()
        {
            return _repositorio.GetAll();
        }

        public Formas_pagos GetById(int id)
        {
            return _repositorio.GetById(id);
        }

        public bool Borrar(int id)
        {
            return _repositorio.Borrar(id);
        }

        public bool Guardar(Formas_pagos oForma_pago)
        {
            return _repositorio.Guardar(oForma_pago);
        }

    }
}
