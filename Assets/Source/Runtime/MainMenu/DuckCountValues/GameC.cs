using UnityEngine;

namespace DuckHunt
{

    public sealed class GameC : IDuckCountValue
    {
        public uint Value => (uint)Random.Range(1, 4);
    }
}