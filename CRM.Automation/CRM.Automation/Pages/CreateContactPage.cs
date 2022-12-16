using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace CRM.Automation.Pages
{
    public class CreateContactPage
    {
        private static IWebDriver driver;
        private static WebDriverWait wait;

        public CreateContactPage(IWebDriver driver, WebDriverWait wait)
        {
            CreateContactPage.driver = driver;
            CreateContactPage.wait = wait;
        }

        #region Locators
        private readonly static By _firstNameInput = By.Id("DetailFormfirst_name-input");
        private readonly static By _lastNameInput = By.Id("DetailFormlast_name-input");
        private readonly static By _categoryOpenDropdownButton = By.XPath("//div[@id='DetailFormcategories-input']");
        private readonly static By _categoryDropdown = By.XPath("//div[@id='DetailFormcategories-input-search']");
        private readonly static By _categoryOptionSearchInput = By.XPath("//div[@id='DetailFormcategories-input-search-text']/input");
        private readonly static By _categoryOption = By.XPath("//div[@id='DetailFormcategories-input-search-list']//div[contains(@class,'option-cell')]");
        private readonly static By _buisnessRoleOpenDropdownButton = By.Id("DetailFormbusiness_role-input-label");
        private readonly static By _saveButton = By.Id("DetailForm_save-label");
        #endregion

        #region Elements
        public IWebElement FirstNameInput => driver.FindElement(_firstNameInput);
        public IWebElement LastNameInput => driver.FindElement(_lastNameInput);
        public IWebElement CategoryOpenDropdownButton => driver.FindElement(_categoryOpenDropdownButton);
        public IWebElement СategoryDropdown => driver.FindElement(_categoryDropdown);
        public IWebElement CategoryOptionSearchInput => СategoryDropdown.FindElement(_categoryOptionSearchInput);
        public IWebElement CategoryOption => driver.FindElement(_categoryOption);
        public IWebElement BuisnessRoleOpenDropdownButton => driver.FindElement(_buisnessRoleOpenDropdownButton);
        public IWebElement SaveButton => driver.FindElement(_saveButton);
        #endregion

        public void FillNewContactInfo(string firstName, string lastName, string categories, string role)
        {
            
            wait.Until(ExpectedConditions.ElementExists(_firstNameInput));
            FirstNameInput.SendKeys(firstName);
            LastNameInput.SendKeys(lastName);

            var categoriesArray = categories.Split(',');
            for(var i = 0; i < categoriesArray.Length; i++)
            {
                Thread.Sleep(500);
                CategoryOpenDropdownButton.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(_categoryDropdown));
                CategoryOptionSearchInput.SendKeys(categoriesArray[i]);
                CategoryOption.Click();
            }

            BuisnessRoleOpenDropdownButton.Click();
            driver.FindElement(By.XPath($"//div[text()='{role}']")).Click();


            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", SaveButton);
            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}
