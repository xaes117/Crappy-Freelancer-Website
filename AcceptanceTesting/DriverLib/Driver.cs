using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AcceptanceTesting.DriverLib
{
    class Driver
    {
        private IWebDriver driver;

        public Driver()
        {
             this.driver = new ChromeDriver();
        }

        // Go to url
        public void GoTo(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

        // Click on a button
        public void Click(string buttonName)
        {
            
        }

        // Hit Enter key
        public void Enter()
        {

        }

        // Enter text into a box
        public void TypeText(string text)
        {

        }

        public void Close()
        {
            this.driver.Close();
        }
    }
}
