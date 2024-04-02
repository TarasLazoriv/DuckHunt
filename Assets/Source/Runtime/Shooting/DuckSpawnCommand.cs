using System;
using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public interface IDuckSpawnCommand : ICommand { }

    public sealed class DuckSpawnCommand : IDuckSpawnCommand
    {
        [Inject] private readonly IGetRandomSpawnPointCommand m_getRandomSpawnPoint = default;
        [Inject] private readonly DuckMonoExecutor.Factory m_factory = default;


        public void Execute()
        {
            Vector2 spawnPoint = m_getRandomSpawnPoint.Execute();
            DuckMonoExecutor duck = m_factory.Create();
            duck.transform.localScale = Vector3.one;
            duck.transform.position = spawnPoint;
            duck.Execute();
        }
    }


}
