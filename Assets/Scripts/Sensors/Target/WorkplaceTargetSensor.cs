using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class WorkplaceTargetSensor : LocalTargetSensorBase
    {
        private WorkplaceSource[] workplaces;

        public override void Created()
        {
            this.workplaces = GameObject.FindObjectsOfType<WorkplaceSource>();
        }

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            var closestWorkplace = this.workplaces.OrderBy(w => Vector3.Distance(w.transform.position, agent.transform.position)).FirstOrDefault();

            if (closestWorkplace == null)
            {
                return null;
            }

            return new TransformTarget(closestWorkplace.transform);
        }

        public override void Update()
        {
        }
    }
}
