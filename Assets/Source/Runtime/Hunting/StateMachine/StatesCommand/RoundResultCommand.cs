using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IRoundResultCommand : ICommand {}

    public sealed class RoundResultCommand : IRoundResultCommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
