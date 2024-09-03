using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Dominio
{
    public class Formas_pagos
    {
        public int Id_forma_pago {  get; set; }
        public string Nombre {  get; set; }

        public Formas_pagos(int id_forma_pago, string nombre) 
        {
            Id_forma_pago = id_forma_pago;
            Nombre = nombre;
        }
    }
}
