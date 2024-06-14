namespace VehicleRentalSystem.Entities
{
    public class Customer
    {
        private string Name { get; set; }
        private int Age { get; set; }
        private int Experience { get; set; }

        public Customer(string name, int age, int experience)
        {
            Name = name;
            Age = age;
            Experience = experience;
        }
        public String GetName()
        {
            return Name;
        }

        public int GetExperience()
        {
            return Experience;
        }

        public int GetAge()
        {
            return Age;
        }
    }
}
