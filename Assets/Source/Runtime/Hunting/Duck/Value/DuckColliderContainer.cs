using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckColliderContainer : IReadOnlyValueContainer<Collider2D> { }

    public sealed class DuckColliderContainer : MonoValueContainer<Collider2D>, IDuckColliderContainer { }
}
