using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class HungerBehaviour : MonoBehaviour
    {
        public float hunger = 0;

        private void Awake()
        {
            // NPC starts not being hungry.
            this.hunger = 0;
        }

        private void FixedUpdate()
        {
            // Increase the hunger over time. The exact value should be balanced according to your game design.
            this.hunger += Time.fixedDeltaTime * 1f;
        }
    }
}