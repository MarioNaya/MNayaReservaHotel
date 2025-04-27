using MNayaReservaHotel.bbdd;
using MNayaReservaHotel.Modelo;
using MNayaReservaHotel.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNayaReservaHotel.Vistas
{
    public partial class ReservaHabitaciones : Form
    {
        public ReservaHabitaciones()
        {
            InitializeComponent();
            comboTipo.SelectedIndex = 0;
            CrearFichero();
        }

        private void btnDni_Click(object sender, EventArgs e)
        {
            ComprobarCliente();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AltaCliente();
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            ConfirmarReserva();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            AbrirFactura();
        }

        //PROCESOS
        public void ComprobarCliente()
        {
            if (!Validacion.ComprobarFormato(campoDni.Text, Validacion.DniFormat))
            {
                MessageBox.Show("Formato de DNI incorrecto.");
                campoDni.Text = "";
                campoDni.BackColor = Color.Red;
                return;
            }

            if (!ConsultasCliente.CompruebaDni(campoDni.Text.ToUpper()))
            {
                MessageBox.Show("DNI no encontrado. Debe registrar un nuevo cliente para continuar");
                campoDni.Enabled = false;
                campoDni.BackColor = Color.Green;
                ActivarFormularioCliente();
                DesactivarFormularioReserva();
                return;
            }

            Cliente c = ConsultasCliente.DatosCliente(campoDni.Text);

            campoNombre.Text = c.Nombre;
            campoApellidos.Text = c.Apellidos;
            campoTelefono.Text = c.Telefono.ToString();
            campoEmail.Text = c.Email;
            campoDireccion.Text = c.Direccion;
            campoCp.Text = c.Cp.ToString();
            campoLocalidad.Text = c.Localidad;

            MessageBox.Show("Puede continuar con la reserva");
            campoDni.Enabled = false;
            campoDni.BackColor = Color.Green;

            ActivarFormularioReserva();
        }

        public void AltaCliente()
        {
            if (!Validacion.CompruebaCamposVacios(groupCliente))
            {
                return;
            }

            if (!Validacion.ComprobarFormato(campoDni.Text,Validacion.DniFormat))
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
                MessageBox.Show("Formato de Email incorrecto.");
                campoEmail.Text = "";
                campoEmail.BackColor = Color.Red;
                return;

            }

            if (!Validacion.ComprobarFormato(campoCp.Text, Validacion.CpFormat))
            {
                MessageBox.Show("Formato de CÓDIGO POSTAL incorrecto.");
                campoCp.Text = "";
                campoCp.BackColor = Color.Red;
                return;

            }

            if (ConsultasCliente.CompruebaDni(campoDni.Text))
            {
                MessageBox.Show("El DNI ya está registrado. Ingrese un nuevo DNI para poder contiguar con el registro.");
                campoDni.Text = "";
                campoDni.BackColor = Color.Red;
                return;
            }

            Cliente c = new Cliente(
                campoDni.Text,
                campoNombre.Text,
                campoApellidos.Text,
                Convert.ToInt32(campoTelefono.Text),
                campoEmail.Text,
                campoDireccion.Text,
                Convert.ToInt32(campoCp.Text),
                campoLocalidad.Text
                );

            if (ConsultasCliente.RegistrarCliente(c))
            {
                MessageBox.Show("Cliente registrado correctamente. Puede continuar con la reserva.");
                DesactivarFormularioCliente();
                ActivarFormularioReserva();
            }
            else
            {
                MessageBox.Show("El cliente no llegó a registrarse correctamente en la base de datos. Inténtelo de nuevo más tarde.");
            }
        }

        public void ConfirmarReserva()
        {
            if (!Validacion.CompruebaCamposVacios(groupReserva))
            {
                return;
            }

            if (!Validacion.FechaSalidaValida(campoEntrada.Value, campoSalida.Value))
            {
                MessageBox.Show("La fecha de salida debe ser posterior a la de entrada");
                return;
            }

            if (!Validacion.EsFechaHoyOPosterior(campoEntrada.Value))
            {
                MessageBox.Show("La fecha de entrada debe ser a partir de hoy.");
                return;
            }

            string tipo = comboTipo.SelectedItem.ToString();
            int noches = CalculoNoches();
            double precio = CalcularPrecio();

            Habitacion h = new Habitacion(
                campoDni.Text,
                Login.dniPublic,
                campoEntrada.Value,
                campoSalida.Value,
                tipo,
                noches,
                precio);

            if (ConsultasHabitacion.RegistrarHabitacion(h))
            {
                MessageBox.Show("Reserva registrada correctamente.");
                campoDni.Enabled = true;
                ActivarBotonFactura();
                areaFactura.Text = h.ToString();
                ImprimeFactura();
                return;
            }
        }

        //PRECIOS
        const double PRECIONOCHESIMPLE = 60;
        const double PRECIONOCHEDOBLE = 100;

        //CONTROL ENABLED INTERFAZ
        public void ActivarFormularioCliente()
        {
            campoNombre.Enabled = true;
            campoApellidos.Enabled = true;
            campoTelefono.Enabled = true;
            campoEmail.Enabled = true;
            campoDireccion.Enabled = true;
            campoCp.Enabled = true;
            campoLocalidad.Enabled = true;
            btnCliente.Enabled = true;
        }

        public void DesactivarFormularioCliente()
        {
            campoNombre.Enabled = false;
            campoApellidos.Enabled = false;
            campoTelefono.Enabled = false;
            campoEmail.Enabled = false;
            campoDireccion.Enabled = false;
            campoCp.Enabled = false;
            campoLocalidad.Enabled = false;
            btnCliente.Enabled = false;
        }

        public void ActivarFormularioReserva()
        {
            campoEntrada.Enabled = true;
            campoSalida.Enabled = true;
            campoSalida.Value = Utilidades.Utilidades.SumarDia(campoEntrada.Value, 1);
            comboTipo.Enabled = true;
            btnReserva.Enabled = true;
        }

        public void DesactivarFormularioReserva()
        {
            campoEntrada.Enabled = false;
            campoSalida.Enabled = false;
            comboTipo.Enabled = false;
            btnReserva.Enabled = false;
        }

        public void ActivarBotonFactura()
        {
            btnFactura.Enabled = true;
        }

        public void DesactivarBotonFactura()
        {
            btnFactura.Enabled = false;
        }

        //CALCULO DE ATRIBUTOS
        public int CalculoNoches()
        {
            DateTime fechaFin = campoSalida.Value;
            DateTime fechaInicio = campoEntrada.Value;

            TimeSpan diferencia = fechaFin - fechaInicio;
            return Math.Abs(diferencia.Days);
        }

        public double CalcularPrecio()
        {
            double precio = 0;

            if (comboTipo.SelectedIndex == 1)
            {
                precio = CalculoNoches() * PRECIONOCHESIMPLE;
                return precio;
            }
            else if (comboTipo.SelectedIndex == 2)
            {
                precio = CalculoNoches() * PRECIONOCHEDOBLE;
                return precio;
            }
            else
            {
                MessageBox.Show("Tipo de habitación no válido.");
            }
            return precio;
        }

        //IMPRESIÓN FACTURA
        private FileInfo factura;

        public void CrearFichero()
        {
            factura = new FileInfo("Factura.txt");

            if (!factura.Exists)
            {
                try
                {
                    using (var fs = factura.Create()) { }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error creando el archivo: " + ex.Message);
                }
            }
        }

        public void ImprimeFactura()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(factura.FullName))
                {
                    sw.Write(areaFactura.Text);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error escribiendo en el archivo: " + ex.Message);
            }
        }

        public void AbrirFactura()
        {
            try
            {
                if (factura.Exists)
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = factura.FullName,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se puede abrir el archivo automáticamente.\n" + ex.Message);
                    }
                }
                else
                {
                    CrearFichero();
                    ImprimeFactura(); // <--- Aquí escribimos lo que hay en el TextBox
                    MessageBox.Show("Se ha creado un nuevo archivo de factura.");

                    // Opcionalmente, abrirlo después de crearlo
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = factura.FullName,
                        UseShellExecute = true
                    });
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error al abrir el archivo: " + ex.Message);
                MessageBox.Show("Error al abrir el archivo: " + ex.Message);
            }
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

        private void campoDireccion_Enter(object sender, EventArgs e)
        {
            campoDireccion.BackColor = Color.White;
        }

        private void campoCp_Enter(object sender, EventArgs e)
        {
            campoCp.BackColor = Color.White;
        }

        private void campoLocalidad_Enter(object sender, EventArgs e)
        {
            campoLocalidad.BackColor = Color.White;
        }
    }
}
