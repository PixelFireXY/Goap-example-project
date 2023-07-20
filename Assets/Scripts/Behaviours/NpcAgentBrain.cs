using UnityEngine;
using NpcDailyRoutines;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using Demos.Shared.Goals;

namespace NpcDailyRoutines
{
    public class NpcAgentBrain : MonoBehaviour
    {
        private AgentBehaviour agent;
        private HungerBehaviour hunger;
        private TirednessBehaviour tiredness;
        private WorkBehaviour work;
        private MoneyBehaviour money;

        private void Awake()
        {
            this.agent = this.GetComponent<AgentBehaviour>();

            this.hunger = this.GetComponent<HungerBehaviour>();
            this.tiredness = this.GetComponent<TirednessBehaviour>();
            this.work = this.GetComponent<WorkBehaviour>();
            this.money = this.GetComponent<MoneyBehaviour>();
        }

        private void OnEnable()
        {
            this.agent.Events.OnActionStop += this.OnActionStop;
        }

        private void OnDisable()
        {
            this.agent.Events.OnActionStop -= this.OnActionStop;
        }

        private void FixedUpdate()
        {
            this.UpdateNeeds();
        }

        private void UpdateNeeds()
        {
            // Determine new goal based on current needs
            this.DetermineGoal();
        }

        private void DetermineGoal()
        {
            if (this.hunger.Hunger > 80)
            {
                // If NPC is hungry and has money, it sets the goal to eat
                if (this.money.money > 0)
                {
                    this.agent.SetGoal<EatGoal>(false);
                }
                // If no money, NPC sets the goal to go to work
                else
                {
                    this.agent.SetGoal<WorkGoal>(false);
                }
            }
            else if (this.tiredness.tiredness > 80)
            {
                // If NPC is tired, it sets the goal to sleep
                this.agent.SetGoal<SleepGoal>(false);
            }
            else
            {
                // If no urgent needs, NPC can wander around
                this.agent.SetGoal<WanderGoal>(false);
            }
        }

        private void OnActionStop(IActionBase action)
        {
            // When an action stops, reevaluate needs
            this.UpdateNeeds();

            // If the current goal is related to eating or sleeping
            if (this.agent.CurrentGoal is EatGoal || this.agent.CurrentGoal is SleepGoal)
                return;

            // Re-determine goals
            this.DetermineGoal();
        }
    }
}
