using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNayaReservaHotel.bbdd
{
    internal class Configuracion
    {
        private static IConfigurationRoot config;

        static Configuracion()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            config = builder.Build();
        }

        public static string GetConnectionString()
        {
            return config.GetConnectionString("DefaultConnection");
        }
    }
}
