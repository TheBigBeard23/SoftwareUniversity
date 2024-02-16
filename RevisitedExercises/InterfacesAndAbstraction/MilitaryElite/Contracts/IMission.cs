using MilitaryElite.Enums;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        public string Name { get; }
        public MissionState State { get; }
        void ComplateMission();
    }
}
