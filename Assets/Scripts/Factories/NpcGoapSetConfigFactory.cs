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
                .AddCondition<IsHungry>(Comparison.GreaterThan, 1);
            builder.AddGoal<WorkGoal>()
                .AddCondition<HasMoney>(Comparison.SmallerThan, 1);
            builder.AddGoal<SleepGoal>()
                .AddCondition<IsTired>(Comparison.GreaterThan, 1);

            // Actions
            builder.AddAction<WanderAction>()
                .SetTarget<WanderTarget>()
                .AddEffect<IsWandering>(true);

            builder.AddAction<EatAction>()
                .SetTarget<KitchenTarget>()
                .AddEffect<IsHungry>(true);

            builder.AddAction<BuyGroceriesAction>()
                .SetTarget<GroceryStoreTarget>()
                .AddCondition<HasMoney>(Comparison.GreaterThan, 0)
                .AddEffect<HasFood>(false);

            builder.AddAction<WorkAction>()
                .SetTarget<WorkplaceTarget>()
                .AddEffect<HasMoney>(true)
                .AddEffect<IsTired>(true);

            builder.AddAction<SleepAction>()
                .SetTarget<BedTarget>()
                .AddEffect<IsTired>(true);

            //World Sensors
            builder.AddWorldSensor<IsHungrySensor>()
                .SetKey<IsHungry>();
            builder.AddWorldSensor<HasMoneySensor>()
                .SetKey<HasMoney>();
            builder.AddWorldSensor<IsTiredSensor>()
                .SetKey<IsTired>();
            builder.AddWorldSensor<HasFoodSensor>()
                .SetKey<HasFood>();

            // Target Sensors
            builder.AddTargetSensor<WanderTargetSensor>()
                .SetTarget<WanderTarget>();

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

