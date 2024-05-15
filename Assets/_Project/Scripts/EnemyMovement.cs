using System.Collections;
using UnityEngine;
using Zenject;

namespace _Project
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private FollowThePlayer _followThePlayer;
        [SerializeField] private AttackStartZone _attackStartZone;
        [SerializeField] private ExitFromAttackingZone _exitFromAttackingZone;
        [SerializeField] private EnemyGun _enemyGun;
        [SerializeField] private Animator _enemyAnimator;
        [SerializeField] private float _shootRate;
        [SerializeField] private float _rotationSpeed;
        
        [Inject] private Transform _player;

        private bool _isMoving;

        private void Awake()
        {
            _attackStartZone.OnEntered += StartAttack;
            _exitFromAttackingZone.OnExit += EnemyMove;
        }

        private void OnDestroy()
        {
            _attackStartZone.OnEntered -= StartAttack;
            _exitFromAttackingZone.OnExit -= EnemyMove;
        }

        private void StartAttack()
        {
            _isMoving = false;
            StartCoroutine(Shooting());
        }

        private void EnemyMove()
        {
            _isMoving = true;
        }

        private void Update()
        {
            if (_isMoving)
            {
                _enemyAnimator.SetTrigger("Run");
                
                _followThePlayer.FollowPlayer();
            }
            else
            {
                _enemyAnimator.SetTrigger("Idle");
                
                Vector3 direction = _player.position - transform.position;

                Quaternion rotation = Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _rotationSpeed);
            }
        }

        IEnumerator Shooting()
        {
            while (_isMoving == false)
            {
                yield return new WaitForSeconds(_shootRate);

                _enemyGun.Shoot();
            }
        }
    }
}