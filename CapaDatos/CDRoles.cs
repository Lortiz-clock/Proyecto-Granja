using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDRoles
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public DataTable MdtConsultarDatos()
        {
            string QueryRoles = "select * from tbl_Roles";
            SqlDataAdapter Adap = new SqlDataAdapter(QueryRoles, conn.MtdAbrirConexion());
            DataTable dtRoles = new DataTable();
            Adap.Fill(dtRoles);
            conn.MtdCerrarConexion();
            return dtRoles;
        }

        public DataTable MtdCargarDatos()
        {
            string QueryCargar = "select CodigoRol, NombreRol, Estado from tbl_Roles order by CodigoRol";
            SqlDataAdapter Adap = new SqlDataAdapter(QueryCargar, conn.MtdAbrirConexion());
            DataTable dtCargar = new DataTable();
            Adap.Fill(dtCargar);
            conn.MtdCerrarConexion();
            return dtCargar;
        }

        public void MtdEliminarDatos(int CodigoRol)
        {
            string QueryEliminar = "delete tbl_Roles where CodigoRol = @CodigoRol";
            SqlCommand CommandEliminar = new SqlCommand(QueryEliminar, conn.MtdAbrirConexion());
            CommandEliminar.Parameters.AddWithValue("@CodigoRol", CodigoRol);
            CommandEliminar.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdAgregarDatos(string NombreRol, string Estado)
        {
            string QueryAgregar = ("Insert into tbl_Roles(NombreRol, Estado) Values (@NombreRol, @Estado)");
            SqlCommand CommanAgregarDato = new SqlCommand(QueryAgregar, conn.MtdAbrirConexion());
            CommanAgregarDato.Parameters.AddWithValue("@NombreRol", NombreRol);
            CommanAgregarDato.Parameters.AddWithValue("@Estado", Estado);
            CommanAgregarDato.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEditarDatos(int CodigoRol, string NombreRol, string Estado)
        {
            string QueryEditar = "update tbl_Roles set NombreRol = @NombreRol, Estado = @Estado where CodigoRol = @CodigoRol";
            SqlCommand CommandEditar = new SqlCommand(QueryEditar, conn.MtdAbrirConexion());
            CommandEditar.Parameters.AddWithValue("@CodigoRol", CodigoRol);
            CommandEditar.Parameters.AddWithValue("@NombreRol", NombreRol);
            CommandEditar.Parameters.AddWithValue("@Estado", Estado);
            CommandEditar.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
    }
}
