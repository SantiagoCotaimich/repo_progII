using Practica01.Datos;
using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Servicios
{
    public class Detalles_FacturasServicios
    {
        private IRepositorioDetalles_Facturas _repositorio;

        public Detalles_FacturasServicios()
        {
            _repositorio = new RepositorioDetalles_Facturas_ADO();
        }

        public List<Detalles_Facturas> GetAll()
        {
            return _repositorio.GetAll();
        }

        public Detalles_Facturas GetById(int id)
        {
            return _repositorio.GetById(id);
        }

        public bool Borrar(int id)
        {
            return _repositorio.Borrar(id);
        }

        public bool Guardar(Detalles_Facturas oDetalles)
        {
            return _repositorio.Guardar(oDetalles);
        }

    }
}
