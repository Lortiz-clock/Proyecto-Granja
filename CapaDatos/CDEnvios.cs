using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDEnvios
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }


        public DataTable MtdConsultaEnvios()
        {
            string QueryConsultaEnvios = "select * from tbl_Ventas";
            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultaEnvios, conn.MtdAbrirConexion());
            DataTable dtEnvios = new DataTable();
            sqlAdap.Fill(dtEnvios);
            conn.MtdCerrarConexion();
            return dtEnvios;
        }

        public List<dynamic> MtdListaEnvios()
        {
            List<dynamic> ListaEnvios = new List<dynamic>();
            string QueryListaEnvios = "select * from tbl_Envios";
            SqlCommand le = new SqlCommand(QueryListaEnvios, conn.MtdAbrirConexion());
            SqlDataReader reader = le.ExecuteReader();

            while (reader.Read())
            {
                ListaEnvios.Add(new
                {
                    Value = reader["CodigoEnvio"]

                });
            }
            conn.MtdCerrarConexion();
            return ListaEnvios;
        }

        public DataTable MtdCargarDatos()
        {
            string QueryCargarDatos = "select CodigoEnvio,CodigoVenta, FechaEnvio,DireccionEnvio,TipoTransporte,PlacaTransporte,Observacion,Estado from tbl_Envios order by FechaEnvio asc";
            SqlDataAdapter SqlAdap = new SqlDataAdapter(QueryCargarDatos, conn.MtdAbrirConexion());
            DataTable dtCargarDatos = new DataTable();
            SqlAdap.Fill(dtCargarDatos);
            conn.MtdCerrarConexion();
            return dtCargarDatos;
        }

        public string MtdListasEnviosDgv(int CodigoEnvio)
        {
            string resultado = string.Empty;
            string QueryListaEnvios = "select * from tbl_Envios where CodigoEnvio = @CodigoEnvio";
            SqlCommand cmd = new SqlCommand(QueryListaEnvios, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoEnvio", CodigoEnvio);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string codigo = reader["CodigoEnvio"].ToString();

                resultado = $"{codigo}";
            }
            else
            {
                resultado = string.Empty;
            }
            conn.MtdCerrarConexion();
            return resultado;
        }

        public void MtdAgregarEnvio(int CodigoVenta, DateTime FechaEnvio, string DireccionEnvio, string TipoTransporte, string PlacaTransporte, string Observacion, string Estado)
        {
            string QueryAgregarEnvio = "insert into tbl_Envios(CodigoVenta, FechaEnvio, DireccionEnvio, TipoTransporte,PlacaTransporte,Observacion, Estado)  values(@CodigoVenta, @FechaEnvio, @DireccionEnvio, @TipoTransporte,@PlacaTransporte,@Observacion, @Estado)";
            SqlCommand commeAgregarEnvio = new SqlCommand(QueryAgregarEnvio, conn.MtdAbrirConexion());
            commeAgregarEnvio.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            commeAgregarEnvio.Parameters.AddWithValue("@FechaEnvio", FechaEnvio);
            commeAgregarEnvio.Parameters.AddWithValue("@DireccionEnvio", DireccionEnvio);
            commeAgregarEnvio.Parameters.AddWithValue("@TipoTransporte", TipoTransporte);
            commeAgregarEnvio.Parameters.AddWithValue("@PlacaTransporte", PlacaTransporte);
            commeAgregarEnvio.Parameters.AddWithValue("@Observacion", Observacion);
            commeAgregarEnvio.Parameters.AddWithValue("@Estado", Estado);
            commeAgregarEnvio.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }


        public void MtdActualizarEnvio(int CodigoEnvio, int CodigoVenta, DateTime FechaEnvio, string DireccionEnvio, string TipoTransporte, string PlacaTransporte, string Observacion, string Estado)
        {
            string QueryActualizarEnvio = "update tbl_Envios set CodigoVenta = @CodigoVenta,FechaEnvio = @FechaEnvio,DireccionEnvio = @DireccionEnvio,TipoTransporte = @TipoTransporte,PlacaTransporte = @PlacaTransporte,Observacion = @Observacion,Estado = @Estado where CodigoEnvio = @CodigoEnvio";
            SqlCommand commeActualizarEnvio = new SqlCommand(QueryActualizarEnvio, conn.MtdAbrirConexion());
            commeActualizarEnvio.Parameters.AddWithValue("@CodigoEnvio", CodigoEnvio);
            commeActualizarEnvio.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            commeActualizarEnvio.Parameters.AddWithValue("@FechaEnvio", FechaEnvio);
            commeActualizarEnvio.Parameters.AddWithValue("@DireccionEnvio", DireccionEnvio);
            commeActualizarEnvio.Parameters.AddWithValue("@TipoTransporte", TipoTransporte);
            commeActualizarEnvio.Parameters.AddWithValue("@PlacaTransporte", PlacaTransporte);
            commeActualizarEnvio.Parameters.AddWithValue("@Observacion", Observacion);
            commeActualizarEnvio.Parameters.AddWithValue("@Estado", Estado);
            commeActualizarEnvio.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEliminarEnvios(int CodigoEnvio)
        {
            string QueryEliminarEnvios = "delete tbl_Envios where CodigoEnvio = @CodigoEnvio";
            SqlCommand commeEliminarEnvios = new SqlCommand(QueryEliminarEnvios, conn.MtdAbrirConexion());
            commeEliminarEnvios.Parameters.AddWithValue("@CodigoEnvio", CodigoEnvio);
            commeEliminarEnvios.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }



    }
}
