using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class DuckInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Debug.LogError($"DuckInstaller 1");
            Container
                .Bind<int>()
                .FromInstance(1)
                .AsSingle();
            Debug.LogError($"DuckInstaller 2");
        }
    }
}
