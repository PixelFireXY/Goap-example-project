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
    public class GoToGroceryAction : ActionBase<GoToGroceryAction.Data>
    {
        public override void Start(IMonoAgent agent, Data data)
        {
            // Find the grocery store
            var store = GameObject.FindObjectOfType<GroceryStore>();

            if (store == null)
                return;

            data.Store = store;
            data.Target = new TransformTarget(store.transform);
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            if (data.Store == null)
                return ActionRunState.Stop;

            // Increase groceries count
            data.AgentGroceries.Groceries += 10;
            return ActionRunState.Stop;
        }

        public override void End(IMonoAgent agent, Data data)
        {
            // Clean up
        }

        public override void Created()
        {
            throw new System.NotImplementedException();
        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }
            public GroceryStore Store { get; set; }

            [GetComponent]
            public AgentGroceries AgentGroceries { get; set; }
        }
    }
}