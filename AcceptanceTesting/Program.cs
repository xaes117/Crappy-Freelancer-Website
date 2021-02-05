using AcceptanceTesting.DriverLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTesting
{
    class Program
    {
        static void Main(string[] args)
        {

            Driver driver = new Driver();
            driver.GoTo("https://www.bing.com");
            Console.WriteLine("Press any key to exit:");
            Console.ReadLine();

            driver.Close();

        }
    }
}
