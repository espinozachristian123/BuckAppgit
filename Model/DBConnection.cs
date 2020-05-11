using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DBConnection
    {
        /*
         *
$hostname="localhost";
$database="id9562541_dbbuckapp";
$username="id9562541_admin";
$password="admin";

         * */
        private static string connectionString = "Server=localhost;Database=id9562541_dbbuckapp;Uid=id9562541_admin;Pwd=admin;";
        private static DBConnection instance;
        private static MySqlConnection con = null;

        private DBConnection()
        {

        }
        public static DBConnection getInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }


        public MySqlConnection getConnection()
        {
            try
            {
                using (con = new MySqlConnection(connectionString)) ;


            }
            catch (MySqlException e)
            {

                Console.WriteLine("Error en la getConnection" + e.Message);
            }

            return con;

        }
    }
}
