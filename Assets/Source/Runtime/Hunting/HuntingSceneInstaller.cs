using LazerLabs.Commands;
using Zenject;

namespace DuckHunt
{
    public sealed class HuntingSceneInstaller : MonoInstaller
    {
        private sealed class DuckCount : ValueContainer<uint>, IDuckCountValue
        {
            public DuckCount() : base(2) { }
        } // ToDo Del
        public override void InstallBindings()
        {
            Container
                .Bind<IDuckCountValue>()
                .To<DuckCount>() // ToDo Del
                .AsSingle();


            ICoroutine coroutine = gameObject.AddComponent<CoroutineObject>();

            Container
                .Bind<ICoroutine>()
                .FromInstance(coroutine)
                .AsSingle();

            Container
                .Bind<CoroutineCommandRunner>()
                .AsTransient();

            Container
                .Bind<CommandRunner>()
                .AsTransient();

            Container
                .Bind<IGetGameFieldCommand>()
                .To<GetGameFieldCommand>()
                .AsSingle();

            Container
                .Bind<IGetRandomSpawnPointCommand>()
                .To<SpawnPointCommand>()
                .AsSingle();

            Container
                .Bind(typeof(IActiveDucksCountValue), typeof(IActiveDucksCountObservable))
                .To<ActiveDucksCountValue>()
                .AsSingle();


            Container
                .Bind<IRoundValue>()
                .To<RoundContainer>()
                .AsSingle();

            Container
                .Bind(typeof(IShotDuckValue), typeof(IShotDuckObservable))
                .To<ShotDuckValue>()
                .AsSingle();

            Container
                .Bind<ICaughtDucksValue>()
                .To<CaughtDucksValue>()
                .AsSingle();

        }
        private sealed class RoundContainer : ValueContainer<uint>, IRoundValue { }
    }
}
