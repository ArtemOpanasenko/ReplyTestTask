using CRM.Automation.Configuration;
using CRM.Automation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CRM.Automation.Test
{
    public class TestBase
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;

        protected string ContactName = Configurations.TestContact.Name;
        protected string ContactSurname = Configurations.TestContact.Surname;
        protected string ContactCategories = Configurations.TestContact.Categories;
        protected string ContactRole = Configurations.TestContact.Role;


        protected LoginPage LoginPage => new LoginPage(driver);
        protected HomePage HomePage => new HomePage(driver, wait);
        protected ContactsPage ContactsPage => new ContactsPage(driver, wait);
        protected CreateContactPage CreateContactPage => new CreateContactPage(driver, wait);
        protected ContactDetailsPage ContactDetailsPage => new ContactDetailsPage(driver, wait);
        protected ReportsPage ReportsPage => new ReportsPage(driver, wait);
        protected SelectedReportPage SelectedReportPage => new SelectedReportPage(driver, wait);
        protected ActivityLogPage ActivityLogPage => new ActivityLogPage(driver, wait);


        //[OneTimeSetUp]
        //public void OneTimeSetUp()
        //{
        //    driver.Manage().Window.Maximize();
        //}
    }
}
