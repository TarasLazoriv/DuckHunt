using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IPerfectValueContainer : IReadOnlyValueContainer<GameObject> { }

    public sealed class PerfectObjectContainer : MonoValueContainer<GameObject>, IPerfectValueContainer { }
}
