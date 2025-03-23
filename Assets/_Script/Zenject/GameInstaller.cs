using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ResourcesLoad>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}