using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;


namespace Pages
{
    public class GoogleMainPage : BasePage
    {
        private string expectedPageTile = "Google2";
        private string homePageUrl;

        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "lst-ib")]
        public IWebElement searchField;

        public GoogleMainPage(IWebDriver driver, string url) : base(driver)
        {
            homePageUrl = url;
            this.driver = driver;
        }

        public void EnterSearchField(string searchString)
        {
            searchField.SendKeys(searchString);
        }

        public void Load()
        {
            driver.Navigate().GoToUrl(homePageUrl);
        }

        public void IsLoaded()
        {
            Assert.AreEqual(expectedPageTile, driver.Title);
        }
    }
}
