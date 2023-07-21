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
    public class EatAction : ActionBase<EatAction.Data>
    {
        private KitchenSource[] kitchens;

        public override void Created()
        {
        }

        public override void Start(IMonoAgent agent, Data data)
        {
            kitchens = GameObject.FindObjectsOfType<KitchenSource>();
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            if (data.Hunger.Hunger > 20)
            {
                var eatNutrition = context.DeltaTime * 20f;
                data.Hunger.Hunger -= eatNutrition;

                return ActionRunState.Continue;
            }

            kitchens[0].food--;

            return ActionRunState.Stop;
        }

        public override void End(IMonoAgent agent, Data data)
        {
        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }

            [GetComponent]
            public HungerBehaviour Hunger { get; set; }
        }
    }
}
