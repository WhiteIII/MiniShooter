using UnityEngine;

namespace _Project
{
    public class HoleView : MonoBehaviour
    {
        [SerializeField] private float _timeToDestroy;

        private void Start()
        {
            transform.position += transform.forward * 0.01f;
        }

        private void Update()
        {
            _timeToDestroy -= Time.deltaTime;

            if (_timeToDestroy <= 0)
                Destroy(gameObject);
        }
    }
}
