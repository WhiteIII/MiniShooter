using UnityEngine;

namespace _Project
{
    public class PlayersInventory : MonoBehaviour
    {
        [SerializeField] private PickUpSystem _pickUpSystem;
        [System.NonSerialized] public GameObject Object;

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