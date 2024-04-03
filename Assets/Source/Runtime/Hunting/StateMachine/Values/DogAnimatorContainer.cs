using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDogAnimatorContainer : IReadOnlyValueContainer<Animator> {}

    public sealed class DogAnimatorContainer : MonoValueContainer<Animator>, IDogAnimatorContainer { }
}
