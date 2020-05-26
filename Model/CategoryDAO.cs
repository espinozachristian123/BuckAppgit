using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CategoryDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection connection;
        
        public CategoryDAO()
        {
            dbConnect = DBConnection.getInstance();
        }
        /// <summary>
        /// Select all the data in the category table
        /// Check if the connection to the server is successful
        /// if not, the exception is controlled
        /// </summary>
        /// <returns> categories list </returns>
        public List<Categories> loadDataComboBox()
        {
            List<Categories> categories = new List<Categories>();
            String QUERY_SELECT_EVENTS_WITH_MOOD = "SELECT * FROM `category`";
            try
            {
                connection = dbConnect.getConnection();

                if (connection != null)
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(QUERY_SELECT_EVENTS_WITH_MOOD, connection))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                String name = reader.GetString(1);
                                categories.Add(new Categories(name));
                            }
                        }
                        else
                        {
                            categories = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error)
            {
                categories = null;
            }
            catch (Exception e)
            {
                categories = null;
            }
            return categories;
        }
    }
}
