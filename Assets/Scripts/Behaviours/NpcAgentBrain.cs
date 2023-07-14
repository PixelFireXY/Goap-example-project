using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using Demos.Complex.Behaviours;
using Demos.Shared.Behaviours;
using Demos.Shared.Goals;
using Demos.Simple.Behaviours;
using NpcDailyRoutines;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class NpcAgentBrain : MonoBehaviour
    {
        private AgentBehaviour agent;
        private HungerBehaviour hunger;
        private TirednessBehaviour tiredness;
        private WorkBehaviour work;
        private MoneyBehaviour money;

        private ItemCollection itemCollection;
        private ComplexInventoryBehaviour inventory;

        private void Awake()
        {
            this.agent = this.GetComponent<AgentBehaviour>();
            this.hunger = this.GetComponent<HungerBehaviour>();
            this.tiredness = this.GetComponent<TirednessBehaviour>();
            this.work = this.GetComponent<WorkBehaviour>();
            this.money = this.GetComponent<MoneyBehaviour>();

            this.inventory = this.GetComponent<ComplexInventoryBehaviour>();
            this.itemCollection = FindObjectOfType<ItemCollection>();
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
            // NPC gets hungry and tired over time
            this.hunger.hunger = Mathf.Min(this.hunger.hunger + Time.fixedDeltaTime, 100f);
            this.tiredness.tiredness = Mathf.Min(this.tiredness.tiredness + Time.fixedDeltaTime, 100f);

            if (this.hunger.hunger > 80)
            {
                // If NPC is hungry, and has money, it buys and eats food
                if (this.money.money > 0)
                {
                    this.money.SpendMoney(1);
                    this.hunger.hunger = Mathf.Max(this.hunger.hunger - 20f, 0f);
                }
                // If no money, NPC needs to go to work
                else
                {
                    this.work.Work();
                    this.money.EarnMoney(1);
                }
            }

            if (this.tiredness.tiredness > 80)
            {
                // If NPC is tired, it needs to sleep
                this.tiredness.Sleep();
            }
        }

        private void OnActionStop(IActionBase action)
        {
            this.UpdateNeeds();

            // If the current goal is not related to fixing hunger or tiredness
            if (this.agent.CurrentGoal is EatGoal || this.agent.CurrentGoal is SleepGoal)
                return;

            this.DetermineGoal();
        }

        private void DetermineGoal()
        {
            // Depending on agent type, determine the goal (to be implemented)
            // ...
        }
    }
}
