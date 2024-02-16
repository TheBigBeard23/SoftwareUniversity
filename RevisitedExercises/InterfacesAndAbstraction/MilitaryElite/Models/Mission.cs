using MilitaryElite.Contracts;
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string name, MissionState state)
        {
            this.Name = name;
            this.State = state;
        }
        public string Name { get; private set; }
        public MissionState State { get; private set; }

        public void ComplateMission()
        {
            this.State = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.Name} State: {this.State}";
        }
    }
}
