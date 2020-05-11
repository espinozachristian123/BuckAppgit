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

        List <Event> events = new List<Event>();
        List <String> categories = new List<string>();

        public EventDAO()
        {
            dbConnect = DBConnection.getInstance();
        }

        public List<Event> cogerDatos()
        {
            String QUERY_SELECT_EVENTS = "Select * from events";
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
                                int id = reader.GetInt16(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string date = reader.GetMySqlDateTime(4).ToString();
                                int numMax = reader.GetInt16(5);
                                string type = reader.GetString(6);
                                events.Add(new Event(id, name, description, location, date, type, numMax));
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

        public List <String> cogerDatosComboBox()
        {
            categories.Add("Deporte");
            categories.Add("Ocio");
            categories.Add("Cultural");
            categories.Add("Musical");
            categories.Add("Gastronomico");
            return categories;
        }

        public List<Event> cogerDatosConFiltro(string locationEvent, string typeEvent)
        {
           
            List<Event> eventsWithFilter = new List<Event>();
            String QUERY_SELECT_EVENTS_WITH_FILTER = "Select * from events where location = @location and type = @type";
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
                                int id = reader.GetInt16(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                string location = reader.GetString(3);
                                string date = reader.GetMySqlDateTime(4).ToString();
                                int numMax = reader.GetInt16(5);
                                string type = reader.GetString(6);
                                eventsWithFilter.Add(new Event(id, name, description, location, date, type, numMax));
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
        
    }
}
