using UnityEngine;
using UnityEngine.UI;

namespace _Project
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image _bar;

        private void Awake()
        {
            _health.HealthHasChanged += ChangeBar;
        }

        private void OnDestroy()
        {
            _health.HealthHasChanged += ChangeBar;
        }

        private void ChangeBar()
        {
            _bar.fillAmount = (float)_health.HealthValue / _health.MaxHealth;
        }
    }
}