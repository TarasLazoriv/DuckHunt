using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IHuntingResultCommand : ICommand {}

    public sealed class HuntingResultCommand : IHuntingResultCommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
