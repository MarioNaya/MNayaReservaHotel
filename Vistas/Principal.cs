using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNayaReservaHotel.Vistas
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            labelBienvenida.Text = $"Bienvenid@ a tu aplicación de reservas:  {Login.nombrePublic} {Login.apellidosPublic}";
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnReservaHabitacion_Click(object sender, EventArgs e)
        {
            ReservaHabitaciones rh = new ReservaHabitaciones();
            rh.ShowDialog();
        }

        private void btnReservaSalon_Click(object sender, EventArgs e)
        {
            ReservaSalones rs = new ReservaSalones();
            rs.ShowDialog();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            AltaEmpleado ae = new AltaEmpleado();
            ae.ShowDialog();
        }

        private void btnVerHabitacion_Click(object sender, EventArgs e)
        {
            VerReservasHabitaciones vh = new VerReservasHabitaciones();
            vh.ShowDialog();
        }

        private void btnVerSalon_Click(object sender, EventArgs e)
        {
            VerReservasSalones vh = new VerReservasSalones();
            vh.ShowDialog();
        }

        private void btnVerEmpleado_Click(object sender, EventArgs e)
        {
            VerEmpleados ver = new VerEmpleados();
            ver.ShowDialog();
        }
    }
}
