using UnityEngine;
using Zenject;

namespace _Project
{
    [RequireComponent(typeof(CharacterController))]

    public class FollowThePlayer : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _gravity;

        [Inject] private Player _player;

        private Vector3 _velocity;

        private CharacterController _controller;
        private Transform _playerTransform;

        private void Awake()
        {
            _playerTransform = _player.transform;
            
            _controller = GetComponent<CharacterController>();
        }

        public void FollowPlayer()
        {
            var direcation = (_playerTransform.position - transform.position).normalized;

            _controller.Move(direcation * _speed * Time.deltaTime);

            transform.LookAt(_playerTransform.position, Vector3.up);

            _velocity.y -= _gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }
    }
}