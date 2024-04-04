using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckFlyAwayPrefabContainer : IReadOnlyValueContainer<GameObject> { }

    public sealed class DuckFlyAwayPrefabContainer : MonoValueContainer<GameObject>, IDuckFlyAwayPrefabContainer { }
}
