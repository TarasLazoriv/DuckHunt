using LazerLabs.Commands;
using System.Collections.Generic;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckFallCommand : ICommand { }

    public sealed class DuckFallCommand : IDuckFallCommand
    {
        private readonly DuckExecutor m_duckExecutor = default;
        private readonly IDuckTransformContainer m_duckTransformContainer = default;
        private readonly IGetGameFieldCommand m_gameFieldCommand = default;
        private readonly IDuckAudioSourceContainer m_audioSourceContainer = default;
        private readonly IDuckFallingAudioContainer m_fallingAudioContainer = default;

        public DuckFallCommand(DuckExecutor duckExecutor, IDuckTransformContainer duckTransformContainer, IGetGameFieldCommand gameFieldCommand, IDuckAudioSourceContainer audioSourceContainer, IDuckFallingAudioContainer fallingAudioContainer)
        {
            m_duckExecutor = duckExecutor;
            m_duckTransformContainer = duckTransformContainer;
            m_gameFieldCommand = gameFieldCommand;
            m_audioSourceContainer = audioSourceContainer;
            m_fallingAudioContainer = fallingAudioContainer;
        }

        public void Execute()
        {
            GameField gameField = m_gameFieldCommand.Execute();
            IEnumerable<Vector2> path = new[]
                { new Vector2(m_duckTransformContainer.Value.position.x, gameField.BottomLeft.y) };

            m_duckExecutor.Execute(path);
            m_duckExecutor.Execute();
            m_audioSourceContainer.Value.loop = false;
            m_audioSourceContainer.Value.clip = m_fallingAudioContainer.Value;
            m_audioSourceContainer.Value.Play();
        }
    }
}
