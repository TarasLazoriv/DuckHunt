using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class HuntingStateMachineInstaller : MonoInstaller
    {
        [SerializeField] private DogAnimatorContainer m_dogAnimatorContainer = default;
        [SerializeField] private PerfectObjectContainer m_perfectObjectContainer = default;
        [SerializeField] private GameOverMonoCommand m_gameOverMonoCommand = default;
        public override void InstallBindings()
        {

            Container
                .Bind<IDogAnimatorContainer>()
                .FromInstance(m_dogAnimatorContainer)
                .AsSingle();

            Container
                .Bind<IFirstRoundIntroCommand>()
                .To<FirstRoundIntroCommand>()
                .AsSingle();

            Container
                .Bind<INewRoundCommand>()
                .To<NewRoundCommand>()
                .AsSingle();

            Container
                .Bind<IHuntingCommand>()
                .To<HuntingCommand>()
                .AsSingle();

            Container
                .Bind<IHuntingResultCommand>()
                .To<HuntingResultCommand>()
                .AsSingle();

            Container
                .Bind<IRoundResultCommand>()
                .To<RoundResultCommand>()
                .AsSingle();

            Container
                .Bind<IPerfectValueContainer>()
                .FromInstance(m_perfectObjectContainer)
                .AsSingle();

            Container
                .Bind(typeof(IRoundGoalObservable), typeof(IRoundGoalValue))
                .To<RoundGoalValue>()
                .AsSingle();

            Container
                .Bind<HuntingStateExecutor>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<HuntingResultExecutor>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind(typeof(IHuntingStateValue), typeof(IHuntingStateObservable))
                .To<HuntingStateValue>()
                .AsSingle();


            Container
                .Bind<IWinRoundCommand>()
                .To<WinRoundCommand>()
                .AsSingle();

            Container
                .Bind<IWinRoundExecutor>()
                .To<WinRoundExecutor>()
                .AsSingle();

            Container
                .Bind<ILooseRoundCommand>()
                .FromInstance(m_gameOverMonoCommand)
                .AsSingle();

            Container
                .Bind<ILooseRoundExecutor>()
                .To<LooseRoundExecutor>()
                .AsSingle();

            Container
                .Bind<IRoundResultAnimationCommand>()
                .To<RoundResultAnimationCommand>()
                .AsSingle();

            Container
                .Bind<IRoundResultAnimationExecutor>()
                .To<RoundResultAnimationExecutor>()
                .AsSingle();

        }
    }
}
