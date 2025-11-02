using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDPagoVentas
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public DataTable MtdConsultaPagosVentas()
        {
            string QueryConsultaPagosVentas = "select * from tbl_PagosVentas";
            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultaPagosVentas, conn.MtdAbrirConexion());
            DataTable dtPagoVentas = new DataTable();
            sqlAdap.Fill(dtPagoVentas);
            conn.MtdCerrarConexion();
            return dtPagoVentas;
        }

        public List<dynamic> MtdListaVentas()
        {
            List<dynamic> ListaVentas = new List<dynamic>();
            string QueryListaVentas = "select * from tbl_Ventas";
            SqlCommand lv = new SqlCommand(QueryListaVentas, conn.MtdAbrirConexion());
            SqlDataReader reader = lv.ExecuteReader();

            while (reader.Read())
            {
                ListaVentas.Add(new
                {
                    Value = reader["CodigoVenta"],
                    Text = $"{reader["CodigoVenta"]}"
                });
            }
            conn.MtdCerrarConexion();
            return ListaVentas;
        }


        public string MtdListasVentasDgv(int CodigoVenta)
        {
            string resultado = string.Empty;
            string QueryListaVentas = "select * from tbl_Ventas where CodigoVenta = @CodigoVenta";
            SqlCommand cmd = new SqlCommand(QueryListaVentas, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string Codigo = reader["CodigoVenta"].ToString();

                resultado = $"{Codigo}";
            }
            else
            {
                resultado = string.Empty;
            }
            conn.MtdCerrarConexion();
            return resultado;
        }

        public void MtdAgregarPagosVentas(int CodigoVenta, double Monto, string TipoPago, string NumeroReferencia, DateTime FechaPago, string Estado)
        {
            string QueryAgregarPagoVentas = "insert into tbl_PagosVentas(CodigoVenta, Monto, TipoPago, NumeroReferencia,FechaPago, Estado)   values(@CodigoVenta, @Monto, @TipoPago, @NumeroReferencia,@FechaPago, @Estado)";
            SqlCommand commeAgregarPagoVentas = new SqlCommand(QueryAgregarPagoVentas, conn.MtdAbrirConexion());
            commeAgregarPagoVentas.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            commeAgregarPagoVentas.Parameters.AddWithValue("@Monto", Monto);
            commeAgregarPagoVentas.Parameters.AddWithValue("@TipoPago", TipoPago);
            commeAgregarPagoVentas.Parameters.AddWithValue("@NumeroReferencia", NumeroReferencia);
            commeAgregarPagoVentas.Parameters.AddWithValue("@FechaPago", FechaPago);
            commeAgregarPagoVentas.Parameters.AddWithValue("@Estado", Estado);
            commeAgregarPagoVentas.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }


        public void MtdActualizarPagosVentas(int CodigoPagoVenta, int CodigoVenta, double Monto, string TipoPago, string NumeroReferencia, DateTime FechaPago, string Estado)
        {
            string QueryActualizarPagoVentas = "update tbl_PagosVentas set CodigoVenta = @CodigoVenta,Monto = @Monto,TipoPago = @TipoPago,NumeroReferencia = @NumeroReferencia,FechaPago = @FechaPago,Estado = @Estado where CodigoPagoVenta = @CodigoPagoVenta)";
            SqlCommand commeAgregarPagoVentas = new SqlCommand(QueryActualizarPagoVentas, conn.MtdAbrirConexion());
            commeAgregarPagoVentas.Parameters.AddWithValue("@CodigoPagoVenta", CodigoPagoVenta);
            commeAgregarPagoVentas.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            commeAgregarPagoVentas.Parameters.AddWithValue("@Monto", Monto);
            commeAgregarPagoVentas.Parameters.AddWithValue("@TipoPago", TipoPago);
            commeAgregarPagoVentas.Parameters.AddWithValue("@NumeroReferencia", NumeroReferencia);
            commeAgregarPagoVentas.Parameters.AddWithValue("@FechaPago", FechaPago);
            commeAgregarPagoVentas.Parameters.AddWithValue("@Estado", Estado);
            commeAgregarPagoVentas.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEliminarPagoVentas(int CodigoPagoVenta)
        {
            string QueryEliminarPagoVentas = "delete tbl_PagosVentas where CodigoPagoVenta = @CodigoPagoVenta";
            SqlCommand commeEliminarPagoVentas = new SqlCommand(QueryEliminarPagoVentas, conn.MtdAbrirConexion());
            commeEliminarPagoVentas.Parameters.AddWithValue("@CodigoPagoVenta", CodigoPagoVenta);
            commeEliminarPagoVentas.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
    }
}
