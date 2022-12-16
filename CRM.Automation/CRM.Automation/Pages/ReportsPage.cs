using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace CRM.Automation.Pages
{
    public class ReportsPage
    {
        private static IWebDriver driver;
        private static WebDriverWait wait;

        public ReportsPage(IWebDriver driver, WebDriverWait wait)
        {
            ReportsPage.driver = driver;
            ReportsPage.wait = wait;
        }

        #region Locators
        private readonly static By _searchTextInput = By.Id("filter_text");
        private readonly static By _secondPageButton = By.XPath("//div[contains(@class,'input-button-group')]/button[2]");
        //private readonly static By _pageSelectionButtons = By.XPath("//div[contains(@class,'input-button-group')]/button");


        #endregion

        #region Elements
        public IWebElement SearchTextInput => driver.FindElement(_searchTextInput);
        public IWebElement SecondPageButton => driver.FindElement(_secondPageButton);
        //public ReadOnlyCollection<IWebElement> PageSelectionButtons => driver.FindElements(_pageSelectionButtons);

        #endregion

        public void GoToSelectedReport(string reportName)
        {
            //Thread.Sleep(2000);
            //wait.Until(ExpectedConditions.ElementToBeClickable(_secondPageButton));
            //try{
            //    SecondPageButton.Click();
            //}
            //catch(StaleElementReferenceException e)
            //{
            //    SecondPageButton.Click();
            //}
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//a[text()='{reportName}']")));
            //driver.FindElement(By.XPath($"//a[text()='{reportName}']")).Click();

            //****works only in debug mode****
            //for (var i = 1; i < (PageSelectionButtons.Count / 2); i++)
            //{
            //    ReadOnlyCollection<IWebElement> report = driver.FindElements(By.XPath($"//a[text()='{reportName}']"));
            //    if (report.Count != 0)
            //    {
            //        report[0].Click();
            //        break;
            //    }
            //    wait.Until(ExpectedConditions.ElementToBeClickable(PageSelectionButtons[i]));
            //    try {
            //        PageSelectionButtons[i].Click();
            //        wait.Until(ExpectedConditions.ElementToBeClickable(PageSelectionButtons[i]));
            //    }
            //    catch(StaleElementReferenceException e) {
            //        PageSelectionButtons[i].Click();
            //        wait.Until(ExpectedConditions.ElementToBeClickable(PageSelectionButtons[i]));
            //    }
            //}


            //****works only in debug mode****

            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementExists(_searchTextInput));
            SearchTextInput.SendKeys(reportName);

            wait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[text()='{reportName}']")));
            driver.FindElement(By.XPath($"//div[text()='{reportName}']")).Click();
        }
    }
}
