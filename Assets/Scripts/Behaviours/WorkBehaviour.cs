using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class WorkBehaviour : MonoBehaviour
    {
        public float money = 0;

        public int isWorking;

        private void Awake()
        {
            // NPC starts without money.
            money = 0;
        }

        public void Work()
        {
            // Increase the money as the NPC works. The exact value should be balanced according to your game design.
            money += 10;
        }
    }
}
