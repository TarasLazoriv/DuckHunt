using System;
using System.Collections.Generic;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckFallCommand : ICommandVoid<int> { }

    public sealed class DuckFallCommand : IDuckFallCommand
    {
        private readonly IDuckTransformContainer m_duckTransformContainer = default;
        private readonly IDuckColliderContainer m_duckColliderContainer = default;
        private readonly IDuckDirectionValue m_directionValue = default;
        private readonly DuckExecutor m_duckExecutor = default;

        public DuckFallCommand(IDuckTransformContainer duckTransformContainer, IDuckDirectionValue directionValue, IDuckColliderContainer duckColliderContainer, DuckExecutor duckExecutor)
        {
            m_duckTransformContainer = duckTransformContainer;
            m_directionValue = directionValue;
            m_duckColliderContainer = duckColliderContainer;
            m_duckExecutor = duckExecutor;
        }

        public void Execute(int duckId)
        {
            if (m_duckTransformContainer.Value.GetInstanceID() == duckId)
            {
                m_directionValue.Value = DuckDirection.Down;
                m_duckColliderContainer.Value.enabled = false;
                IEnumerable<Vector2> path = new[] { Vector2.one };
                m_duckExecutor.Execute(path);
                m_duckExecutor.Execute();
            }
        }
    }
}
