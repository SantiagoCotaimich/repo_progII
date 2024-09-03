using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    internal class RepositorioFormas_pagos_ADO : IRepositorioFormas_pagos
    {

        private Formas_pagos Mapeo(DataRow row)
        {
            int id_forma_pago = Convert.ToInt32(row["id_forma_pago"]);
            string forma_pago = row["forma_pago"].ToString();
            Formas_pagos oForma_pago = new Formas_pagos(id_forma_pago, forma_pago);
            return oForma_pago;

        }
        public bool Borrar(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("id_forma_pago", id));

            var helper = DataHelper.GetInstance();
            return 1 == helper.ExecuteSPNonQuery("SP_Borrar_Formas_pagos", parametros);

        }
        public List<Formas_pagos> GetAll()
        {
            List<Formas_pagos> formas_Pagos = new List<Formas_pagos>();
            var helper = DataHelper.GetInstance();
            var dt = helper.ExecuteSPQuery("SP_Obtener_Todos_Formas_Pagos", null);

            foreach (DataRow row in dt.Rows)
            {
                Formas_pagos oFormas_pagos = Mapeo(row);
                formas_Pagos.Add(oFormas_pagos);

            }

            return formas_Pagos;
        }

        public Formas_pagos GetById(int id)
        {
            var parametros = new List<ParameterSQL>();
            parametros.Add(new ParameterSQL("@id_forma_pago", id));
            var helper = DataHelper.GetInstance();
            var dt = helper.ExecuteSPQuery("SP_Obtener_Formas_pagos_ID", parametros);

            if (dt != null && dt.Rows.Count == 1)
            {
                Formas_pagos oForma_pago = Mapeo(dt.Rows[0]);
                return oForma_pago;
            }
            return null;
        }

        public bool Guardar(Formas_pagos oFormas_pagos)
        {
            bool result = false;
            var parametros = new List<ParameterSQL>();
            if (oFormas_pagos != null)
            {
                parametros.Add(new ParameterSQL("@id_forma_pago", oFormas_pagos.Id_forma_pago));
                parametros.Add(new ParameterSQL("@forma_pago", oFormas_pagos.Nombre));
                int filasAfectadas = DataHelper.GetInstance().ExecuteSPNonQuery("SP_Actualizar_Formas_Pagos", parametros);
                result = filasAfectadas > 0;
            }
            return result;
        }
    }
}
