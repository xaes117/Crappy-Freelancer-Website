using Platform.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Platform.Models
{
    public class DataManager
    {
        public Boolean userExists(string username)
        {
            return false;
        }

        public List<Message> getMessages(Account a, Account b)
        {
            return null;
        }

        public List<Message> getMessages(Account a, Account b, int number)
        {
            return null;
        }

        public static void Main()
        {
            string connectionString = "server=localhost;user=root;database=softt7003;port=3306;password=0x38be";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();

                string sql = "select * from soft7003.contacts;";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int r = Convert.ToInt32(result);
                    Console.WriteLine("Number of countries in the world database is: " + r);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            connection.Close();
            Console.WriteLine("Done.");
        }
    }
}