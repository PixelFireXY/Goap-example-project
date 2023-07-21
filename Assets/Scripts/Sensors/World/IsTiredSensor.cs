using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class IsTiredSensor : LocalWorldSensorBase
    {
        public override void Created() { }

        public override void Update() { }

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            var tirednessBehaviour = references.GetCachedComponent<TirednessBehaviour>();
            return new SenseValue(tirednessBehaviour.tiredness > 80);
        }
    }
}
