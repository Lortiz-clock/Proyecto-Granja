using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class CDProductos
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public DataTable MtdConsultaProductos()
        {
            string QueryConsultaProductos = "select * from tbl_Productos;";
            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultaProductos, conn.MtdAbrirConexion());
            DataTable dtProductos = new DataTable();
            sqlAdap.Fill(dtProductos);
            conn.MtdCerrarConexion();
            return dtProductos;
        }

        public List<dynamic> MtdListaGranjas()
        {
            List<dynamic> ListaGranjas = new List<dynamic>();
            string QueryListaGranjas = "select * from tbl_Clientes";
            SqlCommand lg = new SqlCommand(QueryListaGranjas, conn.MtdAbrirConexion());
            SqlDataReader reader = lg.ExecuteReader();

            while (reader.Read())
            {
                ListaGranjas.Add(new
                {
                    Value = reader["CodigoGranja"],
                    Text = $"{reader["CodigoGranja"]} - {reader["EstadoGranja"]}"
                });
            }
            conn.MtdCerrarConexion();
            return ListaGranjas;
        }

        public string MtdListasGranjasDgv(int CodigoGranja)
        {
            string resultado = string.Empty;
            string QueryListaGranjas = "select * from tbl_Granja where CodigoGranja = @CodigoGranja";
            SqlCommand cmd = new SqlCommand(QueryListaGranjas, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string codigo = reader["CodigoGranja"].ToString();
                string estado = reader["EstadoGranja"].ToString();
                resultado = $"{codigo} - {estado}";
            }
            else
            {
                resultado = string.Empty;
            }
            conn.MtdCerrarConexion();
            return resultado;
        }

        public void MtdAgregarProductos(int CodigoGranja, string NombreProducto, string TipoProducto, string DescripcionProducto, string Estado)
        {
            string QueryAgregarProductos = "insert into tbl_Productos(CodigoGranja, NombreProducto, TipoProducto, DescripcionProducto, Estado) \tvalues(@CodigoGranja, @NombreProducto, @TipoProducto, @DescripcionProducto, @Estado)";
            SqlCommand commeAgregarProductos = new SqlCommand(QueryAgregarProductos, conn.MtdAbrirConexion());
            commeAgregarProductos.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            commeAgregarProductos.Parameters.AddWithValue("@NombreProducto", NombreProducto);
            commeAgregarProductos.Parameters.AddWithValue("@TipoProducto", TipoProducto);
            commeAgregarProductos.Parameters.AddWithValue("@DescripcionProducto", DescripcionProducto);
            commeAgregarProductos.Parameters.AddWithValue("@Estado", Estado);
            commeAgregarProductos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdActualizarProductos(int CodigoProducto, int CodigoGranja, string NombreProducto, string TipoProducto, string DescripcionProducto, string Estado)
        {
            string QueryActualizarProductos = "update tbl_Productos set CodigoGranja = @CodigoGranja,NombreProducto = @NombreProducto,TipoProducto = @TipoProducto,DescripcionProducto = @DescripcionProducto,Estado = @Estado where CodigoProducto = @CodigoProducto";
            SqlCommand commeActualizarProductos = new SqlCommand(QueryActualizarProductos, conn.MtdAbrirConexion());
            commeActualizarProductos.Parameters.AddWithValue("@CodigoProducto", CodigoProducto);
            commeActualizarProductos.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            commeActualizarProductos.Parameters.AddWithValue("@NombreProducto", NombreProducto);
            commeActualizarProductos.Parameters.AddWithValue("@TipoProducto", TipoProducto);
            commeActualizarProductos.Parameters.AddWithValue("@DescripcionProducto", DescripcionProducto);
            commeActualizarProductos.Parameters.AddWithValue("@Estado", Estado);
            commeActualizarProductos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEliminarProducto(int CodigoProducto)
        {
            string QueryEliminarProducto = "delete tbl_Productos where CodigoProducto = @CodigoProducto";
            SqlCommand commeEliminarProducto = new SqlCommand(QueryEliminarProducto, conn.MtdAbrirConexion());
            commeEliminarProducto.Parameters.AddWithValue("@CodigoProducto", CodigoProducto);
            commeEliminarProducto.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

    }
}

