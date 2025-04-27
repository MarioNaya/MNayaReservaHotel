using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNayaReservaHotel.Modelo
{
    internal class Habitacion
    {
        private int idReserva;
        private string dniCliente, dniEmpleado;
        private DateTime fechaEntrada, fechaSalida;
        private string tipo;
        private int noches;
        private double precio;

        public Habitacion(string dniCliente, string dniEmpleado, DateTime fechaEntrada,
            DateTime fechaSalida, string tipo, int noches, double precio)
        {
            this.DniCliente = dniCliente;
            this.DniEmpleado = dniEmpleado;
            this.FechaEntrada = fechaEntrada;
            this.FechaSalida = fechaSalida;
            this.Tipo = tipo;
            this.Noches = noches;
            this.Precio = precio;
        }

        public Habitacion(int idReserva, string dniCliente, DateTime fechaEntrada, DateTime fechaSalida, string tipo, int noches, double precio)
        {
            this.idReserva = idReserva;
            this.dniCliente = dniCliente;
            this.fechaEntrada = fechaEntrada;
            this.fechaSalida = fechaSalida;
            this.tipo = tipo;
            this.noches = noches;
            this.precio = precio;
        }

        public int IdReserva { get => idReserva; set => idReserva = value; }
        public string DniCliente { get => dniCliente; set => dniCliente = value; }
        public string DniEmpleado { get => dniEmpleado; set => dniEmpleado = value; }
        public DateTime FechaEntrada { get => fechaEntrada; set => fechaEntrada = value; }
        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Noches { get => noches; set => noches = value; }
        public double Precio { get => precio; set => precio = value; }

        public override string ToString()
        {
            return "===========RESERVA==========="
                + "\r\nDNI cliente: " + this.dniCliente
                + "\r\nFecha de entrada: " + this.fechaEntrada
                + "\r\nFecha de salida: " + this.fechaSalida
                + "\r\nNoches reservadas: " + this.noches
                + "\r\nTipo de habitación: " + this.tipo
                + "\r\nTotal factura: " + this.precio
                + "\r\n===============================\r\n";
        }
    }
}
