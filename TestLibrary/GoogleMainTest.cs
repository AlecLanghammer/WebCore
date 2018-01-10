using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore;
using NUnit.Framework;
using Pages;
using OpenQA.Selenium;



namespace TestLibrary
{
    [TestFixture]
    class GoogleMainTest : BaseTest
    {       
        GoogleMainPage googleMainPage;
        
        [SetUp]
        public void StartTest()
        {
            googleMainPage = new GoogleMainPage(driver, "http://www.google.com");
        }
        
        [Test]
        public void GoogleMainPageTest()
        {
            googleMainPage.Load();
            googleMainPage.IsLoaded();
            googleMainPage.EnterSearchField("Test");            
        }       
    }
}
