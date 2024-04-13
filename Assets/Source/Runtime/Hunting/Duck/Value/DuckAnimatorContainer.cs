using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckAnimatorContainer : IReadOnlyValueContainer<Animator> {}

    public sealed class DuckAnimatorContainer : MonoValueContainer<Animator>, IDuckAnimatorContainer { }
}
