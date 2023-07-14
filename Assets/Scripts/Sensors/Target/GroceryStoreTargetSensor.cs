using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class GroceryStoreTargetSensor : LocalTargetSensorBase
    {
        private GroceryStoreSource[] groceryStores;

        public override void Created()
        {
            this.groceryStores = GameObject.FindObjectsOfType<GroceryStoreSource>();
        }

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            var closestGroceryStore = this.groceryStores.OrderBy(g => Vector3.Distance(g.transform.position, agent.transform.position)).FirstOrDefault();

            if (closestGroceryStore == null)
            {
                return null;
            }

            return new TransformTarget(closestGroceryStore.transform);
        }

        public override void Update()
        {
        }
    }
}
