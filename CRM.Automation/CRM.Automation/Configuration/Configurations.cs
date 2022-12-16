using Newtonsoft.Json;

namespace CRM.Automation.Configuration
{
    public static class Configurations
    {
        public static AppSettings AppSettings => JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText("appsettings.json"));
        public static TestContact TestContact => JsonConvert.DeserializeObject<TestContact>(File.ReadAllText("testContactData.json"));
    }
}
