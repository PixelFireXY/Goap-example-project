using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NpcDailyRoutines
{
    public class MoneyBehaviour : MonoBehaviour
    {
        public float money = 0;

        [SerializeField] private float startMoney = 0;

        private void Awake()
        {
            // NPC start money.
            money = startMoney;
        }

        public void EarnMoney(float amount)
        {
            // Increase the money when the NPC works.
            money += amount;
        }

        public void SpendMoney(float amount)
        {
            // Decrease the money when the NPC buys something.
            money -= amount;
        }
    }
}
