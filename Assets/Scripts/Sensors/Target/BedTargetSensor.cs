using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class BedTargetSensor : LocalTargetSensorBase
    {
        // List or other data structure to hold all the Bed objects in the scene
        private BedSource[] beds;

        // On creation, find all the Bed objects in the scene
        public override void Created()
        {
            this.beds = GameObject.FindObjectsOfType<BedSource>();
        }

        // The Sense method returns the closest bed to the agent
        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            var closestBed = this.beds.OrderBy(b => Vector3.Distance(b.transform.position, agent.transform.position)).FirstOrDefault();

            if (closestBed == null)
            {
                return null;
            }

            return new TransformTarget(closestBed.transform);
        }

        public override void Update()
        {
        }
    }
}
