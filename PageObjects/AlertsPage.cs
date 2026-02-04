using OpenQA.Selenium;

namespace Assignment02_Testing.PageObjects
{
    public class AlertsPage
    {
        private IWebDriver _driver;

        public AlertsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement AlertBtn => _driver.FindElement(By.Id("alertButton"));
        private IWebElement ConfirmBtn => _driver.FindElement(By.Id("confirmButton"));
        private IWebElement PromptBtn => _driver.FindElement(By.Id("promptButton"));

        public void TriggerAlert() => AlertBtn.Click();
        public void TriggerConfirm() => ConfirmBtn.Click();
        public void TriggerPrompt() => PromptBtn.Click();

        public void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept(); // Clicks "OK"
        }

        public void DismissAlert()
        {
            _driver.SwitchTo().Alert().Dismiss(); // Clicks "Cancel"
        }

        public void TypeInPrompt(string text)
        {
            _driver.SwitchTo().Alert().SendKeys(text);
            _driver.SwitchTo().Alert().Accept();
        }

        public string GetAlertText()
        {
            return _driver.SwitchTo().Alert().Text;
        }
    }
    
}