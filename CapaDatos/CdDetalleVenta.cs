
using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CdDetalleVenta
    {
        CDConnection conn = new CDConnection();

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        public DataTable MtdConsultarGranja()
        {
            string QueryConsultarGranja = "SELECT * FROM tbl_VentaDetalle;";
            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryConsultarGranja, conn.MtdAbrirConexion());
            DataTable dtVentaDetalle = new DataTable();
            sqlAdap.Fill(dtVentaDetalle);
            conn.MtdCerrarConexion();
            return dtVentaDetalle;
        }

        public DataTable MtdCargarDatos()
        {
            string QueryCargarDatos = "SELECT CodigoDetalleVenta, CodigoVenta, CodigoAnimal, CodigoCultivo, CodigoProducto, Cantidad, PrecioUnitario, Total, Descuento, Impuesto, TotalVenta, Estado FROM tbl_VentaDetalle ORDER BY CodigoDetalleVenta ASC";
            SqlDataAdapter sqlAdap = new SqlDataAdapter(QueryCargarDatos, conn.MtdAbrirConexion());
            DataTable dtCargarDatos = new DataTable();
            sqlAdap.Fill(dtCargarDatos);
            conn.MtdCerrarConexion();
            return dtCargarDatos;
        }

        public void MtdEliminarDatos(int CodigoDetalleVenta)
        {
            string QueryEliminarDatos = "DELETE FROM tbl_VentaDetalle WHERE CodigoDetalleVenta = @CodigoDetalleVenta";
            SqlCommand CommEliminarDatos = new SqlCommand(QueryEliminarDatos, conn.MtdAbrirConexion());
            CommEliminarDatos.Parameters.AddWithValue("@CodigoDetalleVenta", CodigoDetalleVenta);
            CommEliminarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
        public void MtdAgregarDatos(
    int CodigoVenta,
    int CodigoAnimal,
    int CodigoCultivo,
    int CodigoProducto,
    int Cantidad,
    decimal PrecioUnitario,
    decimal Total,
    decimal Descuento,
    decimal Impuesto,
    decimal TotalVenta,
    string Estado)
        {
            string QueryAgregarDatos = "INSERT INTO tbl_VentaDetalle (CodigoVenta, CodigoAnimal, CodigoCultivo, CodigoProducto, Cantidad, PrecioUnitario, Total, Descuento, Impuesto, TotalVenta, Estado) " +
                                       "VALUES (@CodigoVenta, @CodigoAnimal, @CodigoCultivo, @CodigoProducto, @Cantidad, @PrecioUnitario, @Total, @Descuento, @Impuesto, @TotalVenta, @Estado)";

            SqlCommand CommAgregarDatos = new SqlCommand(QueryAgregarDatos, conn.MtdAbrirConexion());
            CommAgregarDatos.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            CommAgregarDatos.Parameters.AddWithValue("@CodigoAnimal", CodigoAnimal);
            CommAgregarDatos.Parameters.AddWithValue("@CodigoCultivo", CodigoCultivo);
            CommAgregarDatos.Parameters.AddWithValue("@CodigoProducto", CodigoProducto);
            CommAgregarDatos.Parameters.AddWithValue("@Cantidad", Cantidad);
            CommAgregarDatos.Parameters.AddWithValue("@PrecioUnitario", PrecioUnitario);
            CommAgregarDatos.Parameters.AddWithValue("@Total", Total);
            CommAgregarDatos.Parameters.AddWithValue("@Descuento", Descuento);
            CommAgregarDatos.Parameters.AddWithValue("@Impuesto", Impuesto);
            CommAgregarDatos.Parameters.AddWithValue("@TotalVenta", TotalVenta);
            CommAgregarDatos.Parameters.AddWithValue("@Estado", Estado);

            CommAgregarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }


        public void MtdEditarDatos(
    int CodigoDetalleVenta,
    int CodigoVenta,
    int CodigoAnimal,
    int CodigoCultivo,
    int CodigoProducto,
    int Cantidad,
    decimal PrecioUnitario,
    decimal Total,
    decimal Descuento,
    decimal Impuesto,
    decimal TotalVenta,
    string Estado)
        {
            string QueryEditarDatos = "UPDATE tbl_VentaDetalle SET " +
                                      "CodigoVenta = @CodigoVenta, " +
                                      "CodigoAnimal = @CodigoAnimal, " +
                                      "CodigoCultivo = @CodigoCultivo, " +
                                      "CodigoProducto = @CodigoProducto, " +
                                      "Cantidad = @Cantidad, " +
                                      "PrecioUnitario = @PrecioUnitario, " +
                                      "Total = @Total, " +
                                      "Descuento = @Descuento, " +
                                      "Impuesto = @Impuesto, " +
                                      "TotalVenta = @TotalVenta, " +
                                      "Estado = @Estado " +
                                      "WHERE CodigoDetalleVenta = @CodigoDetalleVenta";

            SqlCommand commEditarDatos = new SqlCommand(QueryEditarDatos, conn.MtdAbrirConexion());
            commEditarDatos.Parameters.AddWithValue("@CodigoDetalleVenta", CodigoDetalleVenta);
            commEditarDatos.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            commEditarDatos.Parameters.AddWithValue("@CodigoAnimal", CodigoAnimal);
            commEditarDatos.Parameters.AddWithValue("@CodigoCultivo", CodigoCultivo);
            commEditarDatos.Parameters.AddWithValue("@CodigoProducto", CodigoProducto);
            commEditarDatos.Parameters.AddWithValue("@Cantidad", Cantidad);
            commEditarDatos.Parameters.AddWithValue("@PrecioUnitario", PrecioUnitario);
            commEditarDatos.Parameters.AddWithValue("@Total", Total);
            commEditarDatos.Parameters.AddWithValue("@Descuento", Descuento);
            commEditarDatos.Parameters.AddWithValue("@Impuesto", Impuesto);
            commEditarDatos.Parameters.AddWithValue("@TotalVenta", TotalVenta);
            commEditarDatos.Parameters.AddWithValue("@Estado", Estado);

            commEditarDatos.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
    }
}