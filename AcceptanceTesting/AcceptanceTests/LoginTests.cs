using System;
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

            Driver user = new Driver();
            user.GoTo(registrationPage);

            // Note: TypeText searches email and password attributed by id
            user.TypeText("email", email);
            user.TypeText("password", password);

            user.Click("Register");

            string text = user.ReadPage();

            user.Close();

            return text.Contains("Invalid password") ? false : true;

        }
    }
}
