using System;
using UnityEngine;

namespace _Project
{
    public class AttackStartZone : MonoBehaviour
    {
        public event Action OnEntered;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                OnEntered?.Invoke();
            }
        }
    }
}