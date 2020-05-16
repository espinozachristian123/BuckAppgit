using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MoodDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection connection;

        public MoodDAO()
        {
            dbConnect = DBConnection.getInstance();
        }

        public Boolean insertMood(int id_user,int mood, string fecha)
        {
            Boolean b = false;
            String QUERY_ADD_MOOD = "Insert into mood (id_user, mood, date) values (@id_user, @mood, @fecha)";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_ADD_MOOD, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@id_user", id_user));
                        cmd.Parameters.Add(new MySqlParameter("@mood", mood));
                        cmd.Parameters.Add(new MySqlParameter("@fecha", Convert.ToDateTime(fecha)));
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
    }
}
