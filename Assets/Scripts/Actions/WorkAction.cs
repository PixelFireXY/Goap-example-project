using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class WorkAction : ActionBase<WorkAction.Data>
    {


        public override void Created()
        {
        }

        public override void Start(IMonoAgent agent, Data data)
        {
            // Let's say shopping takes 2 hours
            data.Timer = 8f;
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            data.Timer -= context.DeltaTime;

            if (data.Timer > 0)
                return ActionRunState.Continue;

            // Add the money
            data.Money.money += 50f;

            return ActionRunState.Stop;
        }

        public override void End(IMonoAgent agent, Data data)
        {
        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }
            public float Timer { get; set; }



            [GetComponent]
            public MoneyBehaviour Money { get; set; }
        }
    } 
}
