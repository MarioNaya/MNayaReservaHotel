using MNayaReservaHotel.bbdd;
using MNayaReservaHotel.Modelo;
using MNayaReservaHotel.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNayaReservaHotel
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Entrar();
        }

        public static string nombrePublic,apellidosPublic,dniPublic;

        public void Entrar()
        {
            if (ConsultasEmpleado.Acceder(campoUsuario.Text, campoPass.Text))
            {
                DatosPersona dp = ConsultasEmpleado.DatosBasicos(campoUsuario.Text);

                nombrePublic = dp.Nombre;
                apellidosPublic = dp.Apellidos;
                dniPublic = dp.Dni;

                Principal vp = new Principal();
                vp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login incorrecto vuelva a intentarlo");
            }
        }
    }
}
