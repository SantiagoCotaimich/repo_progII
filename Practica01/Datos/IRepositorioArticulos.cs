using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public interface IRepositorioArticulos
    {
        List<Artículos> GetAll();

        Artículos GetById(int id);

        bool Guardar(Artículos oArticulos);

        bool Borrar(int id);
    }
}
