using System.Collections.Generic;
using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    /// <summary>
    /// This is an example of a mixed style, where the command is dynamically created, while the executor and runner act as components.
    /// </summary>
    public sealed class StartGameMonoExecutor : MonoBehaviour, ICommandVoid<int>
    {
        [Inject] private readonly ZenjectSceneLoader m_sceneLoader = default;

        [SerializeField] private CoroutineCommandMonoRunner m_coroutineCommandRunner = default;

        private StartGameExecutor m_startGameExecutor = default;

        private static readonly IDictionary<int, IDuckCountValue> ButtonMapper = new Dictionary<int, IDuckCountValue>()
        {
            {0,new GameA()},
            {1,new GameB()},
            {2,new GameC()}
        };


        private void Awake()
        {
            StartGameCommand command = new StartGameCommand(m_sceneLoader);
            m_startGameExecutor =
                new StartGameExecutor(m_coroutineCommandRunner, command);
        }

        /// <summary>
        /// Transform int game type to DuckCountValue and start a command with a correct state
        /// </summary>
        /// <param name="gameType"></param>
        public void Execute(int gameType)
        {
            if (ButtonMapper.TryGetValue(gameType, out IDuckCountValue duckCountValue))
            {
                m_startGameExecutor.Execute(duckCountValue, gameObject.scene);
            }
        }
    }
}