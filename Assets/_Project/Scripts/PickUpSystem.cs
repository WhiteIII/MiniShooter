using System;
using System.Collections;
using UnityEngine;

namespace _Project
{
    public class PickUpSystem : MonoBehaviour
    {
        [SerializeField] private Transform _pickUp;
        [SerializeField] private PlayersInventory _inventory;

        private Rigidbody _gunRigidbody;
        public event Action OnPickUp;
        public event Action ThrowItem;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerGun>(out PlayerGun gun) && _pickUp.childCount == 0)
            {
                _inventory.Object = other.gameObject;
                _gunRigidbody = gun.GetComponent<Rigidbody>();
                _gunRigidbody.isKinematic = true;

                FixedTransform(gun.transform);

                gameObject.GetComponent<Collider>().isTrigger = false;
                
                OnPickUp?.Invoke();
            }
        }
        private void Update()
        {
            if (_pickUp.childCount == 0)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _pickUp.DetachChildren();
                _gunRigidbody.isKinematic = false;
                StartCoroutine(Waiter());
                
                ThrowItem?.Invoke();
            }
        }

        private void FixedTransform(Transform gunTransform)
        {
            gunTransform.SetParent(_pickUp);
            gunTransform.position = _pickUp.position;
            gunTransform.rotation = _pickUp.rotation;
        }

        private IEnumerator Waiter()
        {
            yield return new WaitForSeconds(1.5f);

            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }
}
