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
            builder.AddGoal<WanderGoal>()
                .AddCondition<IsWandering>(Comparison.GreaterThanOrEqual, 1);

            builder.AddGoal<EatGoal>()
                .AddCondition<IsHungry>(Comparison.SmallerThanOrEqual, 0);

            builder.AddGoal<GroceryGoal>()
                .AddCondition<HasFood>(Comparison.GreaterThanOrEqual, 1);

            builder.AddGoal<WorkGoal>()
                .AddCondition<HasMoney>(Comparison.GreaterThanOrEqual, 1);

            builder.AddGoal<SleepGoal>()
                .AddCondition<IsTired>(Comparison.SmallerThanOrEqual, 0);

            // Actions
            builder.AddAction<WanderAction>()
                .SetTarget<WanderTarget>()
                .AddEffect<IsWandering>(true);

            builder.AddAction<EatAction>()
                .SetTarget<KitchenTarget>()
                .AddEffect<IsHungry>(false);

            builder.AddAction<BuyGroceriesAction>()
                .SetTarget<GroceryStoreTarget>()
                .AddEffect<HasFood>(true);

            builder.AddAction<WorkAction>()
                .SetTarget<WorkplaceTarget>()
                .AddEffect<HasMoney>(true);

            builder.AddAction<SleepAction>()
                .SetTarget<BedTarget>()
                .AddEffect<IsTired>(false);

            // World Sensors
            builder.AddTargetSensor<WanderTargetSensor>()
                .SetTarget<WanderTarget>();

            builder.AddWorldSensor<IsHungrySensor>()
                .SetKey<IsHungry>();
            builder.AddWorldSensor<HasMoneySensor>()
                .SetKey<HasMoney>();
            builder.AddWorldSensor<IsTiredSensor>()
                .SetKey<IsTired>();
            builder.AddWorldSensor<HasFoodSensor>()
                .SetKey<HasFood>();

            // Target Sensors
            builder.AddTargetSensor<KitchenTargetSensor>()
                .SetTarget<KitchenTarget>();
            builder.AddTargetSensor<GroceryStoreTargetSensor>()
                .SetTarget<GroceryStoreTarget>();
            builder.AddTargetSensor<WorkplaceTargetSensor>()
                .SetTarget<WorkplaceTarget>();
            builder.AddTargetSensor<BedTargetSensor>()
                .SetTarget<BedTarget>();

            return builder.Build();
        }
    }
}

