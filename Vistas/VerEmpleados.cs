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
    public partial class VerEmpleados : Form
    {
        public VerEmpleados()
        {
            InitializeComponent();
            comboTurnos.SelectedIndex = 0;
            tabla.DataSource = ConsultasEmpleado.EmpleadosActuales();
        }

        private void comboTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTurnos.SelectedIndex == 0)
            {
                tabla.DataSource = ConsultasEmpleado.EmpleadosActuales();
            }
            else if (comboTurnos.SelectedIndex == 1)
            {
                tabla.DataSource = ConsultasEmpleado.EmpleadosPorTurno(comboTurnos.SelectedItem.ToString());
            }
            else if (comboTurnos.SelectedIndex == 2)
            {
                tabla.DataSource = ConsultasEmpleado.EmpleadosPorTurno(comboTurnos.SelectedItem.ToString());
            }
            else if(comboTurnos.SelectedIndex == 3)
            {
                tabla.DataSource = ConsultasEmpleado.EmpleadosPorTurno(comboTurnos.SelectedItem.ToString());
            }
        }
    }
}
