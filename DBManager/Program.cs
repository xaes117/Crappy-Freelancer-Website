using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            var a = dataManager.getUserInfo();

            foreach (List<string> user in a)
            {
                Console.WriteLine(user[0]);
                Console.WriteLine(user[1]);
                Console.WriteLine("----------");
            }
        }
    }
}
