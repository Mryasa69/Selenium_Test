using OpenQA.Selenium;

namespace Assignment02_Testing.PageObjects
{
    public class TextInputPage
    {
        private IWebDriver _driver;

        public TextInputPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // IDs found on http://uitestingplayground.com/textinput
        private IWebElement InputBox => _driver.FindElement(By.Id("newButtonName"));
        private IWebElement UpdateButton => _driver.FindElement(By.Id("updatingButton"));

        public void EnterTextAndClick(string text)
        {
            InputBox.Clear();
            InputBox.SendKeys(text);
            UpdateButton.Click();
        }

        public string GetButtonText()
        {
            return UpdateButton.Text;
        }
    }
}