using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public class DuckFactoryInstaller : MonoInstaller
    {
        [SerializeField] private DuckMonoExecutor m_duckPrefab = default;
        public override void InstallBindings()
        {

            Container
                .BindFactory<DuckMonoExecutor, DuckMonoExecutor.Factory>()
                .FromComponentInNewPrefab(m_duckPrefab)
                .AsSingle();
        }
    }
}
