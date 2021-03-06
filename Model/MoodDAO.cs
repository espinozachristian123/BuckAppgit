﻿using MySql.Data.MySqlClient;
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
        /// <summary>
        /// Load a list to fill the combobox
        /// </summary>
        /// <returns> list  value moods</returns>
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
        /// <summary>
        /// Select the date from the mood table by filtering by the user
        /// that we pass it by parameter and ordering the date in Descending way
        /// </summary>
        /// <param name="userID"></param>
        /// <returns> last date register mood </returns>
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
        /// <summary>
        /// We insert the data from the mood table with the data that we pass by parameter
        /// </summary>
        /// <param name="newMood"></param>
        /// <returns> if is true add mood or false if not added</returns>
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
        /// <summary>
        /// We collect the data from the mood table by filtering by the user id that is connected
        /// If there is an error with the server connection the exception is controlled
        /// </summary>
        /// <param name="id_user"></param>
        /// <returns>list mood one person </returns>
        public List<Mood> loadOnePersonMood(int id_user)
        {
            List<Mood> moodsOnePerson = new List<Mood>();
            String QUERY_SELECT_EVENTS__ONE_PERSON = "Select * from mood where id_user = @id_user ORDER BY date ASC";
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
                                moodsOnePerson.Add(new Mood(id_user, mood, date));
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
