using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using Demos.Shared.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class SleepAction : ActionBase<SleepAction.Data>
    {
        public override void Created()
        {

        }

        public override void End(IMonoAgent agent, Data data)
        {

        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            if (data.Tiredness.tiredness > 20)
            {
                var sleepRecovery = context.DeltaTime * 20f;
                data.Tiredness.tiredness -= sleepRecovery;

                return ActionRunState.Continue;
            }

            return ActionRunState.Stop;
        }

        public override void Start(IMonoAgent agent, Data data)
        {

        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }

            [GetComponent]
            public TirednessBehaviour Tiredness { get; set; }
        }
    } 
}
