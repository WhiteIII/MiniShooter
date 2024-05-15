using UnityEngine;
using Zenject;

namespace _Project
{
    public class PickUpSystemInstaller : MonoInstaller
    {
        [SerializeField] private PickUpSystem _pickUpSystem;
        
        public override void InstallBindings()
        {
            Container.Bind<PickUpSystem>().FromInstance(_pickUpSystem).AsSingle();
        }
    }
}