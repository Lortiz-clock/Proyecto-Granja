using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDEmpleados
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public DataTable ConsultarDatos()
        {
            string QueryEmpleados = "select * from tbl_Empleado";
            SqlDataAdapter Adap = new SqlDataAdapter(QueryEmpleados, conn.MtdAbrirConexion());
            DataTable dtEmpleados = new DataTable();
            Adap.Fill(dtEmpleados);
            conn.MtdCerrarConexion();
            return dtEmpleados;
        }

        public DataTable MtdCargarDatos()
        {
            string QueryCargar = "select CodigoEmpleado, CodigoGranja, NombreEmpleado, TelefonoEmpleado, CorreoEmpleado, Cargo, FechaIngreso, Estado from tbl_Empleado order by NombreEmpleado";
            SqlDataAdapter Adap = new SqlDataAdapter(QueryCargar, conn.MtdAbrirConexion());
            DataTable dtCargar = new DataTable();
            Adap.Fill(dtCargar);
            conn.MtdCerrarConexion();
            return dtCargar;
        }

        public void MtdEliminarDatos(int CodigoEmpleado)
        {
            string QueryEliminar = "delete tbl_Empleado where CodigoEmpleado = @CodigoEmpleado";
            SqlCommand CommeEliminar = new SqlCommand(QueryEliminar, conn.MtdAbrirConexion());
            CommeEliminar.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommeEliminar.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdAgregarDatos(string NombreEmpleado, string TelefonoEmpleado, string CorreoEmpleado, string Cargo, DateTime FechaIngreso, string Estado)
        {
            string QueryAgregar = "Insert into tbl_Empleado(NombreEmpleado, TelefonoEmpleado, CorreoEmpleado, Cargo, FechaIngreso, Estado) Values (@NombreEmpleado, @TelefonoEmpleado, @CorreoEmpleado, @Cargo, @FechaIngreso, @Estado)";
            SqlCommand CommeAgregar = new SqlCommand(QueryAgregar, conn.MtdAbrirConexion());
            CommeAgregar.Parameters.AddWithValue("@NombreEmpleado", NombreEmpleado);
            CommeAgregar.Parameters.AddWithValue("@TelefonoEmpleado", TelefonoEmpleado);
            CommeAgregar.Parameters.AddWithValue("@CorreoEmpleado", CorreoEmpleado);
            CommeAgregar.Parameters.AddWithValue("@Cargo", Cargo);
            CommeAgregar.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            CommeAgregar.Parameters.AddWithValue("@Estado", Estado);
            CommeAgregar.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEditarDatos(int CodigoEmpleado, string NombreEmpleado, string TelefonoEmpleado, string CorreoEmpleado, string Cargo, DateTime FechaIngreso, string Estado)
        {
            string QueryEditar = "Update tbl_Empleado set NombreEmpleado = @NombreEmpleado, TelefonoEmpleado = @TelefonoEmpleado, CorreoEmpleado = @CorreoEmpleado, Cargo = @Cargo, FechaIngreso = @FechaIngreso, Estado = @Estado where CodigoEmpleado = @CodigoEmpleado";
            SqlCommand CommeEditar = new SqlCommand(QueryEditar, conn.MtdAbrirConexion());
            CommeEditar.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommeEditar.Parameters.AddWithValue("@NombreEmpleado", NombreEmpleado);
            CommeEditar.Parameters.AddWithValue("@TelefonoEmpleado", TelefonoEmpleado);
            CommeEditar.Parameters.AddWithValue("@CorreoEmpleado", CorreoEmpleado);
            CommeEditar.Parameters.AddWithValue("@Cargo", Cargo);
            CommeEditar.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            CommeEditar.Parameters.AddWithValue("@Estado", Estado);
            CommeEditar.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

    }

}
