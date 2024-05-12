using System;
using UnityEngine;

namespace _Project
{
    public class Health : MonoBehaviour
    {
        [field:SerializeField] public int HealthValue {  get; private set; }
        public int MaxHealth { get; private set; }

        public event Action HealthHasChanged;
        public event Action Death;

        private void Awake()
        {
            MaxHealth = HealthValue;
        }

        public void TakeDamage(int damage)
        {
            if (HealthValue - damage <= 0)
            {
                HealthValue = 0;
                Death?.Invoke();
                Destroy(gameObject);
            }
            else
            {
                HealthValue -= damage;
            }
            HealthHasChanged?.Invoke();
        }
    }
}