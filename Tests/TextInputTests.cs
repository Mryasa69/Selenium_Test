using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assignment02_Testing.PageObjects;

namespace Assignment02_Testing.Tests
{
    [TestFixture]
    public class TextInputTests
    {
        private IWebDriver _driver;
        private TextInputPage _textInputPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            // Go specifically to the Text Input page
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/textinput");
            _textInputPage = new TextInputPage(_driver);
        }

        [TestCase("MyNewName", TestName = "TC001_1_TextInput_Verification")]
        public void VerifyButtonNameChange(string myText)
        {
            // Test Step: Enter text and press button
            _textInputPage.EnterTextAndClick(myText);

            // Expected Outcome: Button text changes to user text
            string actualText = _textInputPage.GetButtonText();
            Assert.That(actualText, Is.EqualTo(myText));
        }

        [TearDown]
        public void Teardown()
        {
            if (_driver != null) { _driver.Quit(); _driver.Dispose(); }
        }
    }
}
