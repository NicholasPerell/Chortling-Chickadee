using System;
using UnityEngine;
using UnityEngine.UI;

namespace EventExample
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthSO healthRef;
        [SerializeField] private Image fillImage;
        
        private void OnEnable()
        {
            //Listen for when the health changes
            healthRef.OnHealthChanged += OnHealthChanged;
            //Invoke callback manually to immediately update
            OnHealthChanged(healthRef.Health);
        }

        private void OnDisable()
        {
            //Don't forget to remove listeners!
            healthRef.OnHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int arg0)
        {
            fillImage.fillAmount = arg0 / (float)healthRef.MaxHealth;
        }
    }
}