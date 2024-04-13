using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface ICanvasValueContainer : IReadOnlyValueContainer<Canvas> { }

    public sealed class CanvasValueContainer : MonoValueContainer<Canvas>, ICanvasValueContainer { }
}
