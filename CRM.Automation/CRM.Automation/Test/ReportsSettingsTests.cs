using CRM.Automation.Configuration;
using CRM.Automation.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CRM.Automation.Test
{
    class ReportsSettingsTests : TestBase
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
        public void RunReportTest()
        {
            HomePage.GoToReportsPage();
            ReportsPage.GoToSelectedReport("Project Profitability");
            SelectedReportPage.RunReport();

            Assert.That(SelectedReportPage.ReportRecords.Count != 0);
        }

        [Test]
        public void RemoveEventsFromActivityLogTest()
        {
            HomePage.GoToActivityLogPage();
            var activitiesCountBeforeDeleting = ActivityLogPage.GetActivitiesCount();
            ActivityLogPage.SelectActivities(3);
            ActivityLogPage.DeleteSelectedActivites();
            Assert.AreNotEqual(ActivityLogPage.GetActivitiesCount(), activitiesCountBeforeDeleting);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
