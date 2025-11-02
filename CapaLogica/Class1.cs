using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class Class1
    {

        

            public decimal CalcularTotal(int cantidad, decimal precioUnitario)
            {
                return cantidad * precioUnitario;
            }
            public decimal CalcularImpuesto(decimal total)
            {
                return total * 0.12m;
            }
            public decimal CalcularTotalVenta(decimal total, decimal impuesto)
            {
                return total + impuesto;
            }



            public decimal CalcularSalarioFinal(decimal salarioBase, decimal bonos, decimal descuentos)
            {
                return salarioBase + bonos - descuentos;
            }
        }

    }

