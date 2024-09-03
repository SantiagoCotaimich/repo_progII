using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public interface IRepositorioDetalles_Facturas
    {
        List<Detalles_Facturas> GetAll();

        Detalles_Facturas GetById(int id);

        bool Guardar(Detalles_Facturas oDetalles);

        bool Borrar(int id);
    }
}
