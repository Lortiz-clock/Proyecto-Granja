using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLVentas
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public double MtdTotalVenta(int CodigoVenta)
        {

            SqlCommand cmd = new SqlCommand("Select isnull(sum(TotalVenta),0) as TotalVenta from tbl_Ventas where CodigoVenta=@CodigoVenta", conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);

            object resultado = cmd.ExecuteScalar();
            conn.MtdCerrarConexion();

            return resultado != null ? Convert.ToDouble(resultado) : 0;
        }

    }
}
