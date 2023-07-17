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
                .AddCondition<IsHungry>(Comparison.GreaterThanOrEqual, 0); // IsHungry == true

            builder.AddGoal<SleepGoal>()
                .AddCondition<IsTired>(Comparison.GreaterThanOrEqual, 0); // IsTired == true
            
            builder.AddGoal<GroceryGoal>()
                .AddCondition<HasFood>(Comparison.SmallerThan, 1); // HasFood == false
            builder.AddGoal<WorkGoal>()
                .AddCondition<IsAtWork>(Comparison.SmallerThan, 1); // IsAtWork == false

            // Actions
            builder.AddAction<WanderAction>()       // L'azione che sta venendo fatta
                .SetTarget<WanderTarget>()          // Viene eseguito il target sensor
                .AddEffect<IsWandering>(true);      // Viene settato wandergoal

            builder.AddAction<EatAction>()
                .SetTarget<FoodTarget>()
                .AddEffect<IsHungry>(true);

            builder.AddAction<SleepAction>()
                .SetTarget<BedTarget>()
                .AddEffect<IsTired>(true);
            builder.AddAction<BuyGroceriesAction>()
                .SetTarget<GroceryTarget>()
                .AddEffect<HasFood>(false);
            builder.AddAction<WorkAction>()
                .SetTarget<WorkTarget>()
                .AddEffect<IsAtWork>(false);

            // World Sensors
            //builder.AddWorldSensor<IsTiredSensor>()
            //    .SetKey<IsTired>();
            //builder.AddWorldSensor<IsHungrySensor>()
            //    .SetKey<IsHungry>();
            //builder.AddWorldSensor<HasFoodSensor>()
            //    .SetKey<HasFood>();
            //builder.AddWorldSensor<IsAtWorkSensor>()
            //    .SetKey<IsAtWork>();

            // Target Sensors
            builder.AddTargetSensor<WanderTargetSensor>()
                .SetTarget<WanderTarget>();

            builder.AddTargetSensor<KitchenTargetSensor>()
                .SetTarget<FoodTarget>();

            builder.AddTargetSensor<BedTargetSensor>()
                .SetTarget<BedTarget>();
            
            builder.AddTargetSensor<GroceryStoreTargetSensor>()
                .SetTarget<GroceryTarget>();
            builder.AddTargetSensor<WorkplaceTargetSensor>()
                .SetTarget<WorkTarget>();

            return builder.Build();
        }
    }
}

