using UnityEngine;
using Zenject;

namespace DuckHunt
{
    /// <summary>
    /// Factory. All dependencies for creating ducks are here.
    /// </summary>
    public sealed class DuckFactoryInstaller : MonoInstaller
    {
        [SerializeField] private DuckMonoExecutor m_duckPrefab = default;
        [SerializeField] private DucksContainer m_ducksContainer = default;
        [SerializeField] private CanvasValueContainer m_canvasValueContainer = default;
        public override void InstallBindings()
        {

            Container
                .BindFactory<DuckMonoExecutor, DuckMonoExecutor.Factory>()
                .FromComponentInNewPrefab(m_duckPrefab)
                .AsSingle();

            //MonoValueContainer allows for standardized access to read-only values without tight coupling to specific MonoBehaviours or other components.
            Container
                .Bind<ICanvasValueContainer>()
                .FromInstance(m_canvasValueContainer)
                .AsSingle();

            Container
                .Bind<IPathGeneratorCommand>()
                .To<PathGeneratorCommand>()
                .AsSingle();

            Container
                .Bind<IDucksContainer>()
                .FromInstance(m_ducksContainer)
                .AsSingle();


            Container
                .Bind<IDuckSpawnCommand>()
                .To<DuckSpawnCommand>()
                .AsSingle();
        }
    }
}
