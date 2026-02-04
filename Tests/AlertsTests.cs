using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assignment02_Testing.PageObjects;

namespace Assignment02_Testing.Tests
{
    [TestFixture]
    public class AlertsTests
    {
        private IWebDriver _driver;
        private AlertsPage _alertsPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/alerts");
            _alertsPage = new AlertsPage(_driver);
        }

        [TestCase(TestName = "TC004_2_Alerts_VerifyAlertText")]
        public void VerifyAlertText()
        {
            _alertsPage.TriggerAlert();
            // Check text inside the popup
            string alertText = _alertsPage.GetAlertText();
            Assert.That(alertText.Contains("working day"), Is.True);
            _alertsPage.AcceptAlert();
        }

        [TestCase(TestName = "TC004_3_Alerts_VerifyConfirm")]
        public void VerifyConfirm()
        {
            _alertsPage.TriggerConfirm();
            _alertsPage.AcceptAlert(); // Click OK
            // You can add logic here to check the result text on page if required
        }

        [TestCase("TestUser", TestName = "TC004_4_Alerts_VerifyPrompt")]
        public void VerifyPrompt(string name)
        {
            _alertsPage.TriggerPrompt();
            _alertsPage.TypeInPrompt(name); // Type name and OK
        }

        [TearDown]
        public void Teardown()
        {
            if (_driver != null) { _driver.Quit(); _driver.Dispose(); }
        }
    }
}