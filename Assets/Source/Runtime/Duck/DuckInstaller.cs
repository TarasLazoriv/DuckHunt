using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class DuckInstaller : MonoInstaller
    {
        [SerializeField] private TransformContainer m_duckTransform = default;

        public override void InstallBindings()
        {
            Container
                .Bind<IPathGeneratorCommand>()
                .To<PathGeneratorCommand>()
                .AsSingle();

            Container
                .Bind<ITransformContainer>()
                .FromInstance(m_duckTransform)
                .AsSingle();

            Container
                .Bind<IDuckCommand>()
                .To<DuckCommand>()
                .AsSingle();

            Container
                .Bind<DuckExecutor>()
                .To<DuckExecutor>()
                .AsSingle();


        }
    }
}
