using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class HasFoodSensor : LocalWorldSensorBase
    {
        public override void Created() { }

        public override void Update() { }

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            // Check if there's food in the kitchen
            var kitchen = references.GetCachedComponent<KitchenSource>();
            return new SenseValue(kitchen.food > 0);
        }
    }
}
