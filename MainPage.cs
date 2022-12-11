using OpenQA.Selenium;
using System;

namespace TestingForTinex
{
    internal class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement osnovniProizvodi => driver.FindElement(By.LinkText("Основни производи"));

        public void op()
        {

            osnovniProizvodi.Click();
        }
    }

}