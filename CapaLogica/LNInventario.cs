// LNInventario.cs
using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;

namespace CapaLogica
{
    public class LNInventario
    {
        private CDInventario DInventario = new CDInventario();

        // VALIDACIÓN DE NEGOCIO REUSABLE
        private string ValidarInventario(decimal Precio, int Stock, DateTime FechaIngreso, DateTime FechaVencimiento)
        {
            if (Precio <= 0)
            {
                return "Error: El Precio debe ser un valor positivo.";
            }
            if (Stock <= 0)
            {
                return "Error: El Stock debe ser un valor positivo.";
            }
            if (FechaIngreso.Date > DateTime.Now.Date)
            {
                return "Error: La Fecha de Ingreso no puede ser posterior a la fecha actual.";
            }
            if (FechaVencimiento.Date < DateTime.Now.Date)
            {
                return "Error: La Fecha de Vencimiento no puede ser anterior a la fecha actual.";
            }
            if (FechaVencimiento.Date < FechaIngreso.Date)
            {
                return "Error: La Fecha de Vencimiento no puede ser anterior a la Fecha de Ingreso.";
            }
            return "OK";
        }

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        // 1. Método para Agregar Inventario (Create)
        public string MtdAgregarInventario(int CodigoGranja, int CodigoInsumo, string NombreProducto, string Tipo, decimal Precio, int Stock, DateTime FechaIngreso, DateTime FechaVencimiento, string Estado)
        {
            string validacion = ValidarInventario(Precio, Stock, FechaIngreso, FechaVencimiento);
            if (validacion != "OK")
                return validacion;

            try
            {
                DInventario.MtdAgregarInventario(CodigoGranja, CodigoInsumo, NombreProducto, Tipo, Precio, Stock, FechaIngreso, FechaVencimiento, Estado);
                return "Registro de inventario agregado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al agregar el registro de inventario: " + ex.Message;
            }
        }

        // 2. Método para Actualizar Inventario (Update)
        public string MtdActualizarInventario(int CodigoInventario, int CodigoGranja, int CodigoInsumo, string NombreProducto, string Tipo, decimal Precio, int Stock, DateTime FechaIngreso, DateTime FechaVencimiento, string Estado)
        {
            string validacion = ValidarInventario(Precio, Stock, FechaIngreso, FechaVencimiento);
            if (validacion != "OK")
                return validacion;

            try
            {
                DInventario.MtdActualizarInventario(CodigoInventario, CodigoGranja, CodigoInsumo, NombreProducto, Tipo, Precio, Stock, FechaIngreso, FechaVencimiento, Estado);
                return "Registro de inventario actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el registro de inventario: " + ex.Message;
            }
        }

        // Métodos de Consulta y Listado
        public List<dynamic> MtdListaInsumos() { return DInventario.MtdListaInsumos(); }
        public List<dynamic> MtdListaGranjas() { return DInventario.MtdListaGranjas(); }
        public DataTable MtdConsultaInventario() { return DInventario.MtdConsultaInventario(); }
        public string MtdEliminarInventario(int CodigoInventario)
        {
            try { DInventario.MtdEliminarInventario(CodigoInventario); return "Registro de inventario eliminado correctamente."; } catch (Exception ex) { return "Error al eliminar el registro de inventario: " + ex.Message; }
        }
    }
}