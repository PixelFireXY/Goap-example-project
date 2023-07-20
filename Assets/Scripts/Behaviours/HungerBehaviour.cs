using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class HungerBehaviour : MonoBehaviour
    {
        public float Hunger = 0;

        private void Awake()
        {
            // NPC starts not being hungry.
            Hunger = 0;
        }

        private void FixedUpdate()
        {
            Hunger += Time.fixedDeltaTime * 1f;
        }
    }
}