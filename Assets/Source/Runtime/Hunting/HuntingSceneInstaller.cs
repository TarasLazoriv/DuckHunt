using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class HuntingSceneInstaller : MonoInstaller
    {
        private sealed class DuckCount : ValueContainer<uint>, IDuckCountValue
        {
            public DuckCount() : base(2) { }
        } // ToDo Del

        [SerializeField] private HuntingShotSoundMonoCommand m_shotViewMonoCommand = default;
        [SerializeField] private PlayScoreSoundMonoCommand m_playScoreViewMonoCommand = default;

        public override void InstallBindings()
        {
            Container
                .Bind<IDuckCountValue>()
                .To<DuckCount>() // ToDo Del
                .AsSingle();


            Container
                .Bind<IHuntingShotSoundCommand>()
                .FromInstance(m_shotViewMonoCommand)
                .AsSingle();

            Container
                .Bind<IPlayScoreSoundCommand>()
                .FromInstance(m_playScoreViewMonoCommand)
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
                .BindInterfacesTo<RoundDuckHuntingResult>()
                .AsSingle();

            Container
                .Bind<ICaughtDucksValue>()
                .To<CaughtDucksValue>()
                .AsSingle();

        }
        private sealed class RoundContainer : ValueContainer<uint>, IRoundValue { }
    }
}
