using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos; // Necesario para acceder a CDCultivos

namespace CapaLogica
{
    public class LNCultivos
    {
        private CDCultivos DCultivos = new CDCultivos();

        // Método para agregar un cultivo con validaciones
        public string MtdAgregarCultivo(int CodigoGranja, string TipoCultivo, DateTime FechaSiembra, DateTime FechaCosecha, decimal CantidadCosecha, decimal Precio, string Ubicacion, string Observacion, string Estado)
        {
            if (CantidadCosecha < 0)
            {
                return "Error: La Cantidad Cosechada no puede ser un valor negativo.";
            }
            if (Precio < 0)
            {
                return "Error: El Precio no puede ser un valor negativo.";
            }

            if (FechaSiembra.Date < DateTime.Now.Date)
            {
                return "Error: La Fecha de Siembra no puede ser anterior a la fecha actual.";
            }
            if (FechaCosecha.Date < DateTime.Now.Date)
            {
                return "Error: La Fecha de Cosecha no puede ser anterior a la fecha actual.";
            }

            if (FechaCosecha.Date < FechaSiembra.Date)
            {
                return "Error: La Fecha de Cosecha no puede ser anterior a la Fecha de Siembra.";
            }

            try
            {
                DCultivos.MtdAgregarCultivo(CodigoGranja, TipoCultivo, FechaSiembra, FechaCosecha, CantidadCosecha, Precio, Ubicacion, Observacion, Estado);
                return "Cultivo agregado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al agregar el cultivo: " + ex.Message;
            }
        }

        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;
        }

        // Método para llenar ComboBox de Granjas
        public List<dynamic> MtdListaGranjas()
        {
            return DCultivos.MtdListaGranjas();
        }

        // Método para obtener todos los cultivos
        public DataTable MtdConsultaCultivos()
        {
            return DCultivos.MtdConsultaCultivos();
        }

        // Método para eliminar cultivos
        public string MtdEliminarCultivo(int CodigoCultivo)
        {
            try
            {
                DCultivos.MtdEliminarCultivo(CodigoCultivo);
                return "Cultivo eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el cultivo: " + ex.Message;
            }
        }

        private string ValidarCultivo(decimal CantidadCosecha, decimal Precio, DateTime FechaSiembra, DateTime FechaCosecha)
        {
            if (CantidadCosecha < 0)
            {
                return "Error: La Cantidad Cosechada no puede ser un valor negativo.";
            }
            if (Precio < 0)
            {
                return "Error: El Precio no puede ser un valor negativo.";
            }

            if (FechaSiembra.Date < DateTime.Now.Date)
            {
                return "Error: La Fecha de Siembra no puede ser anterior a la fecha actual.";
            }

            if (FechaCosecha.Date < FechaSiembra.Date)
            {
                return "Error: La Fecha de Cosecha no puede ser anterior a la Fecha de Siembra.";
            }

            return "OK";
        }

        // Método para Actualizar Cultivo
        public string MtdActualizarCultivo(int CodigoCultivo, int CodigoGranja, string TipoCultivo, DateTime FechaSiembra, DateTime FechaCosecha, decimal CantidadCosecha, decimal Precio, string Ubicacion, string Observacion, string Estado)
        {
            string validacion = ValidarCultivo(CantidadCosecha, Precio, FechaSiembra, FechaCosecha);
            if (validacion != "OK")
                return validacion;

            try
            {
                DCultivos.MtdActualizarCultivo(CodigoCultivo, CodigoGranja, TipoCultivo, FechaSiembra, FechaCosecha, CantidadCosecha, Precio, Ubicacion, Observacion, Estado);
                return "Cultivo actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el cultivo: " + ex.Message;
            }
        }
    }
}