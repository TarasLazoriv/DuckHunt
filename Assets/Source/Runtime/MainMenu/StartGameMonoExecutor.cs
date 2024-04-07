using System.Collections.Generic;
using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class StartGameMonoExecutor : MonoBehaviour, ICommandVoid<int>
    {
        [Inject] private readonly ZenjectSceneLoader m_sceneLoader = default;

        [SerializeField] private MonoCoroutineCommandRunner m_coroutineCommandRunner = default;

        private StartGameExecutor m_startGameExecutor = default;

        private static readonly IDictionary<int, IDuckCountValue> ButtonMapper = new Dictionary<int, IDuckCountValue>()
        {
            {0,new GameA()},
            {1,new GameB()},
            {2,new GameC()}
        };


        private void Awake()
        {
            m_startGameExecutor =
                new StartGameExecutor(m_coroutineCommandRunner, new StartGameCommand(m_sceneLoader));
        }

        public void Execute(int gameType)
        {
            if (ButtonMapper.TryGetValue(gameType, out IDuckCountValue duckCountValue))
            {
                m_startGameExecutor.Execute(duckCountValue, gameObject.scene);
            }
        }
    }
}