using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Dominio
{
    public class Facturas
    {
        public int NroFactura {  get; set; }
        public DateTime Fecha { get; set; }
        public int Id_formaPago { get; set; }
        public string Cliente { get; set; }

        public Facturas(int nrofactura, DateTime fecha, int id_formapago, string cliente)
        {
            NroFactura = nrofactura;
            Fecha = fecha;
            Id_formaPago = id_formapago;
            Cliente = cliente;
        }

    }
}
