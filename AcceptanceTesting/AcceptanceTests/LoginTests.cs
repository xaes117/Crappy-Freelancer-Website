using System;
using System.Threading;
using AcceptanceTesting.DriverLib;

namespace AcceptanceTesting.AcceptanceTests
{
    public class LoginTests
    {
        //All email addresses must be confirmed
        //All email addresses must be unique
        //Passwords must have at least 6 characters
        //Passwords must have at least one special character
        //Passwords must have at least one numeric character
        //Students must create a basic profile after registration
        //Businesses must create a basic profile after registration

        public static bool PasswordLengthTest(string registrationPage, string email, string password)
        {

            // Open chrome browser
            Driver user = new Driver();
            
            // Go directly to registration page
            user.GoTo(registrationPage);

            // Note: TypeText searches email and password attributed by id
            user.TypeText("email", email);
            user.TypeText("password", password);

            // Click register
            user.Click("Register");

            // Wait for new page to load
            Thread.Sleep(2000);

            // Read the page
            string text = user.ReadPage();

            // Close the browser
            user.Close();

            return text.Contains("Invalid password") ? false : true;

        }
    }
}
