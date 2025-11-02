// CDInventario.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos {
    public class CDInventario {
        CDConnection conn = new CDConnection();

        public List<dynamic> MtdListaInsumos() {
            List<dynamic> ListaInsumos = new List<dynamic>();
            string QueryListaInsumos = "SELECT CodigoInsumo, NombreInsumo FROM tbl_Insumos WHERE Estado = 'Activo'";

            SqlCommand lc = new SqlCommand(QueryListaInsumos, conn.MtdAbrirConexion());
            SqlDataReader reader = lc.ExecuteReader();

            while(reader.Read()) {
                ListaInsumos.Add(new {
                    Value = reader["CodigoInsumo"],
                    Text = $"{reader["CodigoInsumo"]} - {reader["NombreInsumo"]}"
                });
            }
            conn.MtdCerrarConexion();
            return ListaInsumos;
        }

        public DataTable MtdConsultaInventario() {
            string QueryConsultaInventario = @"
            SELECT 
                inv.CodigoInventario, inv.CodigoInsumo, inv.CodigoGranja, inv.NombreProducto, inv.Tipo, 
                inv.Precio, inv.Stock, inv.FechaIngreso, inv.FechaVencimiento, inv.Estado,
                i.NombreInsumo, g.DireccionGranja
            FROM tbl_Inventario inv
            INNER JOIN tbl_Insumos i ON inv.CodigoInsumo = i.CodigoInsumo
            INNER JOIN tbl_Granja g ON inv.CodigoGranja = g.CodigoGranja;";

            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultaInventario, conn.MtdAbrirConexion());
            DataTable dtInventario = new DataTable();
            sqlAdap.Fill(dtInventario);
            conn.MtdCerrarConexion();
            return dtInventario;
        }

        public List<dynamic> MtdListaGranjas() {
            List<dynamic> ListaGranjas = new List<dynamic>();
            string QueryListaGranjas = "SELECT CodigoGranja, DireccionGranja FROM tbl_Granja WHERE EstadoGranja = 'Activa'";

            SqlCommand lc = new SqlCommand(QueryListaGranjas, conn.MtdAbrirConexion());
            SqlDataReader reader = lc.ExecuteReader();

            while(reader.Read()) {
                ListaGranjas.Add(new {
                    Value = reader["CodigoGranja"],
                    Text = $"{reader["CodigoGranja"]} - {reader["DireccionGranja"]}"
                });
            }
            conn.MtdCerrarConexion();
            return ListaGranjas;
        }



        public void MtdAgregarInventario(int CodigoGranja, int CodigoInsumo, string NombreProducto, string Tipo, decimal Precio, int Stock, DateTime FechaIngreso, DateTime FechaVencimiento, string Estado) {
            string QueryAgregarInventario = @"
            INSERT INTO tbl_Inventario(CodigoGranja, CodigoInsumo, NombreProducto, Tipo, Precio, Stock, FechaIngreso, FechaVencimiento, Estado)  
            VALUES(@CodigoGranja, @CodigoInsumo, @NombreProducto, @Tipo, @Precio, @Stock, @FechaIngreso, @FechaVencimiento, @Estado)";

            SqlCommand commAgregarInventario = new SqlCommand(QueryAgregarInventario, conn.MtdAbrirConexion());

            commAgregarInventario.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            commAgregarInventario.Parameters.AddWithValue("@CodigoInsumo", CodigoInsumo);
            commAgregarInventario.Parameters.AddWithValue("@NombreProducto", NombreProducto);
            commAgregarInventario.Parameters.AddWithValue("@Tipo", Tipo);
            commAgregarInventario.Parameters.AddWithValue("@Precio", Precio);
            commAgregarInventario.Parameters.AddWithValue("@Stock", Stock);
            commAgregarInventario.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            commAgregarInventario.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
            commAgregarInventario.Parameters.AddWithValue("@Estado", Estado);

            commAgregarInventario.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdActualizarInventario(int CodigoInventario, int CodigoGranja, int CodigoInsumo, string NombreProducto, string Tipo, decimal Precio, int Stock, DateTime FechaIngreso, DateTime FechaVencimiento, string Estado) {
            string QueryActualizarInventario = @"
            UPDATE tbl_Inventario SET 
                CodigoGranja = @CodigoGranja,
                CodigoInsumo = @CodigoInsumo,
                NombreProducto = @NombreProducto,
                Tipo = @Tipo,
                Precio = @Precio,
                Stock = @Stock,
                FechaIngreso = @FechaIngreso,
                FechaVencimiento = @FechaVencimiento,
                Estado = @Estado
            WHERE CodigoInventario = @CodigoInventario";

            SqlCommand commActualizarInventario = new SqlCommand(QueryActualizarInventario, conn.MtdAbrirConexion());

            commActualizarInventario.Parameters.AddWithValue("@CodigoInventario", CodigoInventario);
            commActualizarInventario.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            commActualizarInventario.Parameters.AddWithValue("@CodigoInsumo", CodigoInsumo);
            commActualizarInventario.Parameters.AddWithValue("@NombreProducto", NombreProducto);
            commActualizarInventario.Parameters.AddWithValue("@Tipo", Tipo);
            commActualizarInventario.Parameters.AddWithValue("@Precio", Precio);
            commActualizarInventario.Parameters.AddWithValue("@Stock", Stock);
            commActualizarInventario.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            commActualizarInventario.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
            commActualizarInventario.Parameters.AddWithValue("@Estado", Estado);

            commActualizarInventario.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEliminarInventario(int CodigoInventario) {
            string QueryEliminarInventario = "DELETE FROM tbl_Inventario WHERE CodigoInventario = @CodigoInventario";

            SqlCommand commEliminarInventario = new SqlCommand(QueryEliminarInventario, conn.MtdAbrirConexion());
            commEliminarInventario.Parameters.AddWithValue("@CodigoInventario", CodigoInventario);
            commEliminarInventario.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
    }
}