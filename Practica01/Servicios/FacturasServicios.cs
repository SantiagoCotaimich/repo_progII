using Practica01.Datos;
using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Servicios
{
    public class FacturasServicios
    {
        private IRepositorioFacturas _repositorio;

        public FacturasServicios()
        {
            _repositorio = new RepositorioFacturas_ADO();
        }

        public List<Facturas> GetAll()
        {
            return _repositorio.GetAll();
        }

        public Facturas GetById(int id)
        {
            return _repositorio.GetById(id);
        }

        public bool Borrar(int id)
        {
            return _repositorio.Borrar(id);
        }

        public bool Guardar(Facturas oFactura)
        {
            return _repositorio.Guardar(oFactura);
        }

    }
}
