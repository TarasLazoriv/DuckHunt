using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckTransformContainer : IReadOnlyValueContainer<Transform> {}

    public sealed class DuckTransformContainer : MonoValueContainer<Transform>,IDuckTransformContainer   {}
}
