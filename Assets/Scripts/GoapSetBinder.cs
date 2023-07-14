using CrashKonijn.Goap.Behaviours;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class GoapSetBinder : MonoBehaviour
    {
        [SerializeField] private GoapRunnerBehaviour goapRunnerBehaviour;
        [SerializeField] private AgentBehaviour agentBehaviour;

        [SerializeField] private string goapToSet = "GettingStartedSet";

        public void Awake()
        {
            agentBehaviour.GoapSet = goapRunnerBehaviour.GetGoapSet(goapToSet);
        }
    }
}