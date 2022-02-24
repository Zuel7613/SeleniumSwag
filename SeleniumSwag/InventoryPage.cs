using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSwag
{
    class InventoryPage
    {
        IWebDriver driver;
        private By appLogo = By.ClassName("app_logo");

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetLogo()
        {
            return driver.FindElement(appLogo);
        }
    }
}
