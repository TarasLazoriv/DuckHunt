using System;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckDirectionCommand : ICommandVoid<Vector2> { }

    public sealed class DuckDirectionCommand : IDuckDirectionCommand
    {
        private readonly IDuckDirectionValue m_duckDirection = default;

        public DuckDirectionCommand(IDuckDirectionValue duckDirection)
        {
            m_duckDirection = duckDirection;
        }

        private const float MinXDelta = 1f;
        public void Execute(Vector2 change)
        {

            if (Math.Abs(change.x) < MinXDelta)
            {
                if (change.y >= 0)
                {
                    //up
                    m_duckDirection.Value = DuckDirection.Up;
                }
                else
                {
                    // down
                    m_duckDirection.Value = DuckDirection.Down;
                }
            }
            else
            {
                if (change.x >= 0)
                {
                    //right
                    m_duckDirection.Value = DuckDirection.Right;
                }
                else
                {
                    //left
                    m_duckDirection.Value = DuckDirection.Left;
                }
            }
        }
    }
}
