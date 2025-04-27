using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNayaReservaHotel.Utilidades
{
    internal class Validacion
    {

        public static bool CompruebaCamposVacios(GroupBox group)
        {

            foreach (Control control in group.Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        MessageBox.Show($"El campo {control.Tag} es obligatorio.");
                        control.BackColor = Color.Red;
                        return false;
                    }
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.SelectedIndex == 0)
                    {
                        MessageBox.Show($"El campo {control.Tag} es obligatorio.");
                        return false;
                    }
                }
            }
            return true;
        }

        public static void ResetFormulario(GroupBox group)
        {
            foreach (Control control in group.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        public static bool ComprobarFormato(string texto, string patron)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(texto, patron);
        }

        public static string DniFormat = "^[0-9]{8}[TRWAGMYFPDXBNJZSQVHLCKE]$";
        public static string TelefonoFormat = "^[0-9]{9}$";
        public static string EmailFormat = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
        public static string CpFormat = "^[0-9]{5}$";

        public static bool CompruebaDecimal(TextBox campo)
        {
            try
            {
                double numeroDecimal = double.Parse(campo.Text);
                return true;
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"{campo.Tag} debe ser un número decimal.");
                return false;
            }
        }

        public static bool CompruebaEntero(TextBox campo)
        {
            try
            {
                int numeroEntero = int.Parse(campo.Text);
                return true;
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"{campo.Tag} debe ser un número entero.");
                return false;
            }
        }

        public static bool FechaSalidaValida(DateTime fechaPrimera, DateTime fechaSegunda)
        {

            DateTime minFechaSalida = fechaPrimera.AddDays(1);

            return fechaSegunda >= minFechaSalida;
        }

        public static bool CompruebaFechasAnteriorOIgual(DateTime fechaAComprobar)
        {

            DateTime fechaActual = DateTime.Today;

            DateTime fechaAComprobarSoloFecha = fechaAComprobar.Date;

            return fechaAComprobarSoloFecha <= fechaActual;
        }

        public static bool EsFechaHoyOPosterior(DateTime fechaAComprobar)
        {

            DateTime fechaActual = DateTime.Today;

            return fechaAComprobar >= fechaActual;
        }
    }
}
