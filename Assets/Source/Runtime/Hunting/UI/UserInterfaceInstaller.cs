using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class UserInterfaceInstaller : MonoInstaller
    {
        [SerializeField] private ShotViewMonoCommand m_shotViewMonoCommand = default;
        [SerializeField] private DucksResultMonoCommand m_ducksResult = default;
        [SerializeField] private RoundDuckGoalMonoCommand m_roundDuckGoalCommand = default;
        public override void InstallBindings()
        {
            Container
                .Bind<IShotViewCommand>()
                .FromInstance(m_shotViewMonoCommand)
                .AsSingle();

            Container
                .Bind<IDucksResultCommand>()
                .FromInstance(m_ducksResult)
                .AsSingle();

            Container
                .Bind<IRoundDuckGoalCommand>()
                .FromInstance(m_roundDuckGoalCommand)
                .AsSingle();

            Container
                .Bind<ShotViewExecutor>()
                .To<ShotViewExecutor>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<RoundDuckGoalExecutor>()
                .To<RoundDuckGoalExecutor>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<DucksResultExecutor>()
                .To<DucksResultExecutor>()
                .AsSingle()
                .NonLazy();


        }
    }
}
