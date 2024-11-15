using Zenject;

namespace _Script.Zenject
{
    public class SoundGameInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SoundManager>().AsSingle().NonLazy(); 
        }
    }
}