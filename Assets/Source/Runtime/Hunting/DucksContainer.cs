using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDucksContainer : IReadOnlyValueContainer<Transform> {}

    public sealed class DucksContainer : MonoValueContainer<Transform>,IDucksContainer   {}
}
