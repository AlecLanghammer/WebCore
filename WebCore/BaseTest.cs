using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using NUnit.Framework.Interfaces;
using System.Configuration;


namespace WebCore
{
    public abstract class BaseTest
    {
        protected static IWebDriver driver;

        [SetUp]       
        protected void SetupTest()
        {
            switch (ConfigurationManager.AppSettings["browser"].ToLower())
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                default:
                    driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        protected void EndTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success
                && Convert.ToBoolean(ConfigurationManager.AppSettings["ScreenOnFail?"]))
            {
                string testName = TestContext.CurrentContext.Test.Name +"_";
                string date = DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss");
                string path = ConfigurationManager.AppSettings["ScreenshotPath"];
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(path+testName+date+".jpg", ScreenshotImageFormat.Jpeg);
            }
            driver.Quit();
        }
    }
}
