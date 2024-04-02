using LazerLabs.Commands;
using Zenject;

namespace DuckHunt
{
    public sealed class ShootSceneInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            ICoroutine coroutine = gameObject.AddComponent<CoroutineObject>();

            Container
                .Bind<ICoroutine>()
                .To<ICoroutine>()
                .FromInstance(coroutine)
                .AsSingle();

            Container
                .Bind<CoroutineCommandRunner>()
                .To<CoroutineCommandRunner>()
                .AsTransient();

            Container
                .Bind<IGetGameFieldCommand>()
                .To<GetGameFieldCommand>()
                .AsSingle();


        }
    }
}
