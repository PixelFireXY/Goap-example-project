using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;
using CrashKonijn.Goap.Resolver;
using Demos.Simple.Sensors.World;

namespace NpcDailyRoutines
{
    public class NpcGoapSetConfigFactory : GoapSetFactoryBase
    {
        public override IGoapSetConfig Create()
        {
            var builder = new GoapSetBuilder("NpcDailyActivitiesSet");

            // Goals
            builder.AddGoal<SleepGoal>()
                .AddCondition<IsTired>(Comparison.GreaterThan, 0); // IsTired == true
            builder.AddGoal<EatGoal>()
                .AddCondition<IsHungry>(Comparison.GreaterThan, 0); // IsHungry == true
            builder.AddGoal<GroceryGoal>()
                .AddCondition<HasFood>(Comparison.SmallerThan, 1); // HasFood == false
            builder.AddGoal<WorkGoal>()
                .AddCondition<IsAtWork>(Comparison.SmallerThan, 1); // IsAtWork == false

            // Actions
            builder.AddAction<SleepAction>()
                .SetTarget<BedTarget>()
                .AddEffect<IsTired>(false) // IsTired becomes false
                .SetBaseCost(1)
                .SetInRange(0.3f);
            builder.AddAction<EatAction>()
                .SetTarget<FoodTarget>()
                .AddEffect<IsHungry>(false) // IsHungry becomes false
                .SetBaseCost(1)
                .SetInRange(0.3f);
            builder.AddAction<BuyGroceriesAction>()
                .SetTarget<GroceryTarget>()
                .AddEffect<HasFood>(true) // HasFood becomes true
                .SetBaseCost(1)
                .SetInRange(0.3f);
            builder.AddAction<WorkAction>()
                .SetTarget<WorkTarget>()
                .AddEffect<IsAtWork>(true) // IsAtWork becomes true
                .SetBaseCost(1)
                .SetInRange(0.3f);

            // World Sensors
            builder.AddWorldSensor<IsTiredSensor>()
                .SetKey<IsTired>();
            builder.AddWorldSensor<IsHungrySensor>()
                .SetKey<IsHungry>();
            builder.AddWorldSensor<HasFoodSensor>()
                .SetKey<HasFood>();
            builder.AddWorldSensor<IsAtWorkSensor>()
                .SetKey<IsAtWork>();

            // Target Sensors
            builder.AddTargetSensor<BedTargetSensor>()
                .SetTarget<BedTarget>();
            builder.AddTargetSensor<KitchenTargetSensor>()
                .SetTarget<FoodTarget>();
            builder.AddTargetSensor<GroceryStoreTargetSensor>()
                .SetTarget<GroceryTarget>();
            builder.AddTargetSensor<WorkplaceTargetSensor>()
                .SetTarget<WorkTarget>();

            return builder.Build();
        }
    }
}

