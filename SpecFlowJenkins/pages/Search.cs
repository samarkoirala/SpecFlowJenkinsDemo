using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SpecFlowJenkins.pages
{
    public class Search
    {
        private IWebDriver _driver;

        public Search(IWebDriver browser)
        {
            this._driver = browser;
        }
        
        public void DoSearch(string search)
        {
            _driver.FindElement(By.Id("lst-ib")).SendKeys(search);
            _driver.FindElement(By.Name("btnG")).Click();
        }

        public bool ValidateSearch(string validation)
        {
            return _driver.PageSource.ToLower().Contains(validation);
        }
    }
}
