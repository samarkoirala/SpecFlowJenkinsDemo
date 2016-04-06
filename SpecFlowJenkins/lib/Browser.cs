using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SpecFlowJenkins.lib
{
    public class Browser
    {
        private IWebDriver _driver;

        public IWebDriver LaunchBrowser()
        {
            switch (ConfigurationManager.AppSettings["target_browser"].ToLower())
            {
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                default:
                    _driver = new ChromeDriver();
                    break;

            }
            _driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(600));
            _driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(600));
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["base_url"]);
            return _driver;
        }

        public void CLoseBrowser(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
