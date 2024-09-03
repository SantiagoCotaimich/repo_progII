using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private string _cnnString;
        private SqlConnection _cnn;

        private DataHelper() 
        {
            _cnnString = @"Data Source=SANTIAGO\SQLEXPRESS;Initial Catalog=Facturación;Integrated Security=True;TrustServerCertificate=True";
            _cnn = new SqlConnection(_cnnString);
        }

        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }


        public DataTable ExecuteSPQuery(string StoredProcedure, List<ParameterSQL>? parametros)
        {
            DataTable dt = new DataTable();

            try
            {
                _cnn.Open();
                var cmd = new SqlCommand(StoredProcedure, _cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var param in parametros)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }
                dt.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                dt = null;
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
            return dt;

        }

        public int ExecuteSPNonQuery(string sp, List<ParameterSQL>? parametros)
        {
            int affectedRows;

            try
            {
                _cnn.Open();
                var cmd = new SqlCommand(sp, _cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw ex;
                affectedRows = 0;
            }
            finally
            {
                _cnn.Close();
            }

            return affectedRows;
        }

    }
}
