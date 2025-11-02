using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDGranja
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public DataTable MtdConsultarGranja()
        {
            string QueryConsultarGranja = "select * from tbl_Granja";
            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultarGranja, conn.MtdAbrirConexion());
            DataTable dtGranja = new DataTable();
            sqlAdap.Fill(dtGranja);
            conn.MtdCerrarConexion();
            return dtGranja;
        }

        // Carga de datos

        public DataTable MtdCargarDatos()
        {
            string QueryCargarDatos = "select CodigoGranja, DireccionGranja, TelefonoGranja, CorreoGranja, CodigoPostalGranja, EstadoGranja from tbl_Granja order by DireccionGranja Asc";
            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryCargarDatos, conn.MtdAbrirConexion());
            DataTable dtCargarDatos = new DataTable();
            sqlAdap.Fill(dtCargarDatos);
            conn.MtdCerrarConexion();
            return dtCargarDatos;
        }

        public void MtdEliminarDatos(int CodigoGranja)
        {
            string QueryEliminarDatos = "delete tbl_Granja where CodigoGranja = @CodigoGranja";
            SqlCommand CommeEliminarDatos = new SqlCommand(QueryEliminarDatos, conn.MtdAbrirConexion());
            CommeEliminarDatos.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            CommeEliminarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdAgregarDatos(string DireccionGranja, string TelefonoGranja, string CorreoGranja, int CodigoPostalGranja, string EstadoGranja)
        {
            string QueryAgregarDatos = "Insert into tbl_Granja(DireccionGranja, TelefonoGranja, CorreoGranja, CodigoPostalGranja, EstadoGranja) Values (@DireccionGranja, @TelefonoGranja, @CorreoGranja, @CodigoPostalGranja, @EstadoGranja)";
            SqlCommand CommeAgregarDatos = new SqlCommand(QueryAgregarDatos, conn.MtdAbrirConexion());
            CommeAgregarDatos.Parameters.AddWithValue("@DireccionGranja", DireccionGranja);
            CommeAgregarDatos.Parameters.AddWithValue("@TelefonoGranja", TelefonoGranja);
            CommeAgregarDatos.Parameters.AddWithValue("@CorreoGranja", CorreoGranja);
            CommeAgregarDatos.Parameters.AddWithValue("@CodigoPostalGranja", CodigoPostalGranja);
            CommeAgregarDatos.Parameters.AddWithValue("@EstadoGranja", EstadoGranja);
            CommeAgregarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEditarDatos(int CodigoGranja, string DireccionGranja, string TelefonoGranja, string CorreoGranja, int CodigoPostalGranja, string EstadoGranja)
        {
            string QueryEditarDatos = "update tbl_Granja set DireccionGranja = @DireccionGranja, TelefonoGranja = @TelefonoGranja, CorreoGranja = @CorreoGranja, CodigoPostalGranja = @CodigoPostalGranja, EstadoGranja = @EstadoGranja where CodigoGranja = @CodigoGranja";
            SqlCommand commanEditarDatos = new SqlCommand(QueryEditarDatos, conn.MtdAbrirConexion());
            commanEditarDatos.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            commanEditarDatos.Parameters.AddWithValue("@DireccionGranja", DireccionGranja);
            commanEditarDatos.Parameters.AddWithValue("@TelefonoGranja", TelefonoGranja);
            commanEditarDatos.Parameters.AddWithValue("@CorreoGranja", CorreoGranja);
            commanEditarDatos.Parameters.AddWithValue("@CodigoPostalGranja", CodigoPostalGranja);
            commanEditarDatos.Parameters.AddWithValue("@Estado", EstadoGranja);
            commanEditarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public List<dynamic> MtdListaGranja()
        {
            List<dynamic> ListaGranja = new List<dynamic>();
            string QueryListaGranja = "select * from tbl_Granja";
            SqlCommand lc = new SqlCommand(QueryListaGranja, conn.MtdAbrirConexion());
            SqlDataReader reader = lc.ExecuteReader();

            while (reader.Read())
            {
                ListaGranja.Add(new
                {
                    Value = reader["CodigoGranja"],
                    Text = $"{reader["CodigoGranja"]} - {reader["EstadoGranja"]}"
                });
            }
            conn.MtdCerrarConexion();
            return ListaGranja;
        }

        public string MtdListasGranjaDgv(int CodigoGranja)
        {
            string resultado = string.Empty;
            string QueryListaGranja = "select * from tbl_Granja where CodigoGranja = @CodigoGranja";
            SqlCommand cmd = new SqlCommand(QueryListaGranja, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string codigo = reader["CodigoGranja"].ToString();
                string nombre = reader["EstadoGranja"].ToString();
                resultado = $"{codigo} - {nombre}";
            }
            else
            {
                resultado = string.Empty;
            }
            conn.MtdCerrarConexion();
            return resultado;

        }
    }
}
