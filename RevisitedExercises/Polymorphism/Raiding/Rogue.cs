namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int DefaultPower = 80;
        public Rogue(string name, int power)
            : base(name, DefaultPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
