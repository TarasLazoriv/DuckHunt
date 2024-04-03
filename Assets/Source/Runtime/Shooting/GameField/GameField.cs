using System;
using UnityEngine;

namespace DuckHunt
{
    public readonly struct GameField : IEquatable<GameField>
    {
        public Vector2 BottomLeft { get; }
        public Vector2 TopRight { get; }

        public GameField(Vector2 bottomLeft, Vector2 topRight)
        {
            BottomLeft = bottomLeft;
            TopRight = topRight;
        }

        public bool Equals(GameField other)
        {
            return BottomLeft.Equals(other.BottomLeft) && TopRight.Equals(other.TopRight);
        }

        public override bool Equals(object obj)
        {
            return obj is GameField other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BottomLeft, TopRight);
        }
    }
}