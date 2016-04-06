using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlowJenkins.lib;
using SpecFlowJenkins.pages;
using TechTalk.SpecFlow;

namespace SpecFlowJenkins.specs
{
    [Binding]
    public class GoogleSearchSteps
    {
        public IWebDriver Driver;
        public Search SearchPage;

        [Given(@"I am on the google search page")]
        public void GivenIAmOnTheGoogleSearchPage()
        {
            Browser browser = new Browser();
            Driver = browser.LaunchBrowser();
        }
        
        [Given(@"I have entered (.*) in the serach box with enter")]
        public void GivenIHaveEnteredInTheSerachBoxWithEnter(int p0)
        {
            SearchPage = new Search(Driver);
            SearchPage.DoSearch(ConfigurationManager.AppSettings["search_term"].ToLower());
        }
        
        [Then(@"the result should contain (.*) on the search results page")]
        public void ThenTheResultShouldContainOnTheSearchResultsPage(int p0)
        {
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(SearchPage.ValidateSearch(ConfigurationManager.AppSettings["search_validation"].ToLower()) , true);
            Driver.Quit();
        }
    }
}
