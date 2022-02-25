using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSwag
{
    class LoginPage
    {
        IWebDriver driver;
        private By userNameControl = By.Id("user-name");
        private By passwordControl = By.Id("password");
        private By loginControl = By.Id("login-button");
        private By errorMessage = By.Id("error-message-container");

        public string ErrorMessage => driver.FindElement(errorMessage).Text;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void UserLogin(string username, string password)
        {
            driver.FindElement(userNameControl).SendKeys(username);
            driver.FindElement(passwordControl).SendKeys(password);
            driver.FindElement(loginControl).Click();
        }
    }
}
