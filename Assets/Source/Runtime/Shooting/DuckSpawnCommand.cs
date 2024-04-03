using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckSpawnCommand : ICommand { }

    public sealed class DuckSpawnCommand : IDuckSpawnCommand
    {
        private readonly IGetRandomSpawnPointCommand m_getRandomSpawnPoint = default;
        private readonly DuckMonoExecutor.Factory m_factory = default;
        private readonly IDuckCountValue m_duckCountValue = default;

        public DuckSpawnCommand(IGetRandomSpawnPointCommand getRandomSpawnPoint, DuckMonoExecutor.Factory factory, IDuckCountValue duckCountValue)
        {
            m_getRandomSpawnPoint = getRandomSpawnPoint;
            m_factory = factory;
            m_duckCountValue = duckCountValue;
        }

        public void Execute()
        {
            for (int i = 0; i < m_duckCountValue.Value; i++)
            {
                Vector2 spawnPoint = m_getRandomSpawnPoint.Execute();
                DuckMonoExecutor duck = m_factory.Create();
                duck.transform.localScale = Vector3.one;
                duck.transform.position = spawnPoint;
                duck.Execute();
            }
        }
    }


}
