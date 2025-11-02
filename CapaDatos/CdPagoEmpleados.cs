using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CdPagoEmpleados
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public DataTable MtdObtenerEmpleados()
        {
            string query = "SELECT CodigoEmpleado, NombreEmpleado FROM tbl_Empleado";
            SqlCommand cmd = new SqlCommand(query, conn.MtdAbrirConexion());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.MtdCerrarConexion();

            // Crear columna concatenada
            dt.Columns.Add("NombreCompleto", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                row["NombreCompleto"] = $"{row["CodigoEmpleado"]} ";
            }//- {row["NombreEmpleado"]}

            return dt;
        }


        public DataTable MtdMostrarPagos()
        {
            string query = "SELECT * FROM tbl_PagoEmpleado";
            SqlCommand cmd = new SqlCommand(query, conn.MtdAbrirConexion());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.MtdCerrarConexion();
            return dt;
        }
        public void MtdAgregarDatos(int CodigoEmpleado, decimal SalarioBase, int HorasExtra, decimal Bonos, decimal Descuentos, decimal SalarioFinal, DateTime FechaPago, string Estado)
        {
            string query = "INSERT INTO tbl_PagoEmpleado (CodigoEmpleado, SalarioBase, HorasExtra, Bonos, Descuentos, SalarioFinal, FechaPago, Estado) " +
                           "VALUES (@CodigoEmpleado, @SalarioBase, @HorasExtra, @Bonos, @Descuentos, @SalarioFinal, @FechaPago, @Estado)";

            SqlCommand cmd = new SqlCommand(query, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            cmd.Parameters.AddWithValue("@SalarioBase", SalarioBase);
            cmd.Parameters.AddWithValue("@HorasExtra", HorasExtra);
            cmd.Parameters.AddWithValue("@Bonos", Bonos);
            cmd.Parameters.AddWithValue("@Descuentos", Descuentos);
            cmd.Parameters.AddWithValue("@SalarioFinal", SalarioFinal);
            cmd.Parameters.AddWithValue("@FechaPago", FechaPago);
            cmd.Parameters.AddWithValue("@Estado", Estado);

            cmd.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEditarDatos(int CodigoPagoEmpleado, int CodigoEmpleado, decimal SalarioBase, int HorasExtra, decimal Bonos, decimal Descuentos, decimal SalarioFinal, DateTime FechaPago, string Estado)
        {
            string query = "UPDATE tbl_PagoEmpleado SET " +
                           "CodigoEmpleado = @CodigoEmpleado, " +
                           "SalarioBase = @SalarioBase, " +
                           "HorasExtra = @HorasExtra, " +
                           "Bonos = @Bonos, " +
                           "Descuentos = @Descuentos, " +
                           "SalarioFinal = @SalarioFinal, " +
                           "FechaPago = @FechaPago, " +
                           "Estado = @Estado " +
                           "WHERE CodigoPagoEmpleado = @CodigoPagoEmpleado";

            SqlCommand cmd = new SqlCommand(query, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoPagoEmpleado", CodigoPagoEmpleado);
            cmd.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            cmd.Parameters.AddWithValue("@SalarioBase", SalarioBase);
            cmd.Parameters.AddWithValue("@HorasExtra", HorasExtra);
            cmd.Parameters.AddWithValue("@Bonos", Bonos);
            cmd.Parameters.AddWithValue("@Descuentos", Descuentos);
            cmd.Parameters.AddWithValue("@SalarioFinal", SalarioFinal);
            cmd.Parameters.AddWithValue("@FechaPago", FechaPago);
            cmd.Parameters.AddWithValue("@Estado", Estado);

            cmd.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEliminarDatos(int CodigoPagoEmpleado)
        {
            string query = "DELETE FROM tbl_PagoEmpleado WHERE CodigoPagoEmpleado = @CodigoPagoEmpleado";
            SqlCommand cmd = new SqlCommand(query, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoPagoEmpleado", CodigoPagoEmpleado);
            cmd.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
    }
}