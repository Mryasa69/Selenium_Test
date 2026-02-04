using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI; // Needed for WebDriverWait
using SeleniumExtras.WaitHelpers; // Needed for ExpectedConditions
using System;

namespace Assignment02_Testing.PageObjects
{
    public class ClientDelayPage
    {
        private IWebDriver _driver;

        public ClientDelayPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement TriggerButton => _driver.FindElement(By.Id("ajaxButton"));
        private By ResultLabelLocator => By.ClassName("bg-success");

        public void ClickButtonAndWait()
        {
            TriggerButton.Click();

            // Wait up to 20 seconds for the text to appear
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(ResultLabelLocator));
        }

        public string GetSuccessMessage()
        {
            return _driver.FindElement(ResultLabelLocator).Text;
        }
    }
}