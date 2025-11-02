using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClPagoVenta
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public double MtdTotalPagoVenta(decimal CodigoPagoVenta)
        {

            SqlCommand cmd = new SqlCommand("Select isnull(sum(Monto),0) as Monto from tbl_PagosVentas where CodigoPagoVenta=@CodigoPagoVenta", conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoPagoVenta", CodigoPagoVenta);

            object resultado = cmd.ExecuteScalar();
            conn.MtdCerrarConexion();

            return resultado != null ? Convert.ToDouble(resultado) : 0;
        }


    }
}
