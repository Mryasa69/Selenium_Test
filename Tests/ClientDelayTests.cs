using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assignment02_Testing.PageObjects;

namespace Assignment02_Testing.Tests
{
    [TestFixture]
    public class ClientDelayTests
    {
        private IWebDriver _driver;
        private ClientDelayPage _delayPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/clientdelay");
            _delayPage = new ClientDelayPage(_driver);
        }

        [TestCase(TestName = "TC003_1_ClientSideDelay_Verification")]
        public void VerifyClientDelay()
        {
            // Test Step: Click and wait
            _delayPage.ClickButtonAndWait();

            // Expected Outcome: "Data calculated on the client side."
            string actualText = _delayPage.GetSuccessMessage();
            Assert.That(actualText, Is.EqualTo("Data calculated on the client side."));
        }

        [TearDown]
        public void Teardown()
        {
            if (_driver != null) { _driver.Quit(); _driver.Dispose(); }
        }
    }
}