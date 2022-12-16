namespace CRM.Automation.Configuration
{
    public class TestContact
    {
        public string Name { get; }
        public string Surname { get; }
        public string Categories { get; }
        public string Role { get; }

        public TestContact(string name, string surname, string categories, string role)
        {
            Name = name;
            Surname = surname;
            Categories = categories;
            Role = role;
        }
    }
}
