using EntityLibreria;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLibreria
{
    public class DBCategoria
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public List<EntCategoria> ObtenerC()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Categorias", cnn);
            da.Fill(dt);

            List<EntCategoria> ec = new List<EntCategoria>();
            foreach (DataRow dr in dt.Rows)
            {
                EntCategoria c = new EntCategoria();
                c.IdC = Convert.ToInt32(dr["IdC"]);
                c.NombreC = dr["NombreC"].ToString();
                ec.Add(c);
            }
            return ec;
        }
    }
}
