using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using Demos.Complex.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class GoToWorkAction : ActionBase<GoToWorkAction.Data>
    {
        public override void Start(IMonoAgent agent, Data data)
        {
            // Assume work time is 8 hours
            data.Timer = 8f;
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            data.Timer -= context.DeltaTime;

            if (data.Timer > 0)
                return ActionRunState.Continue;

            // Increase the agent's money by 100 when work is done
            data.Money.money += 100f;

            return ActionRunState.Stop;
        }

        public override void End(IMonoAgent agent, Data data)
        {
        }

        public override void Created()
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
