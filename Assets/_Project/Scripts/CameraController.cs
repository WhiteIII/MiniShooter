using UnityEngine;

namespace _Project
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivity;
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _body;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

            _camera.Rotate(Vector3.right * -mouseY);
            _body.Rotate(Vector3.up * mouseX);
        }
    }
}