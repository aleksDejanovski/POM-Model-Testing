using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingForTinex
{
    [TestFixture]
    public class TestingForTinex
    {
        IWebDriver driver;
        IWebDriver wait;

        [SetUp]
        public void setiranje()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


        }
        [TearDown]
        public void tearDownMethod()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        [Category("Check if user can be logged in after entering valid credentials")]
        public void testLogiranjeZaTinexPozitinoScenario()
        {


            LoginPage page = new LoginPage(driver);
            page.GoTo();
            page.login.Click();
            page.LoginTinex("dejanovski_a@yahoo.com", "aceecar88");
            Assert.IsTrue(driver.FindElement(By.Id("ctl00_btnLogOut")).Text.Contains("Одјавете се"));
            
            
            MainPage main = new MainPage(driver);

            
        }
        [Test]
        [Category("Check if user can be logged in after entering invalid credentials")]
        public void testLogiranjeZaTinexNegativnoScenario()
        {
            LoginPage page = new LoginPage(driver);
            page.GoTo();
            page.login.Click();
            page.LoginTinex("dd", "ssd");
            Assert.IsTrue(driver.FindElement(By.Id("ctl00_btnLogOut")).Text.Contains("Одјавете се"));
           
        }
        [Test]
        [Category("After Login Click osnovniproizvodi")]
        public void CheckIsOsnovniProizvodiClickable()
        {
            LoginPage page = new LoginPage(driver);
            page.GoTo();
            page.login.Click();
            page.LoginTinex("dejanovski_a@yahoo.com", "aceecar88");
            MainPage page2 = new MainPage(driver);
            page2.op();
            Assert.IsTrue(driver.FindElement(By.XPath("//label[@for='checkbox205']")).Text.Contains("Брашно"));

        }

    }
}

