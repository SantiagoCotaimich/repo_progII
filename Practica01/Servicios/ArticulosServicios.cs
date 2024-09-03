using Practica01.Datos;
using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Servicios
{
    public class ArticulosServicios
    {
        private IRepositorioArticulos _repositorio;

        public ArticulosServicios()
        {
            _repositorio = new RepositorioArticulos_ADO();
        }

        public List<Artículos> GetAll()
        {
            return _repositorio.GetAll();
        }

        public Artículos GetById(int id)
        {
            return _repositorio.GetById(id);
        }

        public bool Borrar(int id) 
        {
            return _repositorio.Borrar(id);
        }

        public bool Guardar(Artículos oArticulo)
        {
            return _repositorio.Guardar(oArticulo);
        }

    }
}
