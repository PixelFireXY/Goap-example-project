using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class IsAtWorkSensor : LocalWorldSensorBase
    {
        public override void Created() { }

        public override void Update() { }

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            var workBehaviour = references.GetCachedComponent<WorkBehaviour>();
            return new SenseValue(workBehaviour.isWorking);
        }
    }
}
