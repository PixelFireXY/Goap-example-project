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
        private KitchenSource kitchenSource;
        public override void Created()
        {
            kitchenSource = GameObject.FindAnyObjectByType<KitchenSource>();
        }

        public override void Update() { }

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            // Check if there's food in the kitchen
            return new SenseValue(kitchenSource.food > 0);
        }
    }
}
