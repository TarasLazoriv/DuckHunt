using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class DuckFactory : PlaceholderFactory<GameObjectContext> { }
    public class DuckFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GameObjectContext m_duckPrefab = default;
        public override void InstallBindings()
        {

            Container
                .BindFactory<GameObjectContext, DuckFactory>()
                .FromComponentInNewPrefab(m_duckPrefab)
                .AsSingle();
        }
    }
}
