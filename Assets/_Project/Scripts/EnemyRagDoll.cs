using UnityEngine;

namespace _Project
{
    public class EnemyRagDoll : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private GameObject _ragDollPrefab;
        [SerializeField] private float _lifeTime;

        private void Awake()
        {
            _health.Death += SpawnRagDoll;
        }

        private void OnDestroy()
        {
            _health.Death -= SpawnRagDoll;
        }

        private void SpawnRagDoll()
        {
            _ragDollPrefab = Instantiate(_ragDollPrefab);
            _ragDollPrefab.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }
    }
}