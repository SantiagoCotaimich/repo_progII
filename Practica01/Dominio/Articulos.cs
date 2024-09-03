using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Dominio
{
    public class Artículos
    {
        public int Id_articulo {  get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }

        public Artículos(int id_articulo, string nombre, double precioUnitario) 
        {
            Id_articulo = id_articulo;
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
        }

    }
}
