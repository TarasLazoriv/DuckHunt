using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IPlayScoreSoundCommand : ICommand { }
    public sealed class PlayScoreSoundMonoCommand : PlaySoundMonoCommand, IPlayScoreSoundCommand { }
}