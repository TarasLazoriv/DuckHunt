using System;
using System.Collections;
using System.Collections.Generic;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IPathGeneratorCommand : ICommand<Vector2, IEnumerable<Vector2>> { }
    public sealed class PathGeneratorCommand : IPathGeneratorCommand
    {
        private readonly IGetGameFieldCommand m_getGameField = default;
        // Number of points in the path
        public const int PathPointNum = 4;
        // Offset from the top of the field for the last point
        public const float OutOfField = 1f;

        public PathGeneratorCommand(IGetGameFieldCommand getGameField)
        {
            m_getGameField = getGameField;
        }

        // Generate a path based on the start point and game field
        public IEnumerable<Vector2> Execute(Vector2 startPoint)
        {
            GameField gameField = m_getGameField.Execute();
            List<Vector2> result = new List<Vector2> { startPoint };

            System.Random random = new System.Random();

            float totalDistance = Vector2.Distance(startPoint, new Vector2(startPoint.x, gameField.TopRight.y + OutOfField));
            float desiredSegmentLength = totalDistance / (PathPointNum - 1);

            for (int i = 1; i < PathPointNum; i++)
            {
                Vector2 prevPoint = result[i - 1];
                float nextX = random.Next((int)gameField.BottomLeft.x, (int)gameField.TopRight.x);
                Vector2 nextPoint = new Vector2(nextX, prevPoint.y + desiredSegmentLength);

                // Clamp the point within the game field bounds
                nextPoint.x = Math.Clamp(nextPoint.x, gameField.BottomLeft.x, gameField.TopRight.x);
                nextPoint.y = Math.Clamp(nextPoint.y, gameField.BottomLeft.y, gameField.TopRight.y);

                result.Add(nextPoint);
            }

            // Offset the last point above the top of the game field
            float lastPointX = random.Next((int)gameField.BottomLeft.x, (int)gameField.TopRight.x);
            result[PathPointNum - 1] = new Vector2(lastPointX, gameField.TopRight.y + OutOfField);

            return result;
        }
    }
}