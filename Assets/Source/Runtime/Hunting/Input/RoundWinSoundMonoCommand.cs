using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IRoundWinSoundCommand : ICommand { }
    public sealed class RoundWinSoundMonoCommand : PlaySoundMonoCommand, IRoundWinSoundCommand
    {

    }
}