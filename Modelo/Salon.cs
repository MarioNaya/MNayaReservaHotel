using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNayaReservaHotel.Modelo
{
    internal class Salon
    {
        private int idReserva;
        private string dniCliente, dniEmpleado;
        private DateTime fecha;
        private int numPersona;
        private string caterin;
        private double precio;

        public Salon(string dniCliente, string dniEmpleado, DateTime fecha, int numPersona, string caterin, double precio)
        {
            this.DniCliente = dniCliente;
            this.DniEmpleado = dniEmpleado;
            this.Fecha = fecha;
            this.NumPersona = numPersona;
            this.Caterin = caterin;
            this.Precio = precio;
        }

        public Salon(int idReserva, string dniCliente, DateTime fecha, int numPersona, string caterin, double precio)
        {
            this.idReserva = idReserva;
            this.dniCliente = dniCliente;
            this.fecha = fecha;
            this.numPersona = numPersona;
            this.caterin = caterin;
            this.precio = precio;
        }

        public int IdReserva { get => idReserva; set => idReserva = value; }
        public string DniCliente { get => dniCliente; set => dniCliente = value; }
        public string DniEmpleado { get => dniEmpleado; set => dniEmpleado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int NumPersona { get => numPersona; set => numPersona = value; }
        public string Caterin { get => caterin; set => caterin = value; }
        public double Precio { get => precio; set => precio = value; }

        public override string ToString()
        {
            return "===========RESERVA==========="
                + "\r\nDNI cliente: " + this.dniCliente
                + "\r\nFecha de entrada: " + this.fecha
                + "\r\nNúmero de personas: " + this.numPersona
                + "\r\nTipo de caterin: " + this.caterin
                + "\r\nTotal factura: " + this.precio
                + "\r\n===============================\r\n";
        }
    }
}
