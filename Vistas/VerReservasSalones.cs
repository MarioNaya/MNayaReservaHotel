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
    public partial class VerReservasSalones : Form
    {
        public VerReservasSalones()
        {
            InitializeComponent();
            tabla.DataSource = ConsultasSalon.ReservasActuales();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            tabla.DataSource = ConsultasSalon.FiltradoPorFecha(campoFecha.Value.Date);
        }

        private void btnActuales_Click(object sender, EventArgs e)
        {
            tabla.DataSource = ConsultasSalon.ReservasActuales();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            tabla.DataSource = ConsultasSalon.ReservasHistorico();
        }
    }
}
