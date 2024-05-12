using UnityEngine;
using System;

namespace _Project
{
    public class ExitFromAttackingZone : MonoBehaviour
    {
        public event Action OnExit;

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                OnExit?.Invoke();
            }
        }
    }
}