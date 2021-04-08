using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    class Program
    {
        static void Main(string[] args)
        {

            string url = "https://hello.com";

            Console.WriteLine(AccountManager.TrimHTTPHeader(url));
            Console.ReadLine();
        }
    }
}
