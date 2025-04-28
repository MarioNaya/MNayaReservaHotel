using MNayaReservaHotel.Modelo;
using MNayaReservaHotel.Utilidades;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNayaReservaHotel.bbdd
{
    internal class ConsultasEmpleado
    {

        private static readonly string url = Configuracion.GetConnectionString();


        public static bool Acceder(string user, string pass)
        {
            string consulta = "SELECT usuario, pass FROM empleados WHERE usuario=?user AND pass=?pass";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(url))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?user", user);
                        cmd.Parameters.AddWithValue("?pass", pass);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static DatosPersona DatosBasicos(string user)
        {
            using (MySqlConnection conn = new MySqlConnection(url))
            {
                conn.Open();

                string consulta = "SELECT dniEmpleado, nombre, apellidos FROM empleados WHERE usuario=?user";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("?user", user);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DatosPersona dp = new DatosPersona(
                                reader["dniEmpleado"].ToString(),
                                reader["nombre"].ToString(),
                                reader["apellidos"].ToString());

                            return dp;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static bool RegistrarEmpleado(Empleado e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(url))
                {
                    conn.Open();

                    string consulta = "INSERT INTO empleados (dniEmpleado, nombre, apellidos, telefono, email, fechaContrato, turno, salarioBase, usuario, pass) "
                        + "VALUES (?dni,?nom,?ape,?tel,?mail,?fecha,?tur,?sal,?user,?pass)";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?dni", e.Dni);
                        cmd.Parameters.AddWithValue("?nom", e.Nombre);
                        cmd.Parameters.AddWithValue("?ape", e.Apellidos);
                        cmd.Parameters.AddWithValue("?tel", e.Telefono);
                        cmd.Parameters.AddWithValue("?mail", e.Email);
                        cmd.Parameters.AddWithValue("?fecha", e.FechaContrato);
                        cmd.Parameters.AddWithValue("?tur", e.Turno);
                        cmd.Parameters.AddWithValue("?sal", e.SalarioBase);
                        cmd.Parameters.AddWithValue("?user", e.Usuario);
                        cmd.Parameters.AddWithValue("?pass", e.Pass);

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

        public static bool CompruebaDni(string dni)
        {
            string consulta = "SELECT * FROM empleados WHERE dniEmpleado=?dni";

            MySqlConnection conn = new MySqlConnection(url);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(consulta, conn);

            cmd.Parameters.AddWithValue("?dni", dni);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                reader.Close();
                conn.Close();
                return true;
            }
            else
            {
                reader.Close();
                conn.Close();
                return false;
            }
        }

        public static bool CopruebaUsuario(string usuario)
        {
            string consulta = "SELECT * FROM empleados WHERE usuario=?user";

            MySqlConnection conn = new MySqlConnection(url);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(consulta, conn);

            cmd.Parameters.AddWithValue("?user", usuario);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                reader.Close();
                conn.Close();
                return true;
            }
            else
            {
                reader.Close();
                conn.Close();
                return false;
            }
        }

        public static DataTable EmpleadosActuales()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("DNI");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellidos");
            dt.Columns.Add("Teléfono");
            dt.Columns.Add("Email");
            dt.Columns.Add("Turno");

            DataRow dr;

            string consulta = "SELECT dniEmpleado, nombre, apellidos, telefono, email, turno "
                    + "FROM empleados";

            using (MySqlConnection conn = new MySqlConnection(url))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dr = dt.NewRow();
                            dr["DNI"] = reader.GetString(0);
                            dr["Nombre"] = reader.GetString(1);
                            dr["Apellidos"] = reader.GetString(2);
                            dr["Teléfono"] = reader.GetInt32(3);
                            dr["Email"] = reader.GetString(4);
                            dr["Turno"] = reader.GetString(5);

                            dt.Rows.Add(dr);
                        }
                    }
                }
                return dt;
            }
        }

        public static DataTable EmpleadosPorTurno(string turno)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("DNI");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellidos");
            dt.Columns.Add("Teléfono");
            dt.Columns.Add("Email");
            dt.Columns.Add("Turno");

            DataRow dr;

            string consulta = "SELECT dniEmpleado, nombre, apellidos, telefono, email, turno "
                    + "FROM empleados WHERE turno=?tur";

            using (MySqlConnection conn = new MySqlConnection(url))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("?tur", turno);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dr = dt.NewRow();
                            dr["DNI"] = reader.GetString(0);
                            dr["Nombre"] = reader.GetString(1);
                            dr["Apellidos"] = reader.GetString(2);
                            dr["Teléfono"] = reader.GetInt32(3);
                            dr["Email"] = reader.GetString(4);
                            dr["Turno"] = reader.GetString(5);

                            dt.Rows.Add(dr);
                        }
                    }
                }
                return dt;
            }
        }
    }
}
