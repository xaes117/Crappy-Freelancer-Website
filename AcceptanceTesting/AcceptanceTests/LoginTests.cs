using System;
using System.Threading;
using AcceptanceTesting.DriverLib;

namespace AcceptanceTesting.AcceptanceTests
{
    public class LoginTests
    {
        //All email addresses must be confirmed
        public static bool ConfirmEmail(string registrationPage, string email, string password)
        {
            Driver user = new Driver();
            user.GoTo(registrationPage);
            user.TypeText("email", email);
            user.TypeText("password", password);
            user.Click("Register");
            user.Wait(2000);
            string text = user.ReadPage();
            user.Close();
            return text.Contains("Confirmation email sent");
        }

        //All email addresses must be unique
        public static bool UniqueEmail(string registrationPage, string email, string password)
        {
            Driver user = new Driver();
            user.GoTo(registrationPage);
            user.TypeText("email", email);
            user.TypeText("password", password);
            user.Click("Register");
            user.Wait(2000);
            string text = user.ReadPage();
            user.Close();
            return !text.Contains("Email address is already associated with an account");
        }

        //Passwords must have at least 6 characters
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
            user.Wait(2000);

            // Read the page
            string text = user.ReadPage();

            // Close the browser
            user.Close();

            // Negate outcome as True => Fail and False => Success
            return !text.Contains("Password must have at least six characters");

        }

        //Passwords must have at least one special character
        public static bool PasswordSpecialCharacterTest(string registrationPage, string email, string password)
        {
            Driver user = new Driver();
            user.GoTo(registrationPage);
            user.TypeText("email", email);
            user.TypeText("password", password);
            user.Click("Register");
            user.Wait(2000);
            string text = user.ReadPage();
            user.Close();
            return !text.Contains("Password must have at least one special character");
        }

        //Passwords must have at least one numeric character
        public static bool PasswordNumericTest(string registrationPage, string email, string password)
        {
            Driver user = new Driver();
            user.GoTo(registrationPage);
            user.TypeText("email", email);
            user.TypeText("password", password);
            user.Click("Register");
            user.Wait(2000);
            string text = user.ReadPage();
            user.Close();
            return !text.Contains("Password must have at least one number");
        }
        
        //Students must create a basic profile after registration
        public static bool CreateFreelanceProfileAfterEmailConfirmation(string confirmationLink)
        {
            Driver user = new Driver();
            user.GoTo(confirmationLink);
            user.Wait(2000);
            string text = user.ReadPage();
            user.Close();
            return text.Contains("Create freelancer profile");
        }

        //Businesses must create a basic profile after registration
        public static bool CreateBusinessProfileAfterEmailConfirmation(string confirmationLink)
        {
            Driver user = new Driver();
            user.GoTo(confirmationLink);
            user.Wait(2000);
            string text = user.ReadPage();
            user.Close();
            return text.Contains("Create business profile");
        }
    }
}
