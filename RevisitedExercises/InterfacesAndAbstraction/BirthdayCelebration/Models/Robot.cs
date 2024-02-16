using BirthdayCelebration.Contracts;


namespace BirthdayCelebration.Models
{
    public class Robot : IRobot, IIdentifiable
    {
        public Robot(string model, string Id)
        {
            Model = model;
            this.Id = Id;
        }
        public string Model { get; set; }
        public string Id { get; set; }
    }
}
