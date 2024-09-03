using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public class RepositorioFacturas_ADO : IRepositorioFacturas
    {

        private Facturas Mapeo(DataRow row)
        {
            int nro_factura = Convert.ToInt32(row["nro_factura"]);
            DateTime fecha = Convert.ToDateTime(row["fecha"]);
            int id_forma_pago = Convert.ToInt32(row["id_forma_pago"]);
            string cliente = row["cliente"].ToString();
            Facturas oFactura = new Facturas(nro_factura, fecha, id_forma_pago, cliente);
            return oFactura;

        }
        public bool Borrar(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("nro_factura", id));

            var helper = DataHelper.GetInstance();
            return 1 == helper.ExecuteSPNonQuery("SP_Borrar_Facturas", parametros);

        }

        public List<Facturas> GetAll()
        {
            List<Facturas> facturas= new List<Facturas>();
            var helper = DataHelper.GetInstance();
            var dt = helper.ExecuteSPQuery("SP_Obtener_Todas_Facturas", null);

            foreach (DataRow row in dt.Rows)
            {
                Facturas oFactura = Mapeo(row);
                facturas.Add(oFactura);
                
            }

            return facturas;
        }

        public Facturas GetById(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@nro_factura", id));
            var helper = DataHelper.GetInstance();
            var dt = helper.ExecuteSPQuery("SP_Obtener_Facturas_ID", parametros);

            if (dt != null && dt.Rows.Count == 1)
            {
                Facturas oFacturas = Mapeo(dt.Rows[0]);
                return oFacturas;
            }
            return null;
        }



        public bool Guardar(Facturas oFacturas)
        {
            bool result = false;
            var parametros = new List<ParameterSQL>();
            if (oFacturas != null)
            {
                parametros.Add(new ParameterSQL("@nro_factura", oFacturas.NroFactura));
                parametros.Add(new ParameterSQL("@fecha", oFacturas.Fecha));
                parametros.Add(new ParameterSQL("@id_forma_pago", oFacturas.Id_formaPago));
                parametros.Add(new ParameterSQL("@cliente", oFacturas.Cliente));
                int filasAfectadas = DataHelper.GetInstance().ExecuteSPNonQuery("SP_Actualizar_Facturas", parametros);
                result = filasAfectadas > 0;
            }
            return result;
        }
    }
}
