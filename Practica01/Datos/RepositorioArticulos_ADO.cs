using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public class RepositorioArticulos_ADO : IRepositorioArticulos
    {

        private Artículos Mapeo(DataRow row)
        {
            int id_articulo = Convert.ToInt32(row["id_articulo"]);
            string nombre = row["nombre"].ToString();
            double precio_Unitario = Convert.ToDouble(row["precio_Unitario"]);
            Artículos oArticulo = new Artículos(id_articulo, nombre, precio_Unitario);
            return oArticulo;

        }
        public bool Borrar(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("id_articulo", id));

            var helper = DataHelper.GetInstance();
            return 1 == helper.ExecuteSPNonQuery("SP_Borrar_Articulos", parametros);

        }

        public List<Artículos> GetAll()
        {
            List<Artículos> articulos = new List<Artículos>();
            var helper = DataHelper.GetInstance();
            var dt = helper.ExecuteSPQuery("SP_Obtener_Todos_Articulos", null);

            foreach (DataRow row in dt.Rows)
            {
                Artículos oArticulo = Mapeo(row);
                articulos.Add(oArticulo);
            }

            return articulos;
        }

        public Artículos GetById(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_articulo", id));
            var helper = DataHelper.GetInstance();
            var dt = helper.ExecuteSPQuery("SP_Obtener_Articulos_ID", parametros);

            if (dt != null && dt.Rows.Count == 1)
            {
                Artículos oArticulo = Mapeo(dt.Rows[0]);
                return oArticulo;
            }
            return null;
        }



        public bool Guardar(Artículos oArticulos)
        {
            bool result = false;
            var parametros = new List<ParameterSQL>();
            if (oArticulos != null)
            {
                parametros.Add(new ParameterSQL("@id_articulo", oArticulos.Id_articulo));
                parametros.Add(new ParameterSQL("@nombre", oArticulos.Nombre));
                parametros.Add(new ParameterSQL("@precio_Unitario", oArticulos.PrecioUnitario));
                int filasAfectadas = DataHelper.GetInstance().ExecuteSPNonQuery("SP_Actualizar_Articulos", parametros);
                result = filasAfectadas > 0;
            }
            return result;
        }

    }
}
