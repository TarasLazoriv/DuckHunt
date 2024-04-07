using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class DuckInstaller : MonoInstaller
    {
        [SerializeField] private DuckTransformContainer m_duckTransform = default;
        [SerializeField] private DuckAnimatorContainer m_duckAnimator = default;
        [SerializeField] private DuckColliderContainer m_duckCollider = default;


        [SerializeField] private DuckPointsEarnedPrefabContainer m_duckPointsEarnedPrefab = default;
        [SerializeField] private DuckFlyAwayPrefabContainer m_duckFlyAwayPrefab = default;
        public override void InstallBindings()
        {
            Container
                .Bind<IDuckPointsEarnedPrefabContainer>()
                .FromInstance(m_duckPointsEarnedPrefab)
                .AsSingle();

            Container
                .Bind<IDuckFlyAwayPrefabContainer>()
                .FromInstance(m_duckFlyAwayPrefab)
                .AsSingle();

            Container
                .Bind<IDuckTransformContainer>()
                .FromInstance(m_duckTransform)
                .AsSingle();

            Container
                .Bind<IDuckColliderContainer>()
                .FromInstance(m_duckCollider)
                .AsSingle();

            Container
                .Bind<IDuckAnimatorContainer>()
                .FromInstance(m_duckAnimator)
                .AsSingle();

            Container
                .Bind<IDuckCommand>()
                .To<DuckCommand>()
                .AsSingle();

            Container
                .Bind<DuckExecutor>()
                .AsSingle();

            Container
                .Bind<IDuckMoveStoppable>()
                .To<DuckExecutor>()
                .FromResolve();

            Container
                .Bind<IDuckDirectionCommand>()
                .To<DuckDirectionCommand>()
                .AsSingle();

            Container
                .Bind(typeof(IDuckDirectionValue), typeof(IDuckDirectionObservable))
                .To<DuckDirectionValue>()
                .AsSingle();

            Container
                .Bind<IDuckAnimationCommand>()
                .To<DuckAnimationCommand>()
                .AsSingle();

            Container
                .Bind<IDuckSpeedValue>()
                .To<DuckSpeedContainer>()
                .AsSingle();

            Container
                .Bind<IDuckAnimationSpeedValue>()
                .To<DuckAnimationSpeedContainer>()
                .AsSingle();

            Container
                .Bind<IDuckShotDownCommand>()
                .To<DuckShotDownCommand>()
                .AsSingle();

            Container
                .Bind<IDuckFallCommand>()
                .To<DuckFallCommand>()
                .AsSingle();

            Container
                .Bind<DuckFallExecutor>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<DuckAnimationExecutor>()
                .AsSingle()
                .NonLazy();

        }

        private sealed class DuckAnimationSpeedContainer : RoundDependentValueProvider, IDuckAnimationSpeedValue
        {
            protected override float DefaultVal => 0.75f;
            protected override float DependPower => 0.1f;
            public DuckAnimationSpeedContainer(IRoundValue roundValue) : base(roundValue) { }
        }

        private sealed class DuckSpeedContainer : RoundDependentValueProvider, IDuckSpeedValue
        {
            protected override float DefaultVal => 3f;
            protected override float DependPower => 0.4f;
            public DuckSpeedContainer(IRoundValue roundValue) : base(roundValue) { }
        }
    }
}
