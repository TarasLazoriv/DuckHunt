using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckPointsEarnedPrefabContainer : IReadOnlyValueContainer<GameObject> {}

    public sealed class DuckPointsEarnedPrefabContainer : MonoValueContainer<GameObject>,IDuckPointsEarnedPrefabContainer   {}
}
