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
        /// <summary>
        /// Select the data in the users table as long as the username and password are the same as the one we passed by parameter
        /// If there is an error with the server connection the exception is controlled
        /// </summary>
        /// <param name="user">value user</param>
        /// <returns></returns>
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
        /// <summary>
        /// Modify the password that is in the database and replace it with the password that we pass it to you
        /// filtering by the user id in which we are connected
        /// If there is an error with the server connection the exception is controlled
        /// </summary>
        /// <param name="password"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool modifyPassword(string password, int id)
        {
            Boolean b = false;
            String QUERY_MODIFY_EVENT = "UPDATE `users` SET `password`= @password where id = @id";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_MODIFY_EVENT, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@password", password));
                        cmd.Parameters.Add(new MySqlParameter("@id", id));
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
                b = true;
            }
            return b;
        }
        /// <summary>
        /// Modify the email that is in the database and replace it with the email that we send it
        /// filtering by the user id in which we are connected
        /// If there is an error with the server connection the exception is controlled
        /// </summary>
        /// <param name="email">value email</param>
        /// <param name="id">value id</param>
        /// <returns></returns>
        public bool modifyEmail(string email, int id)
        {
            Boolean b = false;
            String QUERY_MODIFY_EVENT = "UPDATE `users` SET `email`= @email where id = @id";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_MODIFY_EVENT, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@email", email));
                        cmd.Parameters.Add(new MySqlParameter("@id", id));
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
                b = true;
            }
            return b;
        }
        /// <summary>
        /// Modify the username that is in the database and replace it with the username that we pass it to you
        /// filtering by the user id in which we are connected
        /// If there is an error with the server connection the exception is controlled
        /// </summary>
        /// <param name="newName">new value name</param>
        /// <param name="id_user">value id_user</param>
        /// <returns></returns>
        public bool modifyName(string newName, int id_user)
        {
            Boolean b = false;
            String QUERY_MODIFY_EVENT = "UPDATE `users` SET `username`= @newName where id = @id_user";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_MODIFY_EVENT, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@newName", newName));
                        cmd.Parameters.Add(new MySqlParameter("@id_user", id_user));
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
                b = true;
            }
            return b;
        }
        /// <summary>
        /// Modify the user that we pass to it with our records 
        /// that we pass to it by parameters 
        /// and filtering by the user id that we have modified
        /// If there is an error with the server connection the exception is controlled
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="newPass"></param>
        /// <param name="newEmail"></param>
        /// <param name="id_user"></param>
        /// <returns></returns>
        public bool modifyUser(string newName, string newPass, string newEmail, int id_user)
        {
            Boolean b = false;
            String QUERY_MODIFY_EVENT = "UPDATE `users` SET `username`= @newName,`password`= @newPass,`email`= @newEmail where id = @id_user";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_MODIFY_EVENT, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@newName", newName));
                        cmd.Parameters.Add(new MySqlParameter("@newPass", newPass));
                        cmd.Parameters.Add(new MySqlParameter("@newEmail", newEmail));
                        cmd.Parameters.Add(new MySqlParameter("@id_user", id_user));
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
                b = true;
            }
            return b;
        }
        /// <summary>
        /// We insert the values ​​of the users table with the values ​​that we pass by parameter
        /// If there is an error with the server connection the exception is controlled
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="emailRegister"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Select the user table where the user's email is the same as the email that we pass by parameter
        /// If there is an error with the server connection the exception is controlled
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Select the table of the user where the username of the user is equal to the username that we pass him by parameter
        /// If there is an error with the server connection the exception is controlled
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Boolean UserEquals(String username)
        {
            Boolean b = false;
            String QUERY_SELECT_USER = "Select * from users where username = @username";
            try
            {

                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_USER, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@username", username));
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