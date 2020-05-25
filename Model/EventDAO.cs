using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EventDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection connection;

        List<Event> events = new List<Event>();
        List<String> categories = new List<string>();

        public EventDAO()
        {
            dbConnect = DBConnection.getInstance();
        }
        /// <summary>
        /// load all events of database where the date are bigger than today
        ///  if connection is diferent of null
        /// execute the query of method.
        /// and save the values in a list of events
        /// </summary>
        /// <returns>list of events</returns>
        public List<Event> loadAllEventsForAdmin()
        {
            events = new List<Event>();
            String QUERY_SELECT_EVENTS = "SELECT * FROM `events` WHERE date >= NOW()";
            try{
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
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string direction = reader.GetString(4);
                                string date = reader.GetDateTime(5).ToString();
                                string duration = reader.GetTimeSpan(6).ToString();
                                int numPart = reader.GetInt32(7);
                                int numMax = reader.GetInt32(8);
                                string type = reader.GetString(9);
                                int mood = reader.GetInt32(10);
                                int id_user = reader.GetInt32(11);
                                events.Add(new Event(id, name, description, location, direction, date, duration, numPart, numMax, type, mood, id_user));
                            }
                        }
                        else
                        {
                            events = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                events = null;
            }
            catch (Exception e)
            {
                events = null;
            }
            return events;
        }
        /// <summary>
        /// load the event of database , filtered by mood of user and the date is bigger or equals the date today
        ///  if connection is diferent of null
        /// execute the query of method.
        /// and save the values in a list of event
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>event or null if are not exist</returns>
        public List<Event> loadDataWithFilterMood(int userID)
        {
            events = new List<Event>();
            String QUERY_SELECT_EVENTS_WITH_MOOD = "SELECT * FROM `events` WHERE mood in (SELECT * FROM (SELECT mood FROM `mood` where id_user = @id_user ORDER BY date DESC LIMIT 1) as t ) and date >= NOW()";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS_WITH_MOOD, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@id_user", userID));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string direction = reader.GetString(4);
                                string date = reader.GetDateTime(5).ToString();
                                string duration = reader.GetTimeSpan(6).ToString();
                                int numPart = reader.GetInt32(7);
                                int numMax = reader.GetInt32(8);
                                string type = reader.GetString(9);
                                int mood = reader.GetInt32(10);
                                int id_user = reader.GetInt32(11);
                                events.Add(new Event(id, name, description, location,direction, date,duration, numPart, numMax, type, mood, id_user));
                            }
                        }
                        else
                        {
                            events = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                events = null;
            }
            catch (Exception e)
            {
                events = null;
            }
            return events;
        }
        /// <summary>
        /// load the event of database filtered by location or type with mood of user and the date is bigger or equals the date today
        /// if connection is diferent of null
        /// execute the query of method.
        /// and save the values in a list of event
        /// </summary>
        /// <param name="locationEvent"></param>
        /// <param name="typeEvent"></param>
        /// <param name="userID"></param>
        /// <returns>event or null if are not exist</returns>
        public List<Event> loadDataWithFilterAndMood(string locationEvent, string typeEvent, int userID)
        {
            List<Event> eventsWithFilterAndMood = new List<Event>();
            String QUERY_SELECT_EVENTS_WITH_FILTER_AND_MOOD = "SELECT * FROM `events` WHERE mood in (SELECT mood FROM `mood` where id_user = @id_user ) and city = @location and name_category = @type and date >= NOW()";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS_WITH_FILTER_AND_MOOD, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@location", locationEvent));
                        cmd.Parameters.Add(new MySqlParameter("@type", typeEvent));
                        cmd.Parameters.Add(new MySqlParameter("@id_user", userID));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string direction = reader.GetString(4);
                                string date = reader.GetDateTime(5).ToString();
                                string duration = reader.GetTimeSpan(6).ToString();
                                int numPart = reader.GetInt32(7);
                                int numMax = reader.GetInt32(8);
                                string type = reader.GetString(9);
                                int mood = reader.GetInt32(10);
                                int id_user = reader.GetInt32(11);
                                eventsWithFilterAndMood.Add(new Event(id, name, description, location, direction, date, duration, numPart, numMax, type, mood, id_user));
                            }
                        }
                        else
                        {
                            eventsWithFilterAndMood = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                eventsWithFilterAndMood = null;
            }
            catch (Exception e)
            {
                eventsWithFilterAndMood = null;
            }
            return eventsWithFilterAndMood;
        }
        /// <summary>
        /// load the event of database filtered by location or type and the date is bigger or equals the date today
        ///  if connection is diferent of null
        /// execute the query of method.
        /// and save the values in a list of event.
        /// </summary>
        /// <param name="locationEvent"></param>
        /// <param name="typeEvent"></param>
        /// <returns>event or null if are not exist</returns>
        public List<Event> loadDataWithFilter(string locationEvent, string typeEvent)
        {
            List<Event> eventsWithFilter = new List<Event>();
            String QUERY_SELECT_EVENTS_WITH_FILTER = "Select * from events where city = @location and name_category = @type and date >= NOW()";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS_WITH_FILTER, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@location", locationEvent));
                        cmd.Parameters.Add(new MySqlParameter("@type", typeEvent));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string direction = reader.GetString(4);
                                string date = reader.GetDateTime(5).ToString();
                                string duration = reader.GetTimeSpan(6).ToString();
                                int numPart = reader.GetInt32(7);
                                int numMax = reader.GetInt32(8);
                                string type = reader.GetString(9);
                                int mood = reader.GetInt32(10);
                                int id_user = reader.GetInt32(11);
                                eventsWithFilter.Add(new Event(id, name, description, location, direction, date, duration, numPart, numMax, type, mood, id_user));
                            }
                        }
                        else
                        {
                            eventsWithFilter = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                eventsWithFilter = null;
            }
            catch (Exception e)
            {
                eventsWithFilter = null;
            }
            return eventsWithFilter;
        }
        /// <summary>
        /// load the event of database filtered by location and the date is bigger or equals the date today
        ///  if connection is diferent of null
        /// execute the query of method.
        /// and save the values in a list of event.
        /// </summary>
        /// <param name="locationEvent"></param>
        /// <returns>event or null if are not exist</returns>
        public List<Event> loadDataWithFilterLocation(string locationEvent)
        {
            List<Event> eventsWithFilterLocation = new List<Event>();
            String QUERY_SELECT_EVENTS_WITH_FILTER_LOCATION = "Select * from events where city = @location and date >= NOW()";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS_WITH_FILTER_LOCATION, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@location", locationEvent));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string direction = reader.GetString(4);
                                string date = reader.GetDateTime(5).ToString();
                                string duration = reader.GetTimeSpan(6).ToString();
                                int numPart = reader.GetInt32(7);
                                int numMax = reader.GetInt32(8);
                                string type = reader.GetString(9);
                                int mood = reader.GetInt32(10);
                                int id_user = reader.GetInt32(11);
                                eventsWithFilterLocation.Add(new Event(id, name, description, location, direction, date, duration, numPart, numMax, type, mood, id_user));
                            }
                        }
                        else
                        {
                            eventsWithFilterLocation = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                eventsWithFilterLocation = null;
            }
            catch (Exception e)
            {
                eventsWithFilterLocation = null;
            }
            return eventsWithFilterLocation;
        }
        /// <summary>
        /// load events of database filtered by location and mood of user and the date is bigger or equals the date today
        ///  if connection is diferent of null
        /// execute the query of method.
        /// and save the values in a list of event.
        /// </summary>
        /// <param name="locationEvent"></param>
        /// <param name="userID"></param>
        /// <returns>event or null if are not exist</returns>
        public List<Event> loadDataWithFilterLocationAndMood(string locationEvent, int userID)
        {
            List<Event> eventsWithFilterLocationAndMood = new List<Event>();
            String QUERY_SELECT_EVENTS_WITH_FILTER_LOCATION_AND_MOOD = "SELECT * FROM `events` WHERE mood in (SELECT mood FROM `mood` where id_user = @id_user ) and city = @location and date >= NOW()";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS_WITH_FILTER_LOCATION_AND_MOOD, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@location", locationEvent));
                        cmd.Parameters.Add(new MySqlParameter("@id_user", userID));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string direction = reader.GetString(4);
                                string date = reader.GetDateTime(5).ToString();
                                string duration = reader.GetTimeSpan(6).ToString();
                                int numPart = reader.GetInt32(7);
                                int numMax = reader.GetInt32(8);
                                string type = reader.GetString(9);
                                int mood = reader.GetInt32(10);
                                int id_user = reader.GetInt32(11);
                                eventsWithFilterLocationAndMood.Add(new Event(id, name, description, location, direction, date, duration, numPart, numMax, type, mood, id_user));
                            }
                        }
                        else
                        {
                            eventsWithFilterLocationAndMood = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                eventsWithFilterLocationAndMood = null;
            }
            catch (Exception e)
            {
                eventsWithFilterLocationAndMood = null;
            }
            return eventsWithFilterLocationAndMood;
        }
        /// <summary>
        /// load the event filtered by type and the date is bigger or equals the date today
        ///  if connection is diferent of null
        /// execute the query of method.
        /// and save the values in a list of event.
        /// </summary>
        /// <param name="typeEvent"></param>
        /// <returns>event or null if are not exist</returns>
        public List<Event> loadDataWithFilterType(string typeEvent)
        {
            List<Event> eventsWithFilterType = new List<Event>();
            String QUERY_SELECT_EVENTS_WITH_FILTER_LOCATION = "Select * from events where name_category = @type and date >= NOW()";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS_WITH_FILTER_LOCATION, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@type", typeEvent));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string direction = reader.GetString(4);
                                string date = reader.GetDateTime(5).ToString();
                                string duration = reader.GetTimeSpan(6).ToString();
                                int numPart = reader.GetInt32(7);
                                int numMax = reader.GetInt32(8);
                                string type = reader.GetString(9);
                                int mood = reader.GetInt32(10);
                                int id_user = reader.GetInt32(11);
                                eventsWithFilterType.Add(new Event(id, name, description, location, direction, date, duration, numPart, numMax, type, mood, id_user));
                            }
                        }
                        else
                        {
                            eventsWithFilterType = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                eventsWithFilterType = null;
            }
            catch (Exception e)
            {
                eventsWithFilterType = null;
            }
            return eventsWithFilterType;
        }
        /// <summary>
        /// load the event of database filetered by type with mood user and the date is bigger or equals the date today
        ///  if connection is diferent of null
        /// execute the query of method.
        /// and save the values in a list of event.
        /// </summary>
        /// <param name="typeEvent"></param>
        /// <param name="userID"></param>
        /// <returns>event or null if are not exist</returns>
        public List<Event> loadDataWithFilterTypeAndMood(string typeEvent, int userID)
        {
            List<Event> eventsWithFilterTypeAndMood = new List<Event>();
            String QUERY_SELECT_EVENTS_WITH_FILTER_TYPE_AND_MOOD = "SELECT * FROM `events` WHERE mood in (SELECT mood FROM `mood` where id_user = @id_user ) and name_category = @type and date >= NOW()";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS_WITH_FILTER_TYPE_AND_MOOD, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@type", typeEvent));
                        cmd.Parameters.Add(new MySqlParameter("@id_user", userID));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string direction = reader.GetString(4);
                                string date = reader.GetDateTime(5).ToString();
                                string duration = reader.GetTimeSpan(6).ToString();
                                int numPart = reader.GetInt32(7);
                                int numMax = reader.GetInt32(8);
                                string type = reader.GetString(9);
                                int mood = reader.GetInt32(10);
                                int id_user = reader.GetInt32(11);
                                eventsWithFilterTypeAndMood.Add(new Event(id, name, description, location, direction, date, duration, numPart, numMax, type, mood, id_user));
                            }
                        }
                        else
                        {
                            eventsWithFilterTypeAndMood = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                eventsWithFilterTypeAndMood = null;
            }
            catch (Exception e)
            {
                eventsWithFilterTypeAndMood = null;
            }
            return eventsWithFilterTypeAndMood;
        }
        /// <summary>
        /// load the events of database filtered by id of user
        ///  if connection is diferent of null
        /// execute the query of method.
        /// and save the values in a list of event.
        /// </summary>
        /// <param name="iD_user"></param>
        /// <returns>event or null if are not exist</returns>
        public List<Event> loadOnePersonActivities(int iD_user)
        {
            List<Event> eventsOnePerson = new List<Event>();
            String QUERY_SELECT_EVENTS__ONE_PERSON = "Select * from events where id_user = @id_user";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS__ONE_PERSON, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@id_user", iD_user));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string direction = reader.GetString(4);
                                string date = reader.GetDateTime(5).ToString();
                                string duration = reader.GetTimeSpan(6).ToString();
                                int numPart = reader.GetInt32(7);
                                int numMax = reader.GetInt32(8);
                                string type = reader.GetString(9);
                                int mood = reader.GetInt32(10);
                                int id_user = reader.GetInt32(11);
                                eventsOnePerson.Add(new Event(id, name, description, location, direction, date, duration, numPart, numMax, type, mood, id_user));
                            }
                        }
                        else
                        {
                            eventsOnePerson = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                eventsOnePerson = null;
            }
            catch (Exception e)
            {
                eventsOnePerson = null;
            }
            return eventsOnePerson;
        }
        /// <summary>
        /// add a new event in database doing a insert
        ///  if connection is diferent of null
        /// execute the query of method.
        /// </summary>
        /// <param name="newEvent"></param>
        /// <returns>true if added succesflly or false in case of error</returns>
        public Boolean addEvent(Event newEvent)
        {
            Boolean b = false;
            String QUERY_ADD_USER = "Insert into events (name, description, city, direction, date, duration, num_participants, num_participants_max, name_category,mood ,id_user) " +
                "values (@name,  @description , @city, @direction, @date, @duration, @num_participants, @num_participants_max, @type, @mood, @id_user)";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_ADD_USER, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@name", newEvent.Name));
                        cmd.Parameters.Add(new MySqlParameter("@description", newEvent.Description));
                        cmd.Parameters.Add(new MySqlParameter("@city", newEvent.City));
                        cmd.Parameters.Add(new MySqlParameter("@direction", newEvent.Direction));
                        cmd.Parameters.Add(new MySqlParameter("@date", Convert.ToDateTime(newEvent.Date)));
                        cmd.Parameters.Add(new MySqlParameter("@duration", newEvent.Duration));
                        cmd.Parameters.Add(new MySqlParameter("@num_participants", newEvent.NumParticipants));
                        cmd.Parameters.Add(new MySqlParameter("@num_participants_max", newEvent.NumMaxParticipantes));
                        cmd.Parameters.Add(new MySqlParameter("@type", newEvent.Type));
                        cmd.Parameters.Add(new MySqlParameter("@mood", newEvent.Mood));
                        cmd.Parameters.Add(new MySqlParameter("@id_user", newEvent.Id_user));
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
        /// register user in one event
        ///  if connection is diferent of null
        /// execute the query of method.
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="id_event"></param>
        /// <param name="id_user"></param>
        /// <returns>true if are registered correctly or false in case of error</returns>
        public Boolean registerEvent(DateTime fecha, int id_event, int id_user, int num_participants)
        {
            MySqlTransaction tr = null;
            Boolean b = false;
            String QUERY_REGISTER_USEREVENTS = "Insert into userevents (date, id_events, id_user) values (@date,  @id_events , @id_user)";
            String QUERY_UPDATE_NUM_PART = "UPDATE `events` SET `num_participants`= @num_participants WHERE id = @id and num_participants < num_participants_max";

            try
            {
                connection = dbConnect.getConnection();
                
                if (connection != null)
                {
                    connection.Open();
                    tr = connection.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand(QUERY_REGISTER_USEREVENTS, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@date", fecha));
                        cmd.Parameters.Add(new MySqlParameter("@id_events", id_event));
                        cmd.Parameters.Add(new MySqlParameter("@id_user", id_user));
                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(QUERY_UPDATE_NUM_PART, connection))
                    {
                        num_participants++;
                        cmd.Parameters.Add(new MySqlParameter("@num_participants", num_participants));
                        cmd.Parameters.Add(new MySqlParameter("@id", id_event));
                        cmd.ExecuteNonQuery();
                    }

                    tr.Commit();
                    b = true;
                }
                else
                {
                    b = false;
                }
            }
            catch (MySqlException error)
            {
                tr.Rollback();
                b = false;
            }
            catch (Exception e)
            {
                tr.Rollback();
                b = false;
            }
            return b;
        }
        /// <summary>
        /// delete user of userevents table of databse
        ///  if connection is diferent of null
        /// execute the query of method.
        /// </summary>
        /// <param name="id_event"></param>
        /// <param name="id_user"></param>
        /// <returns>true if the user are deleted of activity or false in case of error</returns>
        public Boolean deleteRegisterEvent(int id_event , int id_user, int num_participants)
        {
            MySqlTransaction tr = null;
            Boolean b = false;

            String QUERY_DELETE_REGISTER_USEREVENTS = "DELETE FROM `userevents` WHERE id_events = @id_event and id_user = @id_user";
            String QUERY_UPDATE_NUM_PART = "UPDATE `events` SET `num_participants`= @num_participants WHERE id = @id";

            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    tr = connection.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand(QUERY_DELETE_REGISTER_USEREVENTS, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@id_event", id_event));
                        cmd.Parameters.Add(new MySqlParameter("@id_user", id_user));
                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(QUERY_UPDATE_NUM_PART, connection))
                    {
                        num_participants--;
                        cmd.Parameters.Add(new MySqlParameter("@num_participants", num_participants));
                        cmd.Parameters.Add(new MySqlParameter("@id", id_event));
                        cmd.ExecuteNonQuery();
                    }

                    tr.Commit();
                    b = true;
                }
                else
                {
                    b = false;
                }
            }
            catch (MySqlException error)
            {
                tr.Rollback();
                b = false;
            }
            catch (Exception e)
            {
                tr.Rollback();
                b = false;
            }
            return b;
        }
        /// <summary>
        /// check if one user are not registeres in one activity
        /// if connection is diferent of null
        /// execute the query of method.
        /// </summary>
        /// <param name="id_event"></param>
        /// <param name="id_user"></param>
        /// <returns>true if user are registered or false in case of error</returns>
        public Boolean checkRegister(int id_event,int id_user)
        {
            Boolean b = false;
            String QUERY_CHECK_REGISTER = "Select * FROM `userevents` where id_events = @id_event and id_user = @id_user";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_CHECK_REGISTER, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@id_event", id_event));
                        cmd.Parameters.Add(new MySqlParameter("@id_user", id_user));
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
        /// load the activitis of database that user are registered in any activity
        /// if connection is diferent of null
        /// execute the query of method.
        /// </summary>
        /// <param name="iD_user"></param>
        /// <returns>true if user are registered in one activty or false in case of error</returns>
        public List <Event> loadActivitiesRegisterOnePerson(int iD_user)
        {
            List<Event> listEventsRegisterOnePerson = new List<Event>(); ;
            String QUERY_SELECT_EVENTS_REGISTER_ONE_PERSON = "SELECT * FROM events WHERE id IN (SELECT id_events FROM userevents WHERE id_user = @id_user)";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS_REGISTER_ONE_PERSON, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@id_user", iD_user));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string direction = reader.GetString(4);
                                string date = reader.GetDateTime(5).ToString();
                                string duration = reader.GetTimeSpan(6).ToString();
                                int numPart = reader.GetInt32(7);
                                int numMax = reader.GetInt32(8);
                                string type = reader.GetString(9);
                                int mood = reader.GetInt32(10);
                                int id_user = reader.GetInt32(11);
                                listEventsRegisterOnePerson.Add(new Event(id, name, description, location, direction, date, duration, numPart, numMax, type, mood, id_user));
                            }
                        }
                        else
                        {
                            listEventsRegisterOnePerson = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                listEventsRegisterOnePerson = null;
            }
            catch (Exception e)
            {
                listEventsRegisterOnePerson = null;
            }
            return listEventsRegisterOnePerson;
        }
    
        /// <summary>
        /// modify event of user doing update in databse
        /// if connection is diferent of null
        /// execute the query of method.
        /// </summary>
        /// <param name="eventModify"></param>
        /// <returns>true if are modified correctly or false in case of error</returns>
        public Boolean modifyEvent(Event eventModify)
        {
            Boolean b = false;
            String QUERY_MODIFY_EVENT = "UPDATE `events` SET `name`= @name,`description`= @description,`city`= @location,`direction`= @direction,`date`= @date,`duration`= @duration,`num_participants_max`= @num_max,`name_category`= @type,`mood`= @mood WHERE id = @id";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_MODIFY_EVENT, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@name", eventModify.Name));
                        cmd.Parameters.Add(new MySqlParameter("@description", eventModify.Description));
                        cmd.Parameters.Add(new MySqlParameter("@location", eventModify.City));
                        cmd.Parameters.Add(new MySqlParameter("@direction", eventModify.Direction));
                        cmd.Parameters.Add(new MySqlParameter("@date", Convert.ToDateTime(eventModify.Date)));
                        cmd.Parameters.Add(new MySqlParameter("@duration", eventModify.Duration));
                        cmd.Parameters.Add(new MySqlParameter("@num_max", eventModify.NumMaxParticipantes));
                        cmd.Parameters.Add(new MySqlParameter("@type", eventModify.Type));
                        cmd.Parameters.Add(new MySqlParameter("@mood", eventModify.Mood));
                        cmd.Parameters.Add(new MySqlParameter("@id", eventModify.Id));
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
        /// delete the event of user doing a "delete" in database
        /// check the conection are succesfully
        /// and then executy query
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if the event are deleted or false in case of error</returns>
        public Boolean deleteEvent(int id)
        {
            Boolean b = false;
            String QUERY_DELETE_EVENT = "DELETE FROM `events` WHERE id = @id";
            try
            {
                connection = dbConnect.getConnection();
                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_DELETE_EVENT, connection))
                    {
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
                b = false;
            }
            return b;
        }
    }

}
