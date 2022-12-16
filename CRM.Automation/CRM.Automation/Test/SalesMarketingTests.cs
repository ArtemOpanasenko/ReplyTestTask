using CRM.Automation.Configuration;
using CRM.Automation.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CRM.Automation.Test
{
    class SalesMarketingTests : TestBase
    {

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Configurations.AppSettings.CRMUrl);
            LoginPage.Login();
        }

        [Test]
        public void CreateContactTest()
        {
            HomePage.GoToContactsPage();
            ContactsPage.GoToCreateContactPage();
            CreateContactPage.FillNewContactInfo(ContactName, ContactSurname, ContactCategories, ContactRole);
            ContactsPage.GoToSelectedContact(ContactName, ContactSurname);

            Assert.AreEqual($"{ContactName} {ContactSurname} ", ContactDetailsPage.GetFullName(), "Full name doesn't match entered data");
            Assert.AreEqual($"Category\r\n{ContactCategories}", ContactDetailsPage.GetCategories(), "Categories doesn't match entered data");
            Assert.AreEqual($"{ContactRole}", ContactDetailsPage.GetRole(), "Role doesn't match entered data");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
