using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class IsHungrySensor : LocalWorldSensorBase
    {
        public override void Created() { }

        public override void Update() { }

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            var hungerBehaviour = references.GetCachedComponent<HungerBehaviour>();
            return new SenseValue(hungerBehaviour.Hunger > 20);
        }
    }
}
