using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDAnimales
    {
        CDConnection conn = new CDConnection();
        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public DataTable MtdConsultaAnimales()
        {
            string QueryConsultaAnimales = "select * from tbl_Animales";
            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultaAnimales, conn.MtdAbrirConexion());
            DataTable dtAnimales = new DataTable();
            sqlAdap.Fill(dtAnimales);
            conn.MtdCerrarConexion();
            return dtAnimales;
        }

        public DataTable MtdCargarDatos()
        {
            string QueryCargarDatos = "select CodigoAnimal, CodigoGranja, TipoAnimal, Raza, FechaNacimiento, Precio, Descripcion, Estado from tbl_Animales order by CodigoAnimal asc";
            SqlDataAdapter SqlAdap = new SqlDataAdapter(QueryCargarDatos, conn.MtdAbrirConexion());
            DataTable dtCargarDatos = new DataTable();
            SqlAdap.Fill(dtCargarDatos);
            conn.MtdCerrarConexion();
            return dtCargarDatos;
        }

        public void MtdEliminarDatos(int CodigoAnimal)
        {
            string QueryEliminarDatos = "delete tbl_Animales where CodigoAnimal = @CodigoAnimal";
            SqlCommand CommeEliminarDatos = new SqlCommand(QueryEliminarDatos, conn.MtdAbrirConexion());
            CommeEliminarDatos.Parameters.AddWithValue("@CodigoAnimal", CodigoAnimal);
            CommeEliminarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdAgregarDatos(string TipoAnimal, string Raza, DateTime FechaNacimiento, double Precio, string Descripcion, string Estado)
        {
            string QueryAgregarDatos = "insert into tbl_Animales(TipoAnimal,Raza,FechaNacimiento,Precio,Descripcion,Estado) values (@TipoAnimal,@Raza,@FechaNacimiento,@Precio,@Descripcion,@Estado)";
            SqlCommand CommeAgregarDatos = new SqlCommand(QueryAgregarDatos, conn.MtdAbrirConexion());
            CommeAgregarDatos.Parameters.AddWithValue("@TipoAnimal", TipoAnimal);
            CommeAgregarDatos.Parameters.AddWithValue("@Raza", Raza);
            CommeAgregarDatos.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            CommeAgregarDatos.Parameters.AddWithValue("@Precio", Precio);
            CommeAgregarDatos.Parameters.AddWithValue("@Descripcion", Descripcion);
            CommeAgregarDatos.Parameters.AddWithValue("@Estado", Estado);
            CommeAgregarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEditarDatos(int CodigoAnimal, string TipoAnimal, string Raza, DateTime FechaNacimiento, double Precio, string Descripcion, string Estado)
        {
            string QueryEditarDatos = "update tbl_Animales set TipoAnimal = @TipoAnimal,Raza = @Raza,FechaNacimiento = @FechaNacimiento,Precio = @Precio,Descripcion = @Descripcion,Estado = @Estado where  CodigoAnimal = @CodigoAnimal";
            SqlCommand CommeEditarDatos = new SqlCommand(QueryEditarDatos, conn.MtdAbrirConexion());
            CommeEditarDatos.Parameters.AddWithValue("@CodigoAnimal", CodigoAnimal);
            CommeEditarDatos.Parameters.AddWithValue("@TipoAnimal", TipoAnimal);
            CommeEditarDatos.Parameters.AddWithValue("@Raza", Raza);
            CommeEditarDatos.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            CommeEditarDatos.Parameters.AddWithValue("@Precio", Precio);
            CommeEditarDatos.Parameters.AddWithValue("@Descripcion", Descripcion);
            CommeEditarDatos.Parameters.AddWithValue("@Estado", Estado);
            CommeEditarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }


    }
}
