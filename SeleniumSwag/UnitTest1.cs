using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSwag
{
    public class Tests
    {
        IWebDriver webDriver;
        LoginPage loginPage;
        InventoryPage inventoryPage;

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            loginPage = new LoginPage(webDriver);
            inventoryPage = new InventoryPage(webDriver);
            webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void LoginSuccessful()
        {
            loginPage.UserLogin("standard_user", "secret_sauce");
            var appLogo = inventoryPage.GetLogo();
            Assert.IsTrue(appLogo.Displayed, "Verify that the application logo is displayed");
        }

        [Test]
        public void LoginFailure()
        {
            loginPage.UserLogin("locked_out_user", "secret_sauce");
            Assert.IsTrue(loginPage.ErrorMessage().Contains("Sorry, this user has been banned."), "Verify that the error message is displayed.");
        }
    }
}