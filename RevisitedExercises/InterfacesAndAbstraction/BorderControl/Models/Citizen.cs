using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Citizen : ICitizen, IIdentifiable
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }

}
