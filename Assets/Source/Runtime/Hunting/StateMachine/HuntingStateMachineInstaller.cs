using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class HuntingStateMachineInstaller : MonoInstaller
    {
        [SerializeField] private DogAnimatorContainer m_dogAnimatorContainer = default;
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

        }
    }
}
