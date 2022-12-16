using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace CRM.Automation.Pages
{
    public class ContactDetailsPage
    {
        private static IWebDriver driver;
        private static WebDriverWait wait;

        public ContactDetailsPage(IWebDriver driver, WebDriverWait wait)
        {
            ContactDetailsPage.driver = driver;
            ContactDetailsPage.wait = wait;
        }

        #region Locators
        private readonly static By _fullName = By.Id("_form_header");
        private readonly static By _category = By.XPath("//p[text()='Category']/..");
        private readonly static By _role = By.XPath("//p[text()='Business Role']/../div");
        #endregion

        #region Elements
        public IWebElement FullName => driver.FindElement(_fullName);
        public IWebElement Category => driver.FindElement(_category);
        public IWebElement Role => driver.FindElement(_role);
        #endregion

        public string GetFullName()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(_fullName));
            return FullName.Text;
        }

        public string GetCategories()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(_category));
            return Category.Text;
        }

        public string GetRole()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(_role));
            return Role.Text;
        }
    }
}
