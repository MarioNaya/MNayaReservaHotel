using MNayaReservaHotel.bbdd;
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
    public partial class VerReservasHabitaciones : Form
    {
        public VerReservasHabitaciones()
        {
            InitializeComponent();
            tabla.DataSource = ConsultasHabitacion.ReservasActuales();
        }

        private void campoFecha_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            tabla.DataSource = ConsultasHabitacion.FiltradoPorFecha(campoFecha.Value.Date);
        }

        private void btnActuales_Click(object sender, EventArgs e)
        {
            tabla.DataSource = ConsultasHabitacion.ReservasActuales();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            tabla.DataSource = ConsultasHabitacion.ReservasHistorico();
        }
    }
}
