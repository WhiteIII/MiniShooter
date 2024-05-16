using UnityEngine;
using Zenject;

namespace _Project
{
    public class PlayerTransformInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;

        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle();
        }
    }
}