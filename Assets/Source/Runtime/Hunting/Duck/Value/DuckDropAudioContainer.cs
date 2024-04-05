using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckDropAudioContainer : IReadOnlyValueContainer<AudioClip> {}

    public sealed class DuckDropAudioContainer : MonoValueContainer<AudioClip>,IDuckDropAudioContainer   {}
}
