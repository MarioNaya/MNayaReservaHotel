using MNayaReservaHotel.bbdd;
using MNayaReservaHotel.Modelo;
using MNayaReservaHotel.Utilidades;
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
    public partial class AltaEmpleado : Form
    {
        public AltaEmpleado()
        {
            InitializeComponent();
            comboTurno.SelectedIndex = 0;
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Registro();
        }

        private void campoDni_Enter(object sender, EventArgs e)
        {
            campoDni.BackColor = Color.White;
        }

        private void campoNombre_Enter(object sender, EventArgs e)
        {
            campoNombre.BackColor = Color.White;
        }

        private void campoApellidos_Enter(object sender, EventArgs e)
        {
            campoApellidos.BackColor = Color.White;
        }

        private void campoTelefono_Enter(object sender, EventArgs e)
        {
            campoTelefono.BackColor = Color.White;
        }

        private void campoEmail_Enter(object sender, EventArgs e)
        {
            campoEmail.BackColor = Color.White;
        }

        private void campoFecha_Enter(object sender, EventArgs e)
        {
            campoFecha.CalendarTitleBackColor = Color.White;
        }

        private void campoTurno_Enter(object sender, EventArgs e)
        {
            comboTurno.BackColor = Color.White;
        }

        private void campoSalario_Enter(object sender, EventArgs e)
        {
            campoSalario.BackColor = Color.White;
        }

        private void campoUsuario_Enter(object sender, EventArgs e)
        {
            campoUsuario.BackColor = Color.White;
        }

        private void campoPass_Enter(object sender, EventArgs e)
        {
            campoPass.BackColor = Color.White;
        }

        public void Registro()
        {
            if (!Validacion.CompruebaCamposVacios(groupEmpleado))
            {
                return;
            }

            if (!Validacion.ComprobarFormato(campoDni.Text, Validacion.DniFormat))
            {
                MessageBox.Show("Formato de DNI incorrecto.");
                campoDni.Text = "";
                campoDni.BackColor = Color.Red;
                return;
            }

            if (!Validacion.ComprobarFormato(campoTelefono.Text, Validacion.TelefonoFormat))
            {
                MessageBox.Show("Formato de teléfono incorrecto.");
                campoTelefono.Text = "";
                campoTelefono.BackColor = Color.Red;
                return;
            }

            if (!Validacion.ComprobarFormato(campoEmail.Text, Validacion.EmailFormat))
            {
                MessageBox.Show("Formato de email incorrecto.");
                campoEmail.Text = "";
                campoEmail.BackColor = Color.Red;
                return;
            }

            if (!Validacion.CompruebaFechasAnteriorOIgual(campoFecha.Value))
            {
                MessageBox.Show("La fecha de contratación debe ser anterior a la fecha de alta en el sistema.");
                campoFecha.CalendarTitleBackColor = Color.Red;
                return;
            }

            if (!Validacion.CompruebaDecimal(campoSalario))
            {
                campoSalario.Text = "";
                campoSalario.BackColor = Color.Red;
                return;
            }

            if (ConsultasEmpleado.CompruebaDni(campoDni.Text.ToUpper()))
            {
                MessageBox.Show("DNI ya registrado. Introduzca un DNI diferente.");
                Validacion.ResetFormulario(groupEmpleado);
                return;
            }

            if (ConsultasEmpleado.CopruebaUsuario(campoUsuario.Text))
            {
                MessageBox.Show("Usuario ya registrado. Elija otro usuario.");
                campoUsuario.Text = "";
                campoUsuario.BackColor = Color.Red;
                return;
            }

            string dni = campoDni.Text;
            string nom = campoNombre.Text;
            string ape = campoApellidos.Text;
            int tel = Convert.ToInt32(campoTelefono.Text);
            string mail = campoEmail.Text;
            DateTime fec = campoFecha.Value;
            string tur = comboTurno.SelectedItem.ToString();
            double sal = Convert.ToDouble(campoSalario.Text);
            string user = campoUsuario.Text;
            string pass = campoPass.Text;

            Empleado e = new Empleado(dni, nom, ape, tel, mail, fec, tur, sal, user, pass);

            if (ConsultasEmpleado.RegistrarEmpleado(e))
            {
                MessageBox.Show("Usuario registrado en la base de datos.");
                Validacion.ResetFormulario(groupEmpleado);
            }
            else
            {
                MessageBox.Show("Error en el registro. Inténtelo más tarde.");
            }
        }
    }
}
