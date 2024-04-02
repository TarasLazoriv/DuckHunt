using UnityEngine;

namespace DuckHunt
{
    public abstract class MonoValueContainer<T> : MonoBehaviour, IReadOnlyValueContainer<T>
    {
        [field: SerializeField] public T Value { get; private set; }
    }
}