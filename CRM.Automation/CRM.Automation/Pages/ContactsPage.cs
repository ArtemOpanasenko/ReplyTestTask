using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace CRM.Automation.Pages
{
    public class ContactsPage
    {
        private static IWebDriver driver;
        private static WebDriverWait wait;

        public ContactsPage(IWebDriver driver, WebDriverWait wait)
        {
            ContactsPage.driver = driver;
            ContactsPage.wait = wait;
        }

        #region Locators
        private readonly static By _createContactSideBarButton = By.XPath("//div[@id='left-sidebar']//div[2]");
        #endregion

        #region Elements
        public IWebElement CreateContactSideBarButton => driver.FindElement(_createContactSideBarButton);
        #endregion

        public void GoToCreateContactPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(_createContactSideBarButton));
            CreateContactSideBarButton.Click();
        }

        public void GoToSelectedContact(string firstName, string lastName)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//a[text()='{firstName} {lastName}']")));
            driver.FindElement(By.XPath($"//a[text()='{firstName} {lastName}']")).Click();
        }
    }
}