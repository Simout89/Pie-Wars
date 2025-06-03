using UnityEngine;
using Zenject;

namespace _Script.Zenject
{
    public class SceneLoaderInstaller: MonoInstaller
    {
        [SerializeField] private SceneLoaderManager _sceneLoaderManager;
        public override void InstallBindings()
        {
            SceneLoaderManager sceneLoaderManager = Container.InstantiatePrefabForComponent<SceneLoaderManager>(_sceneLoaderManager);
            Container.Bind<SceneLoaderManager>().FromInstance(sceneLoaderManager).AsSingle().NonLazy();
        }
    }
}