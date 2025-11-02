using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDClientes
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public DataTable MtdConsultaClientes()
        {
            string QueryConsultaClientes = "select * from tbl_Clientes";
            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultaClientes, conn.MtdAbrirConexion());
            DataTable dtClientes = new DataTable();
            sqlAdap.Fill(dtClientes);
            conn.MtdCerrarConexion();
            return dtClientes;
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

        //Metodo para carga de datos
        public DataTable MtdCargarDatos()
        {
            string QueryCargarDatos = "select CodigoCliente,NombreCliente, TipoCliente,Telefono,Correo,Direccion,Estado from tbl_Clientes order by NombreCliente asc";
            SqlDataAdapter SqlAdap = new SqlDataAdapter(QueryCargarDatos, conn.MtdAbrirConexion());
            DataTable dtCargarDatos = new DataTable();
            SqlAdap.Fill(dtCargarDatos);
            conn.MtdCerrarConexion();
            return dtCargarDatos;
        }

        //Metodo para Eliminar datos de la base de datos
        public void MtdEliminarDatos(int CodigoCliente)
        {
            string QueryEliminarDatos = "delete tbl_Clientes where CodigoCliente = @CodigoCliente";
            SqlCommand CommeEliminarDatos = new SqlCommand(QueryEliminarDatos, conn.MtdAbrirConexion());
            CommeEliminarDatos.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            CommeEliminarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
        //Metodo para Agregar datos de la base de datos
        public void MtdAgregarDatos(string NombreCliente, string TipoCliente, string Telefono, string Correo, string Direccion, string Estado)
        {
            string QueryAgregarDatos = "insert into tbl_Clientes(NombreCliente,TipoCliente,Telefono,Correo,Direccion,Estado) values (@NombreCliente,@TipoCliente,@Telefono,@Correo,@Direccion,@Estado)";
            SqlCommand CommeAgregarDatos = new SqlCommand(QueryAgregarDatos, conn.MtdAbrirConexion());
            CommeAgregarDatos.Parameters.AddWithValue("@NombreCliente", NombreCliente);
            CommeAgregarDatos.Parameters.AddWithValue("@TipoCliente", TipoCliente);
            CommeAgregarDatos.Parameters.AddWithValue("@Telefono", Telefono);
            CommeAgregarDatos.Parameters.AddWithValue("@Correo", Correo);
            CommeAgregarDatos.Parameters.AddWithValue("@Direccion", Direccion);
            CommeAgregarDatos.Parameters.AddWithValue("@Estado", Estado);
            CommeAgregarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
        //Metodo para Editar datos de la base de datos
        public void MtdEditarDatos(int CodigoCliente, string NombreCliente, string TipoCliente, string Telefono, string Correo, string Direccion, string Estado)
        {
            string QueryEditarDatos = "update tbl_Clientes set NombreCliente = @NombreCliente,TipoCliente = @TipoCliente,Telefono = @Telefono,Correo = @Correo,Direccion = @Direccion,Estado = @Estado where  CodigoCliente = @CodigoCliente";
            SqlCommand CommeEditarDatos = new SqlCommand(QueryEditarDatos, conn.MtdAbrirConexion());
            CommeEditarDatos.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            CommeEditarDatos.Parameters.AddWithValue("@NombreCliente", NombreCliente);
            CommeEditarDatos.Parameters.AddWithValue("@TipoCliente", TipoCliente);
            CommeEditarDatos.Parameters.AddWithValue("@Telefono", Telefono);
            CommeEditarDatos.Parameters.AddWithValue("@Correo", Correo);
            CommeEditarDatos.Parameters.AddWithValue("@Direccion", Direccion);
            CommeEditarDatos.Parameters.AddWithValue("@Estado", Estado);
            CommeEditarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
    }
}
