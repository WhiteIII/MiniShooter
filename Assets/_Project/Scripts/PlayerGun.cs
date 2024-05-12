using System;
using UnityEngine;

namespace _Project
{
    public class PlayerGun : Gun
    {
        [SerializeField] private float _attackSpeed;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _holePrefab;

        private float _nextTimeToFire;
        
        public override event Action Shooting;
        
        private void Awake()
        {
            gameObject.GetComponent<PlayerGun>().enabled = false;
        }

        private void Update()
        {
            if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
            {
                _nextTimeToFire = Time.time + 1f / _attackSpeed;

                Shoot();
                
                Shooting?.Invoke();
            }
        }

        private void Shoot()
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _distance, _layerMask))
            {
                var target = hit.transform.GetComponent<Health>();

                if (target != null)
                {
                    target.TakeDamage(_damage);
                }
                else
                {
                    var hole = Instantiate(_holePrefab, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }
    }
}
