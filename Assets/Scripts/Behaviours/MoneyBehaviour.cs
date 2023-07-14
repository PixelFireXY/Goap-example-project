using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class MoneyBehaviour : MonoBehaviour
    {
        public float money = 0;

        private void Awake()
        {
            // NPC starts without money.
            this.money = 0;
        }

        public void EarnMoney(float amount)
        {
            // Increase the money when the NPC works.
            this.money += amount;
        }

        public void SpendMoney(float amount)
        {
            // Decrease the money when the NPC buys something.
            this.money -= amount;
        }
    }
}
