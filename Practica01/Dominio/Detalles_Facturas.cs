using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Dominio
{
    public class Detalles_Facturas
    {
        public int Id_detalle {  get; set; }
        public int Id_factura { get; set; }
        public int Articulo { get; set; }
        public int Cantidad {  get; set; }

        public Detalles_Facturas (int id_detalle, int id_factura, int articulo, int cantidad)
        {
            Id_detalle = id_detalle;
            Id_factura = id_factura;
            Articulo = articulo;
            Cantidad = cantidad;
        }

    }
}
