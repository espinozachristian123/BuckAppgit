using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                email = reader.GetString(3);
                                rol = reader.GetString(4);
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

        public Boolean register(String username, String password, String emailRegister)
        {
            Boolean b = false;
            String QUERY_ADD_USER = "Insert into users (username, password, email, rol) values (@username,  @password , @email, @rol)";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_ADD_USER, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@username", username));
                        cmd.Parameters.Add(new MySqlParameter("@password", password));
                        cmd.Parameters.Add(new MySqlParameter("@email", emailRegister));
                        cmd.Parameters.Add(new MySqlParameter("@rol", "user"));
                        cmd.ExecuteNonQuery();
                        b = true;
                    }
                }
                else
                {
                    b = false;
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

        public Boolean takeUser(String email)
        {
            Boolean b = false;
            String QUERY_SELECT_USER = "Select * from users where email = @email";
            try
            {

                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_USER, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@email", email));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {   
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

        public string Rol { get => rol; set => rol = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get => id; set => id = value; }
    }
}