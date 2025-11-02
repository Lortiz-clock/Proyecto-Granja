using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;

namespace CapaLogica
{
    public class LNInsumos
    {
        private CDInsumos DInsumos = new CDInsumos();

        // Método para agregar un insumo con validaciones
        public string MtdAgregarInsumo(int CodigoProveedor, string NombreInsumo, string TipoInsumo, decimal CostoUnitario, string UnidadMedida, decimal Peso, string Observacion, string Estado)
        {
            if (CostoUnitario < 0)
            {
                return "Error: El Costo Unitario no puede ser un valor negativo.";
            }

            try
            {
                DInsumos.MtdAgregarInsumo(CodigoProveedor, NombreInsumo, TipoInsumo, CostoUnitario, UnidadMedida, Peso, Observacion, Estado);
                return "Insumo agregado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al agregar el insumo: " + ex.Message;
            }
        }

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        // Método para obtener la lista de proveedores 
        public List<dynamic> MtdListaProveedores()
        {
            return DInsumos.MtdListaProveedores();
        }

        // Método para obtener todos los insumos 
        public DataTable MtdConsultaInsumos()
        {
            return DInsumos.MtdConsultaInsumos();
        }

        // Método para eliminar insumos
        public string MtdEliminarInsumo(int CodigoInsumo)
        {
            try
            {
                DInsumos.MtdEliminarInsumo(CodigoInsumo);
                return "Insumo eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el insumo: " + ex.Message;
            }
        }

        // Nuevo método para actualizar un insumo
        public string MtdActualizarInsumo(int CodigoInsumo, int CodigoProveedor, string NombreInsumo, string TipoInsumo, decimal CostoUnitario, string UnidadMedida, decimal Peso, string Observacion, string Estado)
        {
            // Requerimiento: Costo unitario: No permite valores negativos
            if (CostoUnitario < 0)
            {
                return "Error: El Costo Unitario no puede ser un valor negativo.";
            }

            try
            {
                // Si la validación pasa, llama al método de la capa de datos
                DInsumos.MtdActualizarInsumo(CodigoInsumo, CodigoProveedor, NombreInsumo, TipoInsumo, CostoUnitario, UnidadMedida, Peso, Observacion, Estado);
                return "Insumo actualizado correctamente.";
            }
            catch (Exception ex)
            {
                // Manejo de excepciones de la capa de datos (ej. error de SQL)
                return "Error al actualizar el insumo: " + ex.Message;
            }
        }
    }
}