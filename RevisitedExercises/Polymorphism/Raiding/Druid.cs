namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int DefaultPower = 80;
        public Druid(string name, int power) 
            : base(name, DefaultPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
