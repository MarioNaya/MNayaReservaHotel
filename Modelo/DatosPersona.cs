using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNayaReservaHotel.Modelo
{
    internal class DatosPersona
    {
        private string dni, nombre, apellidos;
        private int telefono;
        private string email;

        public DatosPersona(string dni, string nombre, string apellidos, int telefono, string email)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Email = email;
        }

        public DatosPersona(string dni, string nombre, string apellidos)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellidos = apellidos;
        }

        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
    }
}
