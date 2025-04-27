using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNayaReservaHotel.Modelo
{
    internal class Empleado : DatosPersona
    {

        private DateTime fechaContrato;
        private string turno;
        private double salarioBase;
        private string usuario, pass;

        public Empleado(string dni, string nombre, string apellidos, int telefono, string email,
            DateTime fechaContrato, string turno, double salarioBase, string usuario, string pass) 
            : base(dni, nombre, apellidos, telefono, email)
        {
            this.fechaContrato = fechaContrato;
            this.turno = turno;
            this.salarioBase = salarioBase;
            this.usuario = usuario;
            this.pass = pass;
        }

        public DateTime FechaContrato { get => fechaContrato; set => fechaContrato = value; }
        public string Turno { get => turno; set => turno = value; }
        public double SalarioBase { get => salarioBase; set => salarioBase = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}
