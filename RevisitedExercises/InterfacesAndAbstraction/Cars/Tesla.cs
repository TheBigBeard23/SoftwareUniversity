using Cars.Contracts;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int batteries)
        {
            this.Model = model;
            this.Color = color;
            this.Baterry = batteries;
        }
        public int Baterry { set; get; }
        public string Model { set; get; }
        public string Color { set; get; }

        public string Start()
        {
            return $"{this.Color} Tesla {this.Model} with {this.Baterry} Batteries\nEngine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            return sb.ToString().TrimEnd();
        }
    }
}
