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

        private KitchenSource[] kitchens;

        private void Awake()
        {
            agent = GetComponent<AgentBehaviour>();

            hunger = GetComponent<HungerBehaviour>();
            tiredness = GetComponent<TirednessBehaviour>();
            work = GetComponent<WorkBehaviour>();
            money = GetComponent<MoneyBehaviour>();

            kitchens = GameObject.FindObjectsOfType<KitchenSource>();
        }

        private void OnEnable()
        {
            agent.Events.OnActionStop += OnActionStop;
        }

        private void OnDisable()
        {
            agent.Events.OnActionStop -= OnActionStop;
        }

        private void FixedUpdate()
        {
            UpdateNeeds();
        }

        private void UpdateNeeds()
        {
            // Determine new goal based on current needs
            DetermineGoal();
        }

        private void DetermineGoal()
        {
            if (hunger.Hunger > 80)
            {
                if (kitchens[0].food > 0)
                {
                    agent.SetGoal<EatGoal>(false);
                }
                else if (money.money >= 50)
                {
                    agent.SetGoal<GroceryGoal>(false);
                }
                else
                {
                    agent.SetGoal<WorkGoal>(false);
                }
            }
            else if (tiredness.tiredness > 80)
            {
                agent.SetGoal<SleepGoal>(false);
            }
            else
            {
                agent.SetGoal<WanderGoal>(false);
            }
        }

        private void OnActionStop(IActionBase action)
        {
            // When an action stops, reevaluate needs
            UpdateNeeds();

            // If the current goal is related to eating or sleeping
            if (agent.CurrentGoal is EatGoal || agent.CurrentGoal is SleepGoal)
                return;

            // Re-determine goals
            DetermineGoal();
        }
    }
}
