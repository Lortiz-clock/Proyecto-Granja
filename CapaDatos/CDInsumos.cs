using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos {
    public class CDInsumos {
        CDConnection conn = new CDConnection();

        // 1. Método para obtener la lista de Proveedores (para ComboBox)
        public List<dynamic> MtdListaProveedores() {
            List<dynamic> ListaProveedores = new List<dynamic>();
            string QueryListaProveedores = "SELECT CodigoProveedor, NombreProveedor FROM tbl_Proveedores WHERE Estado = 'Activo'";

            SqlCommand lc = new SqlCommand(QueryListaProveedores, conn.MtdAbrirConexion());
            SqlDataReader reader = lc.ExecuteReader();

            while(reader.Read()) {
                ListaProveedores.Add(new {
                    Value = reader["CodigoProveedor"],
                    Text = $"{reader["CodigoProveedor"]} - {reader["NombreProveedor"]}"
                });
            }
            conn.MtdCerrarConexion();
            return ListaProveedores;
        }

        // 2. Método para consultar todos los Insumos (para DataGridView)
        public DataTable MtdConsultaInsumos() {
            string QueryConsultaInsumos = @"
                SELECT 
                    i.CodigoInsumo, i.CodigoProveedor, i.NombreInsumo, i.TipoInsumo, 
                    i.CostoUnitario, i.UnidadMedida, i.Peso, i.Observacion, i.Estado, 
                    p.NombreProveedor 
                FROM tbl_Insumos i
                INNER JOIN tbl_Proveedores p ON i.CodigoProveedor = p.CodigoProveedor;";

            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultaInsumos, conn.MtdAbrirConexion());
            DataTable dtInsumos = new DataTable();
            sqlAdap.Fill(dtInsumos);
            conn.MtdCerrarConexion();
            return dtInsumos;
        }

        // 3. Método para Agregar Insumos (Create)
        public void MtdAgregarInsumo(int CodigoProveedor, string NombreInsumo, string TipoInsumo, decimal CostoUnitario, string UnidadMedida, decimal Peso, string Observacion, string Estado) {
            string QueryAgregarInsumo = @"
                INSERT INTO tbl_Insumos(CodigoProveedor, NombreInsumo, TipoInsumo, CostoUnitario, UnidadMedida, Peso, Observacion, Estado)  
                VALUES(@CodigoProveedor, @NombreInsumo, @TipoInsumo, @CostoUnitario, @UnidadMedida, @Peso, @Observacion, @Estado)";

            SqlCommand commAgregarInsumo = new SqlCommand(QueryAgregarInsumo, conn.MtdAbrirConexion());

            commAgregarInsumo.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            commAgregarInsumo.Parameters.AddWithValue("@NombreInsumo", NombreInsumo);
            commAgregarInsumo.Parameters.AddWithValue("@TipoInsumo", TipoInsumo);
            commAgregarInsumo.Parameters.AddWithValue("@CostoUnitario", CostoUnitario);
            commAgregarInsumo.Parameters.AddWithValue("@UnidadMedida", UnidadMedida);
            commAgregarInsumo.Parameters.AddWithValue("@Peso", Peso);
            commAgregarInsumo.Parameters.AddWithValue("@Observacion", Observacion);
            commAgregarInsumo.Parameters.AddWithValue("@Estado", Estado);

            commAgregarInsumo.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        // 4. Método para Eliminar Insumos (Delete)
        public void MtdEliminarInsumo(int CodigoInsumo) {
            string QueryEliminarInsumo = "DELETE FROM tbl_Insumos WHERE CodigoInsumo = @CodigoInsumo";

            SqlCommand commEliminarInsumo = new SqlCommand(QueryEliminarInsumo, conn.MtdAbrirConexion());
            commEliminarInsumo.Parameters.AddWithValue("@CodigoInsumo", CodigoInsumo);
            commEliminarInsumo.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        // 5. Método para actualizar insumos (Updare)
        public void MtdActualizarInsumo(int CodigoInsumo, int CodigoProveedor, string NombreInsumo, string TipoInsumo, decimal CostoUnitario, string UnidadMedida, decimal Peso, string Observacion, string Estado) {
            string QueryActualizarInsumo = @"
            UPDATE tbl_Insumos SET 
                CodigoProveedor = @CodigoProveedor,
                NombreInsumo = @NombreInsumo,
                TipoInsumo = @TipoInsumo,
                CostoUnitario = @CostoUnitario,
                UnidadMedida = @UnidadMedida,
                Peso = @Peso,
                Observacion = @Observacion,
                Estado = @Estado
            WHERE CodigoInsumo = @CodigoInsumo";

            SqlCommand commActualizarInsumo = new SqlCommand(QueryActualizarInsumo, conn.MtdAbrirConexion());

            commActualizarInsumo.Parameters.AddWithValue("@CodigoInsumo", CodigoInsumo);

            commActualizarInsumo.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            commActualizarInsumo.Parameters.AddWithValue("@NombreInsumo", NombreInsumo);
            commActualizarInsumo.Parameters.AddWithValue("@TipoInsumo", TipoInsumo);
            commActualizarInsumo.Parameters.AddWithValue("@CostoUnitario", CostoUnitario);
            commActualizarInsumo.Parameters.AddWithValue("@UnidadMedida", UnidadMedida);
            commActualizarInsumo.Parameters.AddWithValue("@Peso", Peso);
            commActualizarInsumo.Parameters.AddWithValue("@Observacion", Observacion);
            commActualizarInsumo.Parameters.AddWithValue("@Estado", Estado);

            commActualizarInsumo.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
    }
}