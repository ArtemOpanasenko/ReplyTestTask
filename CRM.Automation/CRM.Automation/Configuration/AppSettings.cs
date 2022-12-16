namespace CRM.Automation.Configuration
{
    public class AppSettings
    {
        public string CRMUrl { get; }
        public string CRMLogin { get; }
        public string CRMPassword { get; }

        public AppSettings(string cRMUrl, string cRMLogin, string cRMPassword)
        {
            CRMUrl = cRMUrl;
            CRMLogin = cRMLogin;
            CRMPassword = cRMPassword;
        }
    }
}
