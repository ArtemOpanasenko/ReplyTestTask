using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace CRM.Automation.Pages
{
    public class SelectedReportPage
    {
        private static IWebDriver driver;
        private static WebDriverWait wait;

        public SelectedReportPage(IWebDriver driver, WebDriverWait wait)
        {
            SelectedReportPage.driver = driver;
            SelectedReportPage.wait = wait;
        }

        #region Locators
        private readonly static By _runReportButton = By.XPath("//button[@name='FilterForm_applyButton']");
        private readonly static By _reportRecords = By.XPath("//table[contains(@class,'listView')]/tbody/tr");

        #endregion

        #region Elements
        public IWebElement RunReportButton => driver.FindElement(_runReportButton);
        public ReadOnlyCollection<IWebElement> ReportRecords => driver.FindElements(_reportRecords);
        #endregion

        public void RunReport()
        {
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(_runReportButton));
            RunReportButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(_reportRecords));
        }
    }
}
