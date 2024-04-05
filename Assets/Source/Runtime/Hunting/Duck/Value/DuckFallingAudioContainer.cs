using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckFallingAudioContainer : IReadOnlyValueContainer<AudioClip> {}

    public sealed class DuckFallingAudioContainer : MonoValueContainer<AudioClip>,IDuckFallingAudioContainer   {}
}
