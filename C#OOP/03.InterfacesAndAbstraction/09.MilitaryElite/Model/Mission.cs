using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Model
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionState missionState)
        {
            CodeName = codeName;
            MissionState = missionState;
        }
        public string CodeName { get; private set; }

        public MissionState MissionState { get; private set; }

        public void ComplateMission()
        {
            MissionState = MissionState.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {MissionState}";
        }
    }
}
