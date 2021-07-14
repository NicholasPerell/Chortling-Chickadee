using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventExample
{
    public class HealthTest : MonoBehaviour
    {
        [SerializeField] private HealthSO healthRef;
        
        public void Hurt()
        {
            healthRef.Health -= 10;
        }

        public void Heal()
        {
            healthRef.Health += 10;
        }
    }
}