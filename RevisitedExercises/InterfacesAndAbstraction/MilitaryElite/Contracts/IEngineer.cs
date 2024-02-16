namespace MilitaryElite.Contracts
{
    public interface IEngineer
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
        void AddRepair(IRepair repair);
    }
}
