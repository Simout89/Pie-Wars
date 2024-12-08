using _Script.Mediator;
using Zenject;

namespace _Script.Zenject
{
    public class SoundGameInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SoundMediator>().AsSingle().NonLazy(); 
        }
    }
}