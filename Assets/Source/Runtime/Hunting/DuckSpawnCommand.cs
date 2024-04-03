using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckSpawnCommand : ICommand { }

    public sealed class DuckSpawnCommand : IDuckSpawnCommand
    {
        private readonly IGetRandomSpawnPointCommand m_getRandomSpawnPoint = default;
        private readonly IDucksContainer m_ducksParent = default;
        private readonly DuckMonoExecutor.Factory m_factory = default;

        public DuckSpawnCommand(IGetRandomSpawnPointCommand getRandomSpawnPoint, DuckMonoExecutor.Factory factory, IDucksContainer ducksParent)
        {
            m_getRandomSpawnPoint = getRandomSpawnPoint;
            m_factory = factory;
            m_ducksParent = ducksParent;
        }

        public void Execute()
        {
            Vector2 spawnPoint = m_getRandomSpawnPoint.Execute();
            DuckMonoExecutor duck = m_factory.Create();
            duck.transform.SetParent(m_ducksParent.Value);
            duck.transform.localScale = Vector3.one;
            duck.transform.position = spawnPoint;
            duck.Execute();
        }
    }


}
