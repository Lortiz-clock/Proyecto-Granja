using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDCultivos
    {
        CDConnection conn = new CDConnection();
        // 1. Método para obtener la lista de granjas (para ComboBox)
        public List<dynamic> MtdListaGranjas()
        {
            List<dynamic> ListaGranjas = new List<dynamic>();
            string QueryListaGranjas = "SELECT CodigoGranja, DireccionGranja FROM tbl_Granja WHERE EstadoGranja = 'Activa'";

            SqlCommand lc = new SqlCommand(QueryListaGranjas, conn.MtdAbrirConexion());
            SqlDataReader reader = lc.ExecuteReader();

            while (reader.Read())
            {
                ListaGranjas.Add(new
                {
                    Value = reader["CodigoGranja"],
                    Text = $"{reader["CodigoGranja"]} - {reader["DireccionGranja"]}"
                });
            }
            conn.MtdCerrarConexion();
            return ListaGranjas;
        }

        // 2. Método para consultar todos los Cultivos (para DataGridView)
        public DataTable MtdConsultaCultivos()
        {
            string QueryConsultaCultivos = "SELECT * FROM tbl_Cultivos;";

            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultaCultivos, conn.MtdAbrirConexion());
            DataTable dtCultivos = new DataTable();
            sqlAdap.Fill(dtCultivos);
            conn.MtdCerrarConexion();
            return dtCultivos;
        }

        // 3. Método para Agregar Cultivos (Create)
        public void MtdAgregarCultivo(int CodigoGranja, string TipoCultivo, DateTime FechaSiembra, DateTime FechaCosecha, decimal CantidadCosecha, decimal Precio, string Ubicacion, string Observacion, string Estado)
        {
            string QueryAgregarCultivo = @"
                INSERT INTO tbl_Cultivos(CodigoGranja, TipoCultivo, FechaSiembra, FechaCosecha, CantidadCosecha, Precio, Ubicacion, Observacion, Estado)  
                VALUES(@CodigoGranja, @TipoCultivo, @FechaSiembra, @FechaCosecha, @CantidadCosecha, @Precio, @Ubicacion, @Observacion, @Estado)";

            SqlCommand commAgregarCultivo = new SqlCommand(QueryAgregarCultivo, conn.MtdAbrirConexion());

            commAgregarCultivo.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            commAgregarCultivo.Parameters.AddWithValue("@TipoCultivo", TipoCultivo);
            commAgregarCultivo.Parameters.AddWithValue("@FechaSiembra", FechaSiembra);
            commAgregarCultivo.Parameters.AddWithValue("@FechaCosecha", FechaCosecha);
            commAgregarCultivo.Parameters.AddWithValue("@CantidadCosecha", CantidadCosecha);
            commAgregarCultivo.Parameters.AddWithValue("@Precio", Precio);
            commAgregarCultivo.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            commAgregarCultivo.Parameters.AddWithValue("@Observacion", Observacion);
            commAgregarCultivo.Parameters.AddWithValue("@Estado", Estado);

            commAgregarCultivo.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        // 4. Método para Eliminar Cultivos (Delete)
        public void MtdEliminarCultivo(int CodigoCultivo)
        {
            string QueryEliminarCultivo = "DELETE FROM tbl_Cultivos WHERE CodigoCultivo = @CodigoCultivo";

            SqlCommand commEliminarCultivo = new SqlCommand(QueryEliminarCultivo, conn.MtdAbrirConexion());
            commEliminarCultivo.Parameters.AddWithValue("@CodigoCultivo", CodigoCultivo);
            commEliminarCultivo.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        // 5. Método para Actualizar Cultivos (Update)
        public void MtdActualizarCultivo(int CodigoCultivo, int CodigoGranja, string TipoCultivo, DateTime FechaSiembra, DateTime FechaCosecha, decimal CantidadCosecha, decimal Precio, string Ubicacion, string Observacion, string Estado)
        {
            string QueryActualizarCultivo = @"
                UPDATE tbl_Cultivos SET 
                    CodigoGranja = @CodigoGranja,
                    TipoCultivo = @TipoCultivo,
                    FechaSiembra = @FechaSiembra,
                    FechaCosecha = @FechaCosecha,
                    CantidadCosecha = @CantidadCosecha,
                    Precio = @Precio,
                    Ubicacion = @Ubicacion,
                    Observacion = @Observacion,
                    Estado = @Estado
                WHERE CodigoCultivo = @CodigoCultivo";

            SqlCommand commActualizarCultivo = new SqlCommand(QueryActualizarCultivo, conn.MtdAbrirConexion());

            commActualizarCultivo.Parameters.AddWithValue("@CodigoCultivo", CodigoCultivo);

            commActualizarCultivo.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            commActualizarCultivo.Parameters.AddWithValue("@TipoCultivo", TipoCultivo);
            commActualizarCultivo.Parameters.AddWithValue("@FechaSiembra", FechaSiembra);
            commActualizarCultivo.Parameters.AddWithValue("@FechaCosecha", FechaCosecha);
            commActualizarCultivo.Parameters.AddWithValue("@CantidadCosecha", CantidadCosecha);
            commActualizarCultivo.Parameters.AddWithValue("@Precio", Precio);
            commActualizarCultivo.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            commActualizarCultivo.Parameters.AddWithValue("@Observacion", Observacion);
            commActualizarCultivo.Parameters.AddWithValue("@Estado", Estado);

            commActualizarCultivo.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
    }
}