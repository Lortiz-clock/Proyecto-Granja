using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CdProveedores
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }


        public DataTable MtdMostrarDatos()
        {
            string query = "SELECT * FROM tbl_Proveedores";
            SqlCommand cmd = new SqlCommand(query, conn.MtdAbrirConexion());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.MtdCerrarConexion();
            return dt;
        }


        public void MtdAgregarDatos(string NombreProveedor, string Telefono, string Correo, string Direccion, string Estado)
        {
            string query = "INSERT INTO tbl_Proveedores (NombreProveedor, Telefono, Correo, Direccion, Estado) " +
                           "VALUES (@NombreProveedor, @Telefono, @Correo, @Direccion, @Estado)";

            SqlCommand cmd = new SqlCommand(query, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
            cmd.Parameters.AddWithValue("@Telefono", Telefono);
            cmd.Parameters.AddWithValue("@Correo", Correo);
            cmd.Parameters.AddWithValue("@Direccion", Direccion);
            cmd.Parameters.AddWithValue("@Estado", Estado);

            cmd.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEditarDatos(int CodigoProveedor, string NombreProveedor, string Telefono, string Correo, string Direccion, string Estado)
        {
            string query = "UPDATE tbl_Proveedores SET " +
                           "NombreProveedor = @NombreProveedor, " +
                           "Telefono = @Telefono, " +
                           "Correo = @Correo, " +
                           "Direccion = @Direccion, " +
                           "Estado = @Estado " +
                           "WHERE CodigoProveedor = @CodigoProveedor";

            SqlCommand cmd = new SqlCommand(query, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
            cmd.Parameters.AddWithValue("@Telefono", Telefono);
            cmd.Parameters.AddWithValue("@Correo", Correo);
            cmd.Parameters.AddWithValue("@Direccion", Direccion);
            cmd.Parameters.AddWithValue("@Estado", Estado);

            cmd.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
        public void MtdEliminarDatos(int CodigoProveedor)
        {
            string query = "DELETE FROM tbl_Proveedores WHERE CodigoProveedor = @CodigoProveedor";
            SqlCommand cmd = new SqlCommand(query, conn.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            cmd.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
    }
}
