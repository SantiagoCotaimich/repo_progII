using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    internal class RepositorioDetalles_Facturas_ADO : IRepositorioDetalles_Facturas
    {

        private Detalles_Facturas Mapeo(DataRow row)
        {
            int id_detalle_factura = Convert.ToInt32(row["id_detalle_factura"]);
            int id_articulo = Convert.ToInt32(row["id_articulo"]);
            int nro_factura = Convert.ToInt32(row["nro_factura"]);
            int cantidad = Convert.ToInt32(row["cantidad"]);
            Detalles_Facturas oDetalle_factura = new Detalles_Facturas(id_detalle_factura, id_articulo, nro_factura, cantidad);
            return oDetalle_factura;

        }
        public bool Borrar(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("id_detalle_factura", id));

            var helper = DataHelper.GetInstance();
            return 1 == helper.ExecuteSPNonQuery("SP_Borrar_Detalles_Facturas", parametros);

        }

        public List<Detalles_Facturas> GetAll()
        {
            List<Detalles_Facturas> detalles_facturas = new List<Detalles_Facturas>();
            var helper = DataHelper.GetInstance();
            var dt = helper.ExecuteSPQuery("SP_Obtener_Todos_Detalles_Facturas", null);

            foreach (DataRow row in dt.Rows)
            {
                Detalles_Facturas oDetalles = Mapeo(row);
                detalles_facturas.Add(oDetalles);

            }

            return detalles_facturas;
        }


        public Detalles_Facturas GetById(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_detalle_factura", id));
            var helper = DataHelper.GetInstance();
            var dt = helper.ExecuteSPQuery("SP_Obtener_Detalles_Facturas_ID", parametros);

            if (dt != null && dt.Rows.Count == 1)
            {
                Detalles_Facturas oDetalles = Mapeo(dt.Rows[0]);
                return oDetalles;
            }
            return null;
        }

        public bool Guardar(Detalles_Facturas oDetalles)
        {
            bool result = false;
            var parametros = new List<ParameterSQL>();
            if (oDetalles != null)
            {
                parametros.Add(new ParameterSQL("@id_detalle_factura", oDetalles.Id_detalle));
                parametros.Add(new ParameterSQL("@id_articulo", oDetalles.Articulo));
                parametros.Add(new ParameterSQL("@nro_factura", oDetalles.Id_factura));
                parametros.Add(new ParameterSQL("@cantidad", oDetalles.Cantidad));
                int filasAfectadas = DataHelper.GetInstance().ExecuteSPNonQuery("SP_Actualizar_Detalles_Facturas", parametros);
                result = filasAfectadas > 0;
            }
            return result;
        }
    }
}
