using UnityEngine;
using Zenject;

namespace _Project
{
    public class PlayersInventory : MonoBehaviour
    {
        [System.NonSerialized] public GameObject Object;
        
        [Inject] private PickUpSystem _pickUpSystem;

        private void Awake()
        {
            _pickUpSystem.OnPickUp += ActiveObject;
            _pickUpSystem.ThrowItem += UnplugObject;
        }

        private void OnDestroy()
        {
            _pickUpSystem.OnPickUp -= ActiveObject;
            _pickUpSystem.ThrowItem -= UnplugObject;
        }

        private void ActiveObject()
        {
            Object.GetComponent<PlayerGun>().enabled = true;
        }

        private void UnplugObject()
        {
            Object.GetComponent<PlayerGun>().enabled = false;
            Object = null;
        }
    }
}