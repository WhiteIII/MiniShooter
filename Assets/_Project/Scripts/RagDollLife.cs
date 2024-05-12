using UnityEngine;

namespace _Project
{
    public class RagDollLife : MonoBehaviour
    {
        [SerializeField] private float _timeToDestroy;

        private void Update()
        {
            _timeToDestroy -= Time.deltaTime;

            if (_timeToDestroy <= 0)
                Destroy(gameObject);
        }
    }
}