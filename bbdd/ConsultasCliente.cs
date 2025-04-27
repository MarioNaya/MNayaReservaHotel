using MNayaReservaHotel.Modelo;
using MySqlConnector;
using System.Windows.Forms;

namespace MNayaReservaHotel.bbdd
{
    internal class ConsultasCliente
    {

        private static readonly string url = "Server=145.14.151.1; " +
            "Database=u812167471_reservas; " +
            "User=u812167471_reservas; " +
            "port=3306; " +
            "password=2025-Reservas; " +
            "Convert Zero Datetime=true";

        public static bool CompruebaDni(string dni)
        {
            string consulta = "SELECT * FROM clientes WHERE dniCliente=?dni";

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

        public static Cliente DatosCliente(string dni)
        {
            using (MySqlConnection conn = new MySqlConnection(url))
            {
                conn.Open();

                try
                {
                    string consulta = "SELECT * FROM clientes WHERE dniCliente=?dni";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?dni", dni);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Cliente c = new Cliente(
                                    reader["dniCliente"].ToString(),
                                    reader["nombre"].ToString(),
                                    reader["apellidos"].ToString(),
                                    int.Parse(reader["telefono"].ToString()),
                                    reader["email"].ToString(),
                                    reader["direccion"].ToString(),
                                    int.Parse(reader["cp"].ToString()),
                                    reader["localidad"].ToString()
                                );
                                return c;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            } 
        }

        public static bool RegistrarCliente(Cliente c)
        {
            using (MySqlConnection conn = new MySqlConnection(url))
            {
                conn.Open();
                try
                {
                    string consulta = "INSERT INTO clientes (dniCliente,nombre,apellidos, telefono, email, direccion, cp, localidad) "
                        + "VALUES (?dni,?nom,?ape,?tel,?mail,?dir,?cp,?loc)";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("?dni", c.Dni);
                        cmd.Parameters.AddWithValue("?nom", c.Nombre);
                        cmd.Parameters.AddWithValue("?ape", c.Apellidos);
                        cmd.Parameters.AddWithValue("?tel", c.Telefono);
                        cmd.Parameters.AddWithValue("?mail", c.Email);
                        cmd.Parameters.AddWithValue("?dir", c.Direccion);
                        cmd.Parameters.AddWithValue("?cp", c.Cp);
                        cmd.Parameters.AddWithValue("?loc", c.Localidad);

                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }               
            }
        }
    }
}
