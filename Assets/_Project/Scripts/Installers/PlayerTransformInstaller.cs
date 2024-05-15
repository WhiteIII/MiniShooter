using UnityEngine;
using Zenject;

namespace _Project
{
    public class PlayerTransformInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerTransform;

        public override void InstallBindings()
        {
            Container.Bind<Transform>().FromInstance(_playerTransform).AsSingle();
        }
    }
}