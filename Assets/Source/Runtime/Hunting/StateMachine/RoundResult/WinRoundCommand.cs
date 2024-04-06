using LazerLabs.Commands;
namespace DuckHunt
{
    public interface IWinRoundCommand : ICommand {}

    public sealed class WinRoundCommand : IWinRoundCommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
