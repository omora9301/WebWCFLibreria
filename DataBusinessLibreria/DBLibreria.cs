using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using EntityLibreria;

namespace DataBusinessLibreria
{
    public class DBLibreria
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public List<EntLibreria> Obtener() 
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Id,Titulo,Autor,Categoria,Editorial,Edicion,ISBN,IdC,NombreC from Libros inner join Categorias on Libros.Categoria = Categorias.IdC ", cnn);
            //SqlDataAdapter da = new SqlDataAdapter("select Id, Titulo, Autor, isnull(Categoria, 0) as Categoria, Editorial, Edicion, ISBN,ISNULL(IdC, 0) as IdC, ISNULL(NombreC, 'N/A') as NombreC from Libros inner join Categorias on Libros.Categoria = Categorias.IdC order by Titulo", cnn);
            da.Fill(dt);

            List<EntLibreria> list = new List<EntLibreria>();
            foreach (DataRow dr in dt.Rows)
            {
                EntLibreria el = new EntLibreria();
                EntCategoria ec = new EntCategoria();

                el.Id = Convert.ToInt32(dr["Id"]);
                el.Titulo = dr["Titulo"].ToString();
                el.Autor = dr["Autor"].ToString();
                el.Categoria = Convert.ToInt32(dr["Categoria"]);
                el.Editorial = dr["Editorial"].ToString();
                el.Edicion = dr["Edicion"].ToString();
                el.ISBN = dr["ISBN"].ToString();

                ec.IdC = Convert.ToInt32(dr["IdC"]);
                ec.NombreC = dr["NombreC"].ToString();

                el.EntCategoria = ec;

                list.Add(el);
            }
            return list;
        }
        public EntLibreria IdObtener(int id) 
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"Select * from Libros where Id ={id} ", cnn);
            da.Fill(dt);
            DataRow dr = dt.Rows[0];

            EntLibreria lib = new EntLibreria();
            lib.Id = Convert.ToInt32(dr["Id"]);
            lib.Titulo = dr["Titulo"].ToString();
            lib.Autor = dr["Autor"].ToString();
            lib.Categoria = Convert.ToInt32(dr["Categoria"]);
            lib.Editorial = dr["Editorial"].ToString();
            lib.Edicion = dr["Edicion"].ToString();
            lib.ISBN = dr["ISBN"].ToString();
            
            return lib;
        }
        public void Editar(EntLibreria l) 
        {
            int filasafectadas = 0;
            SqlCommand cmd = new SqlCommand($"Update Libros set Titulo = '{l.Titulo}', Autor = '{l.Autor}', Categoria = {l.Categoria}, Editorial = '{l.Editorial}', Edicion ='{l.Edicion}', ISBN ='{l.ISBN}' where Id =" + l.Id, cnn);
            try
            {
                cnn.Open();
                filasafectadas = cmd.ExecuteNonQuery();
                cnn.Close();
                if (filasafectadas != 1)
                {
                    throw new ApplicationException("Error al editar");
                }
            }
            catch (Exception)
            {
                cnn.Close();
                throw;
            }
        }
        public void Agregar(EntLibreria l) 
        {
            int filasafectadas = 0;
            SqlCommand cmd = new SqlCommand($"Insert into Libros values('{l.Titulo}','{l.Autor}',{l.Categoria},'{l.Editorial}','{l.Edicion}','{l.ISBN}')",cnn);
            try
            {
                cnn.Open();
                filasafectadas = cmd.ExecuteNonQuery();
                cnn.Close();
                if (filasafectadas != 1)
                {
                    throw new ApplicationException("Error al Agregar");
                }
            }
            catch (Exception)
            {
                cnn.Close();
                throw;
            }
        }
        public void Eliminar(int id) 
        {
            int filas_afectadas = 0;
            SqlCommand cmd = new SqlCommand("spEliminar", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                cnn.Open();
                filas_afectadas = cmd.ExecuteNonQuery();
                cnn.Close();
                if (filas_afectadas != 1)
                {
                    throw new ApplicationException("Error al Eliminado");
                }
            }
            catch (Exception)
            {
                cnn.Close();
                throw;
            }
        }
        public List<EntLibreria> Buscar(string Valor) 
        {
            SqlCommand cmd = new SqlCommand("spBuscar", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Valor", Valor);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<EntLibreria> ls = new List<EntLibreria>();
            foreach (DataRow dr in dt.Rows)
            {
                EntLibreria l = new EntLibreria();
                l.Id = Convert.ToInt32(dr["Id"]);
                l.Titulo = dr["Titulo"].ToString();
                l.Autor = dr["Autor"].ToString();
                l.Categoria = Convert.ToInt32(dr["Categoria"]);
                l.Editorial = dr["Editorial"].ToString();
                l.Edicion = dr["Edicion"].ToString();
                l.ISBN = dr["ISBN"].ToString(); 

                ls.Add(l);
            }
            return ls;
        }
        public void ValidarRepetido(EntLibreria l) 
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select * from Libros where ISBN = '{l.ISBN}'", cnn);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                throw new ApplicationException($" El registro { l.ISBN} ya existe ");
            }
        }
    }
}
