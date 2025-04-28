using MNayaReservaHotel.Modelo;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNayaReservaHotel.bbdd
{
    internal class ConsultasHabitacion
    {
        private static readonly string url = Configuracion.GetConnectionString();


        public static bool RegistrarHabitacion(Habitacion h)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(url))
                {
                    conn.Open();

                    string consulta = "INSERT INTO reserva_habitacion (dniCliente, fechaEntrada, fechaSalida, tipoHabitacion, noches, precioTotal, dniEmpleado) "
                    + "VALUES (?cli,?ent,?sal,?tip,?noc,?pre,?emp)";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?cli", h.DniCliente);
                        cmd.Parameters.AddWithValue("?ent", h.FechaEntrada);
                        cmd.Parameters.AddWithValue("?sal", h.FechaSalida);
                        cmd.Parameters.AddWithValue("?tip", h.Tipo);
                        cmd.Parameters.AddWithValue("?noc", h.Noches);
                        cmd.Parameters.AddWithValue("?pre", h.Precio);
                        cmd.Parameters.AddWithValue("?emp", h.DniEmpleado);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static DataTable ReservasActuales()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idReserva");
            dt.Columns.Add("DNI de cliente");
            dt.Columns.Add("Entrada");
            dt.Columns.Add("Salida");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Noches");
            dt.Columns.Add("Precio total");

            DataRow dr;

            string consulta = "SELECT idReserva, dniCliente, fechaEntrada, fechaSalida, tipoHabitacion, noches, precioTotal "
                    + "FROM reserva_habitacion WHERE fechaEntrada >=?ent";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(url))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?ent", DateTime.Today);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dr = dt.NewRow();
                                dr["idReserva"] = reader.GetInt32(0);
                                dr["DNI de cliente"] = reader.GetString(1);
                                dr["Entrada"] = reader.GetDateTime(2);
                                dr["Salida"] = reader.GetDateTime(3);
                                dr["Tipo"] = reader.GetString(4);
                                dr["Noches"] = reader.GetInt32(5);
                                dr["Precio total"] = reader.GetDouble(6);

                                dt.Rows.Add(dr);
                            }
                        }
                    }            
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public static DataTable ReservasHistorico()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idReserva");
            dt.Columns.Add("DNI de cliente");
            dt.Columns.Add("Entrada");
            dt.Columns.Add("Salida");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Noches");
            dt.Columns.Add("Precio total");

            DataRow dr;

            string consulta = "SELECT idReserva, dniCliente, fechaEntrada, fechaSalida, tipoHabitacion, noches, precioTotal "
                    + "FROM reserva_habitacion WHERE fechaEntrada <?ent";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(url))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?ent", DateTime.Today);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dr = dt.NewRow();
                                dr["idReserva"] = reader.GetInt32(0);
                                dr["DNI de cliente"] = reader.GetString(1);
                                dr["Entrada"] = reader.GetDateTime(2);
                                dr["Salida"] = reader.GetDateTime(3);
                                dr["Tipo"] = reader.GetString(4);
                                dr["Noches"] = reader.GetInt32(5);
                                dr["Precio total"] = reader.GetDouble(6);

                                dt.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public static DataTable FiltradoPorFecha(DateTime fecha)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idReserva");
            dt.Columns.Add("DNI de cliente");
            dt.Columns.Add("Entrada");
            dt.Columns.Add("Salida");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Noches");
            dt.Columns.Add("Precio total");

            DataRow dr;

            string consulta = "SELECT idReserva, dniCliente, fechaEntrada, fechaSalida, tipoHabitacion, noches, precioTotal "
                    + "FROM reserva_habitacion WHERE fechaEntrada =?ent";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(url))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?ent", fecha);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dr = dt.NewRow();
                                dr["idReserva"] = reader.GetInt32(0);
                                dr["DNI de cliente"] = reader.GetString(1);
                                dr["Entrada"] = Utilidades.Utilidades.AplicarFormatoFecha(reader.GetDateTime(2));
                                dr["Salida"] = Utilidades.Utilidades.AplicarFormatoFecha(reader.GetDateTime(3));
                                dr["Tipo"] = reader.GetString(4);
                                dr["Noches"] = reader.GetInt32(5);
                                dr["Precio total"] = reader.GetDouble(6);

                                dt.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
    }
}

