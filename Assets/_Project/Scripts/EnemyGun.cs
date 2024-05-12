using System;
using UnityEngine;

namespace _Project
{
    public class EnemyGun : Gun
    {
        [SerializeField] private Transform _enemyTransform;

        public override event Action Shooting;

        public void Shoot()
        {
            Shooting?.Invoke();

            if (Physics.Raycast(_enemyTransform.position, _enemyTransform.right, out RaycastHit hit, _distance, _layerMask))
            {
                var target = hit.transform.GetComponent<Health>();

                if (target != null)
                {
                    target.TakeDamage(_damage);
                }
            }
        }
    }
}