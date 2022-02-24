using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSwag
{
    public class Tests
    {
        IWebDriver webDriver;
        IWebElement userName;
        IWebElement userPassword;
        IWebElement loginButton;

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            userName = webDriver.FindElement(By.Id("user-name"));
            userPassword = webDriver.FindElement(By.Id("password"));
            loginButton = webDriver.FindElement(By.Id("login-button"));
        }

        [Test]
        public void LoginSuccessful()
        {
            userName.SendKeys("standard_user");
            userPassword.SendKeys("secret_sauce");
            loginButton.Click();
            var appLogo = webDriver.FindElement(By.Id("app_logo"));
            Assert.IsTrue(appLogo.Displayed);
        }

        [Test]
        public void LoginFailure()
        {
            userName.SendKeys("locked_out_user");
            userPassword.SendKeys("secret_sauce");
            loginButton.Click();
            var errorMessage = webDriver.FindElement(By.ClassName("error-button"));
            Assert.IsTrue(errorMessage.Text.Equals("Epic sadface: Sorry, this user has been locked out."));
        }
    }
}