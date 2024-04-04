using LazerLabs.Commands;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public interface IDuckFallCommand : ICommand { }

    public sealed class DuckFallCommand : IDuckFallCommand
    {
        private readonly DuckExecutor m_duckExecutor = default;
        private readonly IDuckTransformContainer m_duckTransformContainer = default;
        private readonly IGetGameFieldCommand m_gameFieldCommand = default;

        public DuckFallCommand(DuckExecutor duckExecutor, IDuckTransformContainer duckTransformContainer, IGetGameFieldCommand gameFieldCommand)
        {
            m_duckExecutor = duckExecutor;
            m_duckTransformContainer = duckTransformContainer;
            m_gameFieldCommand = gameFieldCommand;
        }

        public void Execute()
        {
            GameField gameField = m_gameFieldCommand.Execute();
            IEnumerable<Vector2> path = new[]
                { new Vector2(m_duckTransformContainer.Value.position.x, gameField.BottomLeft.y) };

            m_duckExecutor.Execute(path);
            m_duckExecutor.Execute();
        }
    }
}
