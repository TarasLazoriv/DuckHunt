using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IGetRandomSpawnPointCommand : ICommand<Vector2> { }

    public sealed class SpawnPointCommand : IGetRandomSpawnPointCommand
    {
        private readonly IGetGameFieldCommand m_getGameField = default;

        public SpawnPointCommand(IGetGameFieldCommand getGameField)
        {
            m_getGameField = getGameField;
        }
        public Vector2 Execute()
        {
            GameField field = m_getGameField.Execute();
            Vector2 randomPoint = new Vector2(
                Random.Range(field.BottomLeft.x, field.TopRight.x),
                field.BottomLeft.y
            );
            return randomPoint;
        }
    }
}
