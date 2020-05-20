using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MoodDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection connection;

        List<Mood> moods = new List<Mood>();

        public MoodDAO()
        {
            dbConnect = DBConnection.getInstance();
        }

        public List<String> loadDataComboBox()
        {
            List<String> valueMoods = new List<String>();
            valueMoods.Add("1.-Para personas que estan muy triste");
            valueMoods.Add("2.-Para personas que estan triste");
            valueMoods.Add("3.-Para personas que estan normal");
            valueMoods.Add("4.-Para personas que estan bien");
            valueMoods.Add("5.-Para personas que estan muy bien");
            return valueMoods;
        }

        public DateTime checkDate(int userID)
        {
            DateTime date = default(DateTime);
            String QUERY_CHECK_DATE = "SELECT date FROM `mood` WHERE id_user = @id_user ORDER BY date DESC LIMIT 1";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_CHECK_DATE, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@id_user", userID));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                date = reader.GetDateTime(0);
                            }
                        }
                        else
                        {
                            date = default(DateTime);
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                date = default(DateTime);
            }
            catch (Exception e)
            {
                date = default(DateTime);
            }
            return date;
        }

        public Boolean insertMood(Mood newMood)
        {
            Boolean b = false;
            String QUERY_ADD_MOOD = "Insert into mood (id_user, mood, date) values (@id_user, @mood, @date)";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_ADD_MOOD, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@id_user", newMood.Id_user));
                        cmd.Parameters.Add(new MySqlParameter("@mood", newMood.Mod));
                        cmd.Parameters.Add(new MySqlParameter("@date", Convert.ToDateTime(newMood.Date)));
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

        public List<Mood> loadData()
        {
            moods = new List<Mood>();
            String QUERY_SELECT_EVENTS = "SELECT * FROM `mood`";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS, connection))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id_user = reader.GetInt16(0);
                                int mood = reader.GetInt16(1);
                                string date = reader.GetDateTime(2).ToString();
                                moods.Add(new Mood(id_user, mood, date));
                            }
                        }
                        else
                        {
                            moods = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                moods = null;
            }
            catch (Exception e)
            {
                moods = null;
            }
            return moods;
        }

        public List<Mood> loadOnePersonMood(int id_user)
        {
            List<Mood> moodsOnePerson = new List<Mood>();
            String QUERY_SELECT_EVENTS__ONE_PERSON = "Select * from mood where id_user = @id_user";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS__ONE_PERSON, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@id_user", id_user));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt16(0);
                                int mood = reader.GetInt16(1);
                                string date = reader.GetDateTime(2).ToString();
                                moodsOnePerson.Add(new Mood(id, mood, date, id_user));
                            }
                        }
                        else
                        {
                            moodsOnePerson = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                moodsOnePerson = null;
            }
            catch (Exception e)
            {
                moodsOnePerson = null;
            }
            return moodsOnePerson;
        }
        
    }
}
