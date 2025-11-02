using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDVentas
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public DataTable MtdConsultaVentas()
        {
            string QueryConsultaVentas = "select * from tbl_Ventas";
            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultaVentas, conn.MtdAbrirConexion());
            DataTable dtVentas = new DataTable();
            sqlAdap.Fill(dtVentas);
            conn.MtdCerrarConexion();
            return dtVentas;
        }


        public List<dynamic> MtdListaClientes()
        {
            List<dynamic> ListaClientes = new List<dynamic>();
            string QueryListaClientes = "select * from tbl_Clientes";
            SqlCommand lc = new SqlCommand(QueryListaClientes, conn.MtdAbrirConexion());
            SqlDataReader reader = lc.ExecuteReader();

            while (reader.Read())
            {
                ListaClientes.Add(new
                {
                    Value = reader["CodigoCliente"],
                    Text = $"{reader["CodigoCliente"]} - {reader["NombreCliente"]}"
                });
            }
            conn.MtdCerrarConexion();
            return ListaClientes;
        }


        public string MtdListasClientesDgv(int CodigoCliente)
        {
            string resultado = string.Empty;
            string QueryListaClientes = "select * from tbl_Clientes where CodigoCliente = @CodigoCliente";
            SqlCommand cmd = new SqlCommand(QueryListaClientes, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string codigo = reader["CodigoCliente"].ToString();
                string nombre = reader["NombreCliente"].ToString();
                resultado = $"{codigo} - {nombre}";
            }
            else
            {
                resultado = string.Empty;
            }
            conn.MtdCerrarConexion();
            return resultado;
        }




        public void MtdAgregarVentas(int CodigoCliente, DateTime FechaVenta, string TipoVenta, double TotalVenta, string Estado)
        {
            string QueryAgregarVentas = "insert into tbl_Ventas(CodigoCliente, FechaVenta, TipoVenta, TotalVenta, Estado)   values(@CodigoCliente, @FechaVenta, @TipoVenta, @TotalVenta, @Estado)";
            SqlCommand commeAgregarVentas = new SqlCommand(QueryAgregarVentas, conn.MtdAbrirConexion());
            commeAgregarVentas.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            commeAgregarVentas.Parameters.AddWithValue("@FechaVenta", FechaVenta);
            commeAgregarVentas.Parameters.AddWithValue("@TipoVenta", TipoVenta);
            commeAgregarVentas.Parameters.AddWithValue("@TotalVenta", TotalVenta);
            commeAgregarVentas.Parameters.AddWithValue("@Estado", Estado);
            commeAgregarVentas.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }


        public void MtdActualizarVentas(int CodigoVenta, int CodigoCliente, DateTime FechaVenta, string TipoVenta, double TotalVenta, string Estado)
        {
            string QueryActualizarVentas = "update tbl_Ventas set CodigoCliente = @CodigoCliente,FechaVenta = @FechaVenta,TipoVenta = @TipoVenta,TotalVenta = @TotalVenta,Estado = @Estado where CodigoVenta = @CodigoVenta";
            SqlCommand commeActualizarVentas = new SqlCommand(QueryActualizarVentas, conn.MtdAbrirConexion());
            commeActualizarVentas.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            commeActualizarVentas.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            commeActualizarVentas.Parameters.AddWithValue("@FechaVenta", FechaVenta);
            commeActualizarVentas.Parameters.AddWithValue("@TipoVenta", TipoVenta);
            commeActualizarVentas.Parameters.AddWithValue("@TotalVenta", TotalVenta);
            commeActualizarVentas.Parameters.AddWithValue("@Estado", Estado);
            commeActualizarVentas.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEliminarVentas(int CodigoVenta)
        {
            string QueryEliminarVentas = "delete tbl_Ventas where CodigoVenta = @CodigoVenta";
            SqlCommand commeEliminarVentas = new SqlCommand(QueryEliminarVentas, conn.MtdAbrirConexion());
            commeEliminarVentas.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            commeEliminarVentas.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
    }
}
