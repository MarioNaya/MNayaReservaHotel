using MNayaReservaHotel.Modelo;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNayaReservaHotel.bbdd
{
    internal class ConsultasSalon
    {
        private static readonly string url = Configuracion.GetConnectionString();


        public static bool RegistrarSalon(Salon s)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(url))
                {
                    conn.Open();

                    string consulta = "INSERT INTO reserva_salon (dniCliente,fecha,numPersonas,Caterin,precio,dniEmpleado) "
                    + "VALUES (?cli,?fec,?per,?cat,?pre,?emp)";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?cli",s.DniCliente);
                        cmd.Parameters.AddWithValue("?fec", s.Fecha);
                        cmd.Parameters.AddWithValue("?per", s.NumPersona);
                        cmd.Parameters.AddWithValue("?cat", s.Caterin);
                        cmd.Parameters.AddWithValue("?pre", s.Precio);
                        cmd.Parameters.AddWithValue("?emp", s.DniEmpleado);

                        cmd.ExecuteNonQuery();
                        return true;

                    }
                }
            } 
            catch (MySqlException ex)
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
            dt.Columns.Add("Fecha de reserva");
            dt.Columns.Add("Personas");
            dt.Columns.Add("Caterin");
            dt.Columns.Add("Precio total");

            DataRow dr;

            string consulta = "SELECT idReserva, dniCliente, fecha, numPersonas, caterin, precio "
                    + "FROM reserva_salon WHERE fecha >=?fec";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(url))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?fec", DateTime.Today);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                dr = dt.NewRow();
                                dr["idReserva"] = reader.GetInt32(0);
                                dr["DNI de cliente"] = reader.GetString(1);
                                dr["Fecha de reserva"] = reader.GetDateTime(2);
                                dr["Personas"] = reader.GetInt32(3);
                                dr["Caterin"] = reader.GetString(4);
                                dr["Precio total"] = reader.GetDouble(5);

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
            dt.Columns.Add("Fecha de reserva");
            dt.Columns.Add("Personas");
            dt.Columns.Add("Caterin");
            dt.Columns.Add("Precio total");

            DataRow dr;

            string consulta = "SELECT idReserva, dniCliente, fecha, numPersonas, caterin, precio "
                    + "FROM reserva_salon WHERE fecha <?fec";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(url))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?fec", DateTime.Today);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dr = dt.NewRow();
                                dr["idReserva"] = reader.GetInt32(0);
                                dr["DNI de cliente"] = reader.GetString(1);
                                dr["Fecha de reserva"] = reader.GetDateTime(2);
                                dr["Personas"] = reader.GetInt32(3);
                                dr["Caterin"] = reader.GetString(4);
                                dr["Precio total"] = reader.GetDouble(5);

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
            dt.Columns.Add("Fecha de reserva");
            dt.Columns.Add("Personas");
            dt.Columns.Add("Caterin");
            dt.Columns.Add("Precio total");

            DataRow dr;

            string consulta = "SELECT idReserva, dniCliente, fecha, numPersonas, caterin, precio "
                    + "FROM reserva_salon WHERE fecha =?fec";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(url))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?fec", fecha);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dr = dt.NewRow();
                                dr["idReserva"] = reader.GetInt32(0);
                                dr["DNI de cliente"] = reader.GetString(1);
                                dr["Fecha de reserva"] = reader.GetDateTime(2);
                                dr["Personas"] = reader.GetInt32(3);
                                dr["Caterin"] = reader.GetString(4);
                                dr["Precio total"] = reader.GetDouble(5);

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
