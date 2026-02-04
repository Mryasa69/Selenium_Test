using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assignment02_Testing.PageObjects;

namespace Assignment02_Testing.Tests
{
    [TestFixture]
    public class SampleAppTests
    {
        private IWebDriver _driver;
        private SampleAppPage _sampleAppPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/sampleapp");
            _sampleAppPage = new SampleAppPage(_driver);
        }

        // TC002_2: Successful Login
        [TestCase("Yasas", "pwd", "Welcome, Yasas!", TestName = "TC002_2_SampleApp_SuccessfulLogin")]
        public void VerifySuccessfulLogin(string user, string pass, string expected)
        {
            _sampleAppPage.Login(user, pass);
            Assert.That(_sampleAppPage.GetStatusText(), Is.EqualTo(expected));
        }

        // TC002_3: Unsuccessful Login (Wrong password)
        [TestCase("Yasas", "wrongpass", "Invalid username/password", TestName = "TC002_3_SampleApp_UnsuccessfulLogin")]
        public void VerifyUnsuccessfulLogin(string user, string pass, string expected)
        {
            _sampleAppPage.Login(user, pass);
            Assert.That(_sampleAppPage.GetStatusText(), Is.EqualTo(expected));
        }

        [TearDown]
        public void Teardown()
        {
            if (_driver != null) { _driver.Quit(); _driver.Dispose(); }
        }
    }
}