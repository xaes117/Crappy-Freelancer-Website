using System;
using System.Threading;
using AcceptanceTesting.DriverLib;

namespace AcceptanceTesting.AcceptanceTests
{
    public class LoginTests
    {

        private static int WaitTime = 1000;

        // ID: 2.1.1 & 2.1.2 
        // Rule 1: Account must be locked after five failed login attempts
        // Rule 2: Users cannot attempt to login to a locked account
        public static bool LockTest(string loginPage, string email, string incorrectPassword, string correctPassword)
        {
            Driver user = new Driver();

            // Attempt incorrect login more than 5 times
            for (int i = 0; i < 6; i++)
            {
                // go to login page
                user.GoTo(loginPage);

                // wait for page to load
                user.Wait(LoginTests.WaitTime);

                // enter email and password
                user.TypeText("email", email);
                user.TypeText("password", incorrectPassword);

                // login and wait
                user.Click("Login");
                user.Wait(LoginTests.WaitTime);
            }

            // read page
            string text = user.ReadPage();
           
            // confirm rule 1
            bool rule1 = text.Contains("Account locked") && text.Contains("5 minutes");

            // return to login page
            user.GoTo(loginPage);

            // wait for page to load
            user.Wait(WaitTime);

            // enter email and password
            user.TypeText("email", email);
            user.TypeText("password", correctPassword);
            
            // login and wait for response
            user.Click("Login");
            user.Wait(WaitTime);

            // confirm rule 2
            bool rule2 = user.ReadPage().Contains("Account locked");

            // return the two rules
            return rule1 && rule2;
        }

        // 2.2.1 Users must be shown the home page after login
        // 2.3.1 Users can reset their password if forgotten

    }
}
