using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaLogica
{
    public class CLProductos
    {
        public string MtdFecha()
        {
            string FechaHoy = DateTime.Today.ToString("d");
            return FechaHoy;
        }

        private readonly Dictionary<string, List<string>> nombresPorTipo;
        private readonly Dictionary<string, List<string>> descripcionPorTipo;
        public CLProductos()
        {
            // Inicializar mapa de tipos -> nombres (puede ampliarse o cargarse desde BD)
            nombresPorTipo = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "Avicolas", new List<string> { "Huevo rojo grande", "Huevo blanco mediano", "Gallina ponedora", "Pollo de engorde", "Pollos Enteros", "Pollo Cortado", "Plumas" } },
                { "Ganaderia", new List<string> { "Carne Res", "Ganado Vivo", "Leche entera pasteurizada", "Queso fresco artesanal", "Crema fresca" } },
                { "Agricola", new List<string> { "Maíz", "Trigo", "Papa", "Tomate rojo", "Lechuga orgánica", " Miel natural" } },
                { "SubProductos", new List<string> { "Abono orgánico", "Melaza de caña", "Harina de maíz", "Harina de Hueso", "Gallinaza seca", "Café tostado molido" } }
            };






            // Inicializar mapa de tipos -> nombres (puede ampliarse o cargarse desde BD)
            descripcionPorTipo = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "Avicolas", new List<string> { "Productos derivados de la cría de aves, como huevos y carne de pollo." } },
                { "Ganaderia", new List<string> { "Productos obtenidos del ganado, como leche, carne o queso." } },
                { "Agricola", new List<string> { "Productos provenientes del cultivo de la tierra, como maíz, frijol o vegetales." } },
                { "SubProductos", new List<string> { "Residuos o derivados de otros procesos, como abono o compost." } }
            };
        }





        // Devuelve la lista de nombres para un tipo; si no existe devuelve lista vacía
        public List<string> GetNombresPorTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                return new List<string>();

            if (nombresPorTipo.TryGetValue(tipo, out List<string> lista) && lista != null)
                return new List<string>(lista); // devolver copia para evitar modificaciones externas

            return new List<string>();
        }

        public List<string> GetdescripcionPorTipo(string Descripcion)
        {
            if (string.IsNullOrWhiteSpace(Descripcion))
                return new List<string>();

            if (descripcionPorTipo.TryGetValue(Descripcion, out List<string> lista) && lista != null)
                return new List<string>(lista); // devolver copia para evitar modificaciones externas

            return new List<string>();
        }

        // Opcional: obtener todos los tipos conocidos
        public List<string> GetTipos()
        {
            return new List<string>(nombresPorTipo.Keys);
        }

        public List<string> GetDescripcion()
        {
            return new List<string>(descripcionPorTipo.Keys);
        }

    }


}
