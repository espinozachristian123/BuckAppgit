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

        public List<Event> cogerDatos()
        {
            events = new List<Event>();
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
                                int numPart = reader.GetInt16(5);
                                int numMax = reader.GetInt16(6);
                                string type = reader.GetString(7);
                                int id_user = reader.GetInt16(8);
                                events.Add(new Event(id, name, description, location, date, numPart, numMax, type, id_user));
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

        public List<String> cogerDatosComboBox()
        {
            categories.Add("Deportivo");
            categories.Add("Ocio");
            categories.Add("Cultural");
            categories.Add("Musical");
            categories.Add("Gastronomico");
            return categories;
        }

        public List<Event> cogerDatosConFiltroLugarTipo(string locationEvent, string typeEvent)
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
                                int numPart = reader.GetInt16(5);
                                int numMax = reader.GetInt16(6);
                                string type = reader.GetString(7);
                                int id_user = reader.GetInt16(8);
                                eventsWithFilter.Add(new Event(id, name, description, location, date, numPart, numMax, type, id_user));
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

        public List<Event> cogerActividadesDeUnaPersona(int id_user)
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
                        cmd.Parameters.Add(new MySqlParameter("@id_user", id_user));
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
                                int numPart = reader.GetInt16(5);
                                int numMax = reader.GetInt16(6);
                                string type = reader.GetString(7);
                                eventsOnePerson.Add(new Event(id, name, description, location, date, numPart, numMax, type, id_user));
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

        public Boolean modifyEvent(String name, String description, String location, String date, int num_max, String type, int id)
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
                        cmd.Parameters.Add(new MySqlParameter("@date", date));
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
        public Boolean insertar_event(string name, string description, string location, string date, int num_participants, int num_participants_max, string type, int id_user)
        {
            Boolean b = false;
            String QUERY_ADD_USER = "Insert into events (name, description, location, date, num_participants, num_participants_max, type, id_user) values (@name,  @description , @location, @date, @num_participants, @num_participants_max, @type, @id_user)";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_ADD_USER, connection))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@name", name));
                        cmd.Parameters.Add(new MySqlParameter("@description", description));
                        cmd.Parameters.Add(new MySqlParameter("@location", location));
                        cmd.Parameters.Add(new MySqlParameter("@date", Convert.ToDateTime(date)));
                        cmd.Parameters.Add(new MySqlParameter("@num_participants", num_participants));
                        cmd.Parameters.Add(new MySqlParameter("@num_participants_max", num_participants_max));
                        cmd.Parameters.Add(new MySqlParameter("@type", type));
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



    }
}
