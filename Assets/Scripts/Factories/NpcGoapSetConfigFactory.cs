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
                .AddCondition<IsWandering>(Comparison.SmallerThanOrEqual, 0);

            builder.AddGoal<EatGoal>()                                                  // The goal that must be satisfied
                .AddCondition<IsHungry>(Comparison.SmallerThan, 80);                    // The condition to satisfy the goal

            builder.AddGoal<GroceryGoal>()
                .AddCondition<HasFood>(Comparison.GreaterThanOrEqual, 1);

            builder.AddGoal<WorkGoal>()
                .AddCondition<HasMoney>(Comparison.GreaterThan, 0);

            builder.AddGoal<SleepGoal>()
                .AddCondition<IsTired>(Comparison.SmallerThan, 80);

            // Actions
            builder.AddAction<WanderAction>()
                .SetTarget<WanderTarget>()
                .AddEffect<IsWandering>(false);

            builder.AddAction<EatAction>()                                              // This is the action to satisfy the goal
                .SetTarget<KitchenTarget>()                                             // This is the target of the goal (the action will be execute after the min distance is reached)
                .AddEffect<IsHungry>(false);                                            // This is the value to set to the variable after the action is complete

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
            builder.AddWorldSensor<IsHungrySensor>()                                    // This is the Sensor that checks the variable inside the MonoBehaviour
                .SetKey<IsHungry>();                                                    // This is the variable set to true or false by the sensor
            builder.AddWorldSensor<HasFoodSensor>()
                .SetKey<HasFood>();
            builder.AddWorldSensor<HasMoneySensor>()
                .SetKey<HasMoney>();
            builder.AddWorldSensor<IsTiredSensor>()
                .SetKey<IsTired>();
            
            // Target Sensors
            builder.AddTargetSensor<WanderTargetSensor>()
                .SetTarget<WanderTarget>();
            builder.AddTargetSensor<KitchenTargetSensor>()                              // This is the Target Sensor to check the Source in the enviroment
                .SetTarget<KitchenTarget>();                                            // This is the set of the target setted by the Target Sensor
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

