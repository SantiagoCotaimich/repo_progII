using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public interface IRepositorioFacturas
    {
        List<Facturas> GetAll();

        Facturas GetById (int id);

        bool Guardar(Facturas oFacturas);

        bool Borrar(int id);
    }
}
