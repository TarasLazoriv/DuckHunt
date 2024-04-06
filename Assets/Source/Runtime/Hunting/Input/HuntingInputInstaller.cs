using LazerLabs.Commands;
using Zenject;

namespace DuckHunt
{
    public sealed class HuntingInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {

            Container
                .Bind<IHuntingInputCommand>()
                .To<HuntingInputCommand>()
                .AsSingle();

            Container
                .Bind<HuntingInputExecutor>()
                .To<HuntingInputExecutor>()
                .AsSingle();



            Container
                .Bind(typeof(IShotAmmo), typeof(IShotAmmoObservable))
                .To<ShotAmmoValue>()
                .AsSingle();

        }
    }
}
