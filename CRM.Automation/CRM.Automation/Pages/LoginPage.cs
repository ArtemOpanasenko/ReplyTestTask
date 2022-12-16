using CRM.Automation.Configuration;
using OpenQA.Selenium;

namespace CRM.Automation.Pages
{
    public class LoginPage
    {
        private static IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            LoginPage.driver = driver;
        }

        #region Locators
        private readonly static By _userNameInput = By.Id("login_user");
        private readonly static By _passwordInput = By.Id("login_pass");
        private readonly static By _loginButton = By.Id("login_button");
        #endregion

        #region Elements
        public IWebElement UserNameInput => driver.FindElement(_userNameInput);
        public IWebElement PasswordInput => driver.FindElement(_passwordInput);
        public IWebElement LoginButton => driver.FindElement(_loginButton);
        #endregion

        public void Login()
        {
            UserNameInput.SendKeys(Configurations.AppSettings.CRMLogin);
            PasswordInput.SendKeys(Configurations.AppSettings.CRMPassword);
            LoginButton.Click();
        }
    }
}
