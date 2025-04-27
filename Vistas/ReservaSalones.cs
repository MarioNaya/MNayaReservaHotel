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
    public partial class ReservaSalones : Form
    {
        public ReservaSalones()
        {
            InitializeComponent();
            CrearFichero();
            comboCaterin.SelectedIndex = 0;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AltaCliente();
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            ConfirmarReserva();
        }

        private void btnDni_Click(object sender, EventArgs e)
        {
            ComprobarCliente();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            AbrirFactura();
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

        private void campoPersonas_Enter(object sender, EventArgs e)
        {
            campoPersonas.BackColor = Color.White;
        }

        //PROCESOS
        public void ComprobarCliente()
        {
            DesactivarBotonFactura();

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

            if (!Validacion.EsFechaHoyOPosterior(campoFecha.Value))
            {
                MessageBox.Show("La fecha de reserva debe ser a partir de hoy.");
                return;
            }

            if (!Validacion.CompruebaEntero(campoPersonas))
            {
                return;
            }

            double precio = CalcularPrecio();

            Salon s = new Salon(
                campoDni.Text,
                Login.dniPublic,
                campoFecha.Value,
                Convert.ToInt32(campoPersonas.Text),
                Convert.ToString(comboCaterin.SelectedItem),
                precio);

            if (ConsultasSalon.RegistrarSalon(s))
            {
                MessageBox.Show("Reserva registrada correctamente.");
                campoDni.Enabled = true;
                campoDni.BackColor = Color.White;
                DesactivarFormularioReserva();
                ActivarBotonFactura();
                areaFactura.Text = s.ToString();
                ImprimeFactura();
                return;
            }
        }

        //PRECIOS
        const double PRECIODESAYUNO = 60;
        const double PRECIOALMUERZO = 75;
        const double PRECIOCOMIDA = 90;
        const double PRECIOCENA = 80;
        const double PRECIOFIJO = 475;

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
            campoFecha.Enabled = true;
            campoPersonas.Enabled = true;
            comboCaterin.Enabled = true;
            btnReserva.Enabled = true;
        }

        public void DesactivarFormularioReserva()
        {
            campoFecha.Enabled = false;
            campoPersonas.Enabled = false;
            comboCaterin.Enabled = false;
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
        public double CalcularPrecio()
        {
            double precio = 0;

            if (comboCaterin.SelectedIndex == 1)
            {
                precio = Convert.ToInt16(campoPersonas.Text) * PRECIODESAYUNO;
                return precio;
            }
            else if (comboCaterin.SelectedIndex == 2)
            {
                precio = Convert.ToInt16(campoPersonas.Text) * PRECIOALMUERZO;
                return precio;
            }
            else if (comboCaterin.SelectedIndex == 3)
            {
                precio = Convert.ToInt16(campoPersonas.Text) * PRECIOCOMIDA;
                return precio;
            }
            else if (comboCaterin.SelectedIndex == 4)
            {
                precio = Convert.ToInt16(campoPersonas.Text) * PRECIOCENA;
                return precio;
            }
            else
            {
                MessageBox.Show("Tipo de CATERIN no válido.");
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

    }
}
