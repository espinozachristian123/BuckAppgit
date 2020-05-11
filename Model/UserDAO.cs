using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model
{
    public class UserDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection connection;

        private int id;
        private string rol;
        private string email;
        

        public UserDAO()
        {
            dbConnect = DBConnection.getInstance();
        }
        
        public Boolean loginUser(User user)
        {
            Boolean b = false;
            String QUERY_SELECT_USER = "Select * from users WHERE username = @user AND password = @password";
            try
            {

                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_USER, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@user", user.Username));
                        cmd.Parameters.Add(new MySqlParameter("@password", user.Password));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                id = reader.GetInt16(0);
                                rol = reader.GetString(3);
                                email = reader.GetString(4);
                                b = true;
                            }
                        }
                        else
                        {
                            b = false;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                b = false;   
            }
            catch (Exception e)
            {
                b = false;
            }

            return b;
        }
        public string registrase(string nombre, string password, string rol, string email)
        {
            string salida = "Se ha insertado nuevo registro";
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataReader mysqlReader = null;


            try
            {
                connection = dbConnect.getConnection();
                connection.Open(); //Open connection.
                mysqlCmd = new MySqlCommand("Insert into users(username,password,rol,email) values('" + nombre + "','" + password + "','" + rol + "','" + email + "')", connection); //It makes the query
                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Se ha incertado nuevo usuario");
            }
            catch (Exception e)
            {
                salida = "No se ha podido insertar " + e.ToString();
            }
            return salida;
        }
        public string Rol { get => rol; set => rol = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get => id; set => id = value; }
    }
}


//String QUERY_SELECT_USER = "Select * from users WHERE username = @user AND password = @password";