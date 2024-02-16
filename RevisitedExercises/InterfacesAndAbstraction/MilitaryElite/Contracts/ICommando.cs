namespace MilitaryElite.Contracts
{
    public interface ICommando
    {
        IReadOnlyCollection<IMission> Missions { get; }
        void AddMission(IMission mission);

    }
}
