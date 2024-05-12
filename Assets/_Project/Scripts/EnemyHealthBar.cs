using UnityEngine;

namespace _Project
{
    public class EnemyHealthBar : HealthBar
    {
        [SerializeField] private Transform _cameraTransform;

        void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - _cameraTransform.position);
        }
    }
}