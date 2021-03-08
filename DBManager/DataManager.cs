using System;
using System.Collections.Generic;
using Accounts.Assets;
using MySql.Data.MySqlClient;

namespace DBManager
{
    public class DataManager
    {

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public List<List<string>> getUserInfo()
        {
            return this.Select("select * from users");
        }

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

        //Constructor
        public DataManager()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            // set details for connecting to the database
            server = "localhost";
            database = "soft7003";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        //Insert statement
        public void Insert(string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string query)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<List<string>> Select(string query)
        {
            try
            {
                //Create a list to store the result
                List<List<string>> list = new List<List<string>>();

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(new List<string>());
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            list[list.Count - 1].Add(dataReader.GetString(i));
                        }
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    return list;
                }
            } finally
            {
                this.CloseConnection();
            }
        }
    }
}