using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using Demos.Complex.Behaviours;
using Demos.Complex.Interfaces;
using Demos.Simple.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class BuyGroceriesAction : ActionBase<BuyGroceriesAction.Data>
    {
        public override void Start(IMonoAgent agent, Data data)
        {
            // Check if agent has enough money to buy groceries (let's assume it costs 50)
            if (data.Money.money < 50f)
            {
                // Can't perform the action due to lack of money
                return;
            }

            // Deduct the money
            data.Money.money -= 50f;

            // Let's say shopping takes 2 hours
            data.Timer = 2f;
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            data.Timer -= context.DeltaTime;

            if (data.Timer > 0)
                return ActionRunState.Continue;

            // Increase groceries by 1 when shopping is done
            data.Inventory.Groceries += 1;

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
            [GetComponent]
            public InventoryBehaviour Inventory { get; set; }
        }
    }

}
