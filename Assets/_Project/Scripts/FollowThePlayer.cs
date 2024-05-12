using UnityEngine;

namespace _Project
{
    [RequireComponent(typeof(CharacterController))]

    public class FollowThePlayer : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _speed;
        [SerializeField] private float _gravity;

        private Vector3 _velocity;

        private CharacterController _controller;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void FollowPlayer()
        {
            var direcation = (_player.position - transform.position).normalized;

            _controller.Move(direcation * _speed * Time.deltaTime);

            transform.LookAt(_player.position, Vector3.up);

            _velocity.y -= _gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }
    }
}