using OpenQA.Selenium;

namespace Assignment02_Testing.PageObjects
{
    public class SampleAppPage
    {
        private IWebDriver _driver;

        public SampleAppPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Names found on http://uitestingplayground.com/sampleapp
        private IWebElement UserName => _driver.FindElement(By.Name("UserName"));
        private IWebElement Password => _driver.FindElement(By.Name("Password"));
        private IWebElement LoginBtn => _driver.FindElement(By.Id("login"));
        private IWebElement LoginStatus => _driver.FindElement(By.Id("loginstatus"));

        public void Login(string user, string pass)
        {
            UserName.Clear();
            UserName.SendKeys(user);
            Password.Clear();
            Password.SendKeys(pass);
            LoginBtn.Click();
        }

        public string GetStatusText()
        {
            return LoginStatus.Text;
        }
    }
}
