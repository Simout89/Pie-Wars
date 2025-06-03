using _Script.SelectedEntitys;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // КРИТИЧНО для добычи ресурсов
        Container.Bind<ResourceManager>().FromComponentInHierarchy().AsSingle();
        
        // КРИТИЧНО для работы команд юнитов
        Container.Bind<EntitysController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<SelectedEntitysModel>().FromComponentInHierarchy().AsSingle();
        
        // КРИТИЧНО для обработки кликов
        Container.Bind<MapClickHendler>().FromComponentInHierarchy().AsSingle();
    }
}