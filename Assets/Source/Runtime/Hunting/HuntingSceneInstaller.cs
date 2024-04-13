using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class HuntingSceneInstaller : MonoInstaller
    {
        [SerializeField] private HuntingShotSoundMonoCommand m_shotViewMonoCommand = default;
        [SerializeField] private PlayScoreSoundMonoCommand m_playScoreViewMonoCommand = default;
        [SerializeField] private RoundWinSoundMonoCommand m_winSoundMonoCommand = default;
        [SerializeField] private ScoreMonoCommand m_scoreMonoCommand = default;

        public override void InstallBindings()
        {
            Container
                .Bind<IHuntingShotSoundCommand>()
                .FromInstance(m_shotViewMonoCommand)
                .AsSingle();

            Container
                .Bind<IPlayScoreSoundCommand>()
                .FromInstance(m_playScoreViewMonoCommand)
                .AsSingle();

            Container
                .Bind<IRoundWinSoundCommand>()
                .FromInstance(m_winSoundMonoCommand)
                .AsSingle();

            ICoroutine coroutine = gameObject.AddComponent<CoroutineObject>();

            Container
                .Bind<ICoroutine>()
                .FromInstance(coroutine)
                .AsSingle();

            Container
                .Bind<ICoroutineCommandRunner>()
                .To<CoroutineCommandRunner>()
                .AsTransient();

            Container
                .Bind<ICommandRunner>()
                .To<CommandRunner>()
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



            Container
                .Bind<IScoreCommand>()
                .FromInstance(m_scoreMonoCommand)
                .AsSingle();
            
            Container
                .Bind<ScoreExecutor>()
                .To<ScoreExecutor>()
                .AsSingle()
                .NonLazy();
            
        }

        private sealed class RoundContainer : ValueContainer<uint>, IRoundValue { }
    }
}
