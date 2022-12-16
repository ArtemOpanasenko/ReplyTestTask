using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CRM.Automation.Pages
{
    public class HomePage
    {
        private static IWebDriver driver;
        private static WebDriverWait wait;
        private static Actions action;

        public HomePage(IWebDriver driver, WebDriverWait wait)
        {
            HomePage.driver = driver;
            HomePage.wait = wait;
            HomePage.action = new Actions(driver);
        }

        #region Locators
        private readonly static By _salesMarketingMenuBar = By.Id("grouptab-1");
        private readonly static By _reportsSettingsMenuBar = By.Id("grouptab-5");
        private readonly static By _contactsMenuOption = By.XPath("//a[text()=' Contacts']");
        private readonly static By _reportsMenuOption = By.XPath("//a[text()=' Reports']");
        private readonly static By _activityLogMenuOption = By.XPath("//a[text()=' Activity Log']");
        #endregion

        #region Elements
        public IWebElement SalesMarketingMenuBar => driver.FindElement(_salesMarketingMenuBar);
        public IWebElement ReportsSettingsMenuBar => driver.FindElement(_reportsSettingsMenuBar);
        public IWebElement ContactsMenuOption => driver.FindElement(_contactsMenuOption);
        public IWebElement ReportsMenuOption => driver.FindElement(_reportsMenuOption);
        public IWebElement ActivityLogMenuOption => driver.FindElement(_activityLogMenuOption);
        #endregion

        public void GoToContactsPage()
        {
            wait.Until(ExpectedConditions.ElementExists(_salesMarketingMenuBar));
            action.MoveToElement(SalesMarketingMenuBar);
            action.Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(_contactsMenuOption));
            ContactsMenuOption.Click();
        }

        public void GoToReportsPage()
        {
            wait.Until(ExpectedConditions.ElementExists(_reportsSettingsMenuBar));
            action.MoveToElement(ReportsSettingsMenuBar);
            action.Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(_reportsMenuOption));
            ReportsMenuOption.Click();
        }

        public void GoToActivityLogPage()
        {
            wait.Until(ExpectedConditions.ElementExists(_reportsSettingsMenuBar));
            action.MoveToElement(ReportsSettingsMenuBar);
            action.Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(_activityLogMenuOption));
            ActivityLogMenuOption.Click();
        }
    }
}
