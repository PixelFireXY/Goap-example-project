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
            builder.AddGoal<WanderGoal>()                                                   // A goal represents something that the agent desires to achieve. It contains one or more conditions that need to be met in order to achieve the goal.
                .AddCondition<IsWandering>(Comparison.GreaterThanOrEqual, 1);               // A condition is a specific state of the world that must be true for the goal to be considered achieved. The conditions are usually expressed in terms of world states.
            
            builder.AddGoal<EatGoal>()
                .AddCondition<IsHungry>(Comparison.GreaterThanOrEqual, 0);
            
            builder.AddGoal<SleepGoal>()
                .AddCondition<IsTired>(Comparison.GreaterThanOrEqual, 0);
            
            builder.AddGoal<GroceryGoal>()
                .AddCondition<HasFood>(Comparison.SmallerThan, 1);
            
            builder.AddGoal<WorkGoal>()
                .AddCondition<IsAtWork>(Comparison.SmallerThan, 1);

            // Actions
            builder.AddAction<WanderAction>()                                               // An action is something that the agent can do to change the state of the world. It contains preconditions (which must be met for the action to be performed) and effects (which describe how the action changes the world state).
                .SetTarget<WanderTarget>()                                                  // The target is typically a specific location or object that the action involves. For example, if the action is "go to the kitchen", the target might be the kitchen's location.
                .AddEffect<IsWandering>(true);                                              // An effect describes how the action changes the state of the world. For example, the effect of the action "eat food" might be to decrease the agent's hunger level.

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
            //builder.AddWorldSensor<IsTiredSensor>()                                       // Sensors allow the agent to perceive the state of the world, which is necessary for it to make decisions and plan its actions.
            //    .SetKey<IsTired>();
            //builder.AddWorldSensor<IsHungrySensor>()
            //    .SetKey<IsHungry>();
            //builder.AddWorldSensor<HasFoodSensor>()
            //    .SetKey<HasFood>();
            //builder.AddWorldSensor<IsAtWorkSensor>()
            //    .SetKey<IsAtWork>();

            // Target Sensors
            builder.AddTargetSensor<WanderTargetSensor>()                                   // A target sensor helps determine the position for a given TargetKey. The TargetState is used by the Planner to determine distance between Actions and the position an Agent should move to before performing the action.
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

