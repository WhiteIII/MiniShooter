using UnityEngine;
using Zenject;

namespace _Project
{
    public class PlayersInventoryInstaller : MonoInstaller
    {
        [SerializeField] private PlayersInventory _playersInventory;

        public override void InstallBindings()
        {
            Container.Bind<PlayersInventory>().FromInstance(_playersInventory).AsSingle();
        }
    }
}