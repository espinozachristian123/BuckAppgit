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

        public List<Event> loadData()
        {
            events = new List<Event>();
            String QUERY_SELECT_EVENTS = "SELECT * FROM `events` WHERE date >= NOW()";
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
        
        public List<String> loadDataComboBox()
        {
            categories.Add("");
            categories.Add("Deportivo");
            categories.Add("Ocio");
            categories.Add("Cultural");
            categories.Add("Musical");
            categories.Add("Gastronomico");
            return categories;
        }

        public List<Event> loadDataWithFilter(string locationEvent, string typeEvent)
        {
            List<Event> eventsWithFilter = new List<Event>();
            String QUERY_SELECT_EVENTS_WITH_FILTER = "Select * from events where location = @location and type = @type and date >= NOW()";
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

        public List<Event> loadDataWithFilterLocation(string locationEvent)
        {
            List<Event> eventsWithFilterLocation = new List<Event>();
            String QUERY_SELECT_EVENTS_WITH_FILTER_LOCATION = "Select * from events where location = @location and date >= NOW()";
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
        
        public List<Event> loadDataWithFilterType(string typeEvent)
        {
            List<Event> eventsWithFilterType = new List<Event>();
            String QUERY_SELECT_EVENTS_WITH_FILTER_LOCATION = "Select * from events where type = @type and date >= NOW()";
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

        public Boolean registerEvent(DateTime fecha, int id_event, int id_user)
        {
            Boolean b = false;
            String QUERY_REGISTER_USEREVENTS = "Insert into userevents (date, id_events, id_user) values (@date,  @id_events , @id_user)";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_REGISTER_USEREVENTS, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@date", fecha));
                        cmd.Parameters.Add(new MySqlParameter("@id_events", id_event));
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
                b = false;
            }
            return b;
        }

        public Boolean deleteRegisterEvent(int id_event , int id_user)
        {
            Boolean b = false;
            String QUERY_DELETE_REGISTER_USEREVENTS = "DELETE FROM `userevents` WHERE id_events = @id_event and id_user = @id_user";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_DELETE_REGISTER_USEREVENTS, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@id_event", id_event));
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
                b = false;
            }
            return b;
        }

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
    

        public Boolean modifyEvent(String name, String description, String location, DateTime date, int num_max, String type, int id)
        {
           
            Boolean b = false;
            String QUERY_MODIFY_EVENT = "UPDATE `events` SET `name`= @name,`description`= @description,`location`= @location,`date`= @date,`num_participants_max`= @num_max,`type`= @type WHERE id = @id";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_MODIFY_EVENT, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@name", name));
                        cmd.Parameters.Add(new MySqlParameter("@description", description));
                        cmd.Parameters.Add(new MySqlParameter("@location", location));
                        cmd.Parameters.Add(new MySqlParameter("@date", Convert.ToDateTime(date)));
                        cmd.Parameters.Add(new MySqlParameter("@num_max", num_max));
                        cmd.Parameters.Add(new MySqlParameter("@type", type));
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

        public Boolean updateNumParticipants(int num_participants,  int id)
        {

            Boolean b = false;
            String QUERY_UPDATE_NUM_PART = "UPDATE `events` SET `num_participants`= @num_participants WHERE id = @id and num_participants < num_participants_max";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_UPDATE_NUM_PART, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@num_participants", num_participants));
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
