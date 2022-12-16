using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SeleniumExtras.WaitHelpers;

namespace CRM.Automation.Pages
{
    public class ActivityLogPage
    {
        private static IWebDriver driver;
        private static WebDriverWait wait;

        public ActivityLogPage(IWebDriver driver, WebDriverWait wait)
        {
            ActivityLogPage.driver = driver;
            ActivityLogPage.wait = wait;
        }

        #region Locators
        private readonly static By _activitiesCountText = By.XPath("//div[contains(text(),'Selected')]/span[2]");
        private readonly static By _activityCheckboxes = By.XPath("//table[contains(@class,'listView')]//tr//input");
        private readonly static By _actionsButton = By.XPath("//button[contains(@class,'input-button menu-source')]");
        private readonly static By _deleteButton = By.XPath("//div[text()='Delete']");
        #endregion

        #region Elements
        public IWebElement ActivitiesCountText => driver.FindElement(_activitiesCountText);
        public IWebElement ActionsButton => driver.FindElement(_actionsButton);
        public IWebElement DeleteButton => driver.FindElement(_deleteButton);
        public ReadOnlyCollection<IWebElement> ActivityCheckboxes => driver.FindElements(_activityCheckboxes);
        #endregion

        public int GetActivitiesCount()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(_activitiesCountText));
            return int.Parse(ActivitiesCountText.Text.Replace(",",""));
        }
        
        public void SelectActivities(int count)
        {
            for(var i = 1; i <= count; i++)
            {
                ActivityCheckboxes[i].Click();
                wait.Until(ExpectedConditions.ElementToBeSelected(ActivityCheckboxes[i]));
            }
        }

        public void DeleteSelectedActivites()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ActionsButton));
            ActionsButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(_deleteButton));
            DeleteButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            wait.Until(ExpectedConditions.ElementToBeClickable(ActionsButton));
        }
    }
}
