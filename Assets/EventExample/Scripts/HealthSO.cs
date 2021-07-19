using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventExample
{
    
    [CreateAssetMenu(menuName = "HealthSO")]
    //This class is a scriptableObject so that it can be referenced via the inspector by any component.
    //This is a simple way of providing globally accessible values in Unity.
    public class HealthSO : ScriptableObject
    {
        //Invoked whenever health changes. Any script can listen for this event. See HealthBar for an example.
        //Action<int> is a simple delegate that takes an int argument and returns nothing.
        //For events that you want to assign listeners to via the inspector, use UnityEvent
        public event Action<int> OnHealthChanged;
        
        [SerializeField] private int health;
        public int Health
        {
            get => health;
            set
            {
                health = Mathf.Clamp(value, 0, MaxHealth);
                //Whenever this value changes, an event with the new health value is sent out.
                OnHealthChanged?.Invoke(health);
            }
        }

        private void OnValidate()
        {
            Health = health;
        }

        //This value can be set in the inspector
        [SerializeField] private int maxHealth;
        public int MaxHealth => maxHealth;
    }
}