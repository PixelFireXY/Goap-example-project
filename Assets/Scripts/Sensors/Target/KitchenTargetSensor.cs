using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class KitchenTargetSensor : LocalTargetSensorBase
    {
        private KitchenSource[] kitchens;

        public override void Created()
        {
            this.kitchens = GameObject.FindObjectsOfType<KitchenSource>();
        }

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            var closestKitchen = this.kitchens.OrderBy(k => Vector3.Distance(k.transform.position, agent.transform.position)).FirstOrDefault();

            if (closestKitchen == null)
            {
                return null;
            }

            return new TransformTarget(closestKitchen.transform);
        }

        public override void Update()
        {
        }
    }
}
