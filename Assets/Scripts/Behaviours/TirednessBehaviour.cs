using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class TirednessBehaviour : MonoBehaviour
    {
        public float tiredness = 0;

        private void Awake()
        {
            // NPC starts without being tired.
            tiredness = 0;
        }

        private void FixedUpdate()
        {
            // Increase the tiredness over time. The exact value should be balanced according to your game design.
            tiredness += Time.fixedDeltaTime * 0.5f;
        }

        public void Sleep()
        {
            // Decrease the tiredness when the NPC sleeps. The exact value should be balanced according to your game design.
            tiredness -= 20;
        }
    }
}
