using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            this.driver.FindElement(By.PartialLinkText(buttonName)).Click();
        }

        // Enter text into a box
        public void TypeText(string fieldId, string text)
        {
            this.driver.FindElement(By.Id(fieldId)).SendKeys(text);
        }

        public string ReadPage()
        {
            return this.driver.FindElement(By.TagName("body")).Text.ToString();
        }

        public void Wait(int time)
        {
            Thread.Sleep(time);
        }

        public void Close()
        {
            this.driver.Close();
        }
    }
}
