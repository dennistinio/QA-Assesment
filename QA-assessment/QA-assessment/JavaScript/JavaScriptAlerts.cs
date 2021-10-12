using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace JavaScriptAlerts
{
    class JavaScriptAlerts
    {
        public static void Main()
        {

        }
        String test_url = "http://the-internet.herokuapp.com/javascript_alerts";

        IWebDriver driver;

        [SetUp]
        public void start_Browser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test, Order(1)]
        public void test_JSalert()
        {
            String button_xpath = "//button[@onclick='jsAlert()']";
            var expectedAlertText = "I am a JS Alert";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = test_url;

            /* Click the Alert Button on the Popup window */
            IWebElement alertButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(button_xpath)));
            alertButton.Click();
            Thread.Sleep(4000);

            var alert_win = driver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertText, alert_win.Text);

            alert_win.Accept();

            /* IWebElement clickResult = driver.FindElement(By.Id("result")); */
            var clickResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("result")));

            Console.WriteLine(clickResult.Text);

            if (clickResult.Text == "You successfuly clicked an alert")
            {
                Console.WriteLine("Alert Test Successful");
            }

            Thread.Sleep(4000);
            driver.Close();
        }

        [Test, Order(2)]
        public void test_JSconfirm()
        {
            String button_css_selector = "button[onclick='jsConfirm()']";
            var expectedAlertText = "I am a JS Confirm";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = test_url;

            IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));
            confirmButton.Click();
            Thread.Sleep(4000);

            var confirm_win = driver.SwitchTo().Alert();
            confirm_win.Accept();

            IWebElement clickResult = driver.FindElement(By.Id("result"));
            Console.WriteLine(clickResult.Text);

            if (clickResult.Text == "You clicked: Ok")
            {
                Console.WriteLine("Confirm Test Successful");
            }

            Thread.Sleep(4000);
            driver.Close();
        }

        [Test, Order(3)]
        public void test_JScancel()
        {
            String button_css_selector = "button[onclick='jsConfirm()']";
            var expectedAlertText = "I am a JS Confirm";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = test_url;

            IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));
            confirmButton.Click();
            Thread.Sleep(4000);

            var confirm_win = driver.SwitchTo().Alert();
            confirm_win.Dismiss();

            IWebElement clickResult = driver.FindElement(By.Id("result"));
            Console.WriteLine(clickResult.Text);

            if (clickResult.Text == "You clicked: Cancel")
            {
                Console.WriteLine("Dismiss Test Successful");
            }

            Thread.Sleep(4000);
            driver.Close();
        }

        [Test, Order(4)]
        public void test_JSprompt()
        {
            String button_css_selector = "button[onclick='jsPrompt()']";
            var expectedAlertText = "I am a JS prompt";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = test_url;

            IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));
            confirmButton.Click();
            Thread.Sleep(4000);

            var alert_win = driver.SwitchTo().Alert();
            alert_win.SendKeys("This is only a test prompt message");
            alert_win.Accept();

            IWebElement clickResult = driver.FindElement(By.Id("result"));
            Console.WriteLine(clickResult.Text);

            if (clickResult.Text == "You entered: This is only a test prompt message")
            {
                Console.WriteLine("Send Text Alert Test Successful");
            }

            Thread.Sleep(4000);
            driver.Close();
        }
    }
}