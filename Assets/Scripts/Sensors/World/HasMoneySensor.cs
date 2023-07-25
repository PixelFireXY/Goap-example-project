using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using NpcDailyRoutines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class HasMoneySensor : LocalWorldSensorBase
    {
        public override void Created() { }

        public override void Update() { }

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            var moneyBehaviour = references.GetCachedComponent<MoneyBehaviour>();
            return new SenseValue((int)moneyBehaviour.money);
        }
    }
}
