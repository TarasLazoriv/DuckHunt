using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public class DuckFactoryInstaller : MonoInstaller
    {
        [SerializeField] private DuckMonoExecutor m_duckPrefab = default;
        [SerializeField] private DucksContainer m_ducksContainer = default;
        public override void InstallBindings()
        {

            Container
                .BindFactory<DuckMonoExecutor, DuckMonoExecutor.Factory>()
                .FromComponentInNewPrefab(m_duckPrefab)
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
