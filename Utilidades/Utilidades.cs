using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNayaReservaHotel.Utilidades
{
    internal class Utilidades
    {
        public static string AplicarFormatoFecha(DateTime fecha)
        {
            return fecha.ToString("dd/MM/yyyy");
        }

        public static DateTime SumarDia(DateTime fecha, int dias)
        {
            return fecha.AddDays(dias);
        }
    }
}
