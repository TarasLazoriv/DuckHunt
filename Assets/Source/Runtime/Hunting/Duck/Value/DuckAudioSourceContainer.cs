using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckAudioSourceContainer : IReadOnlyValueContainer<AudioSource> {}

    public sealed class DuckAudioSourceContainer : MonoValueContainer<AudioSource>,IDuckAudioSourceContainer   {}
}
